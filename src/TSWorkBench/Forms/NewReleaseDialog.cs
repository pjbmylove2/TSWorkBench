using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>
    /// ② 새 버전 배포. VS2022에서 커밋한 내용을 읽어 버전·변경 내역·업무 ID를 채우고,
    /// 버튼 하나로 이름표 → 배포본 → 설치 기록 → 업무 카드 기록 → NAS 백업까지 한다.
    /// </summary>
    public partial class NewReleaseDialog : DarkForm
    {
        private readonly Workspace ws;
        private readonly WorkItem card;
        private PendingInfo pending;

        // 배포는 백그라운드에서 돌고 취소할 수 없으므로, 도는 동안에는 창을 닫지 못하게 한다.
        private bool running;
        private DateTime startedAt;
        private ReleaseProgress current;

        public NewReleaseDialog()
        {
            InitializeComponent();
        }

        /// <param name="program">미리 고를 프로그램 (없으면 첫 번째)</param>
        /// <param name="card">업무 카드에서 열었으면 그 카드 — 업무 ID와 설치 위치를 채운다</param>
        public NewReleaseDialog(Workspace ws, string program, WorkItem card) : this()
        {
            this.ws = ws;
            this.card = card;
            dateDeployedAt.Value = DateTime.Now;
            UiHelpers.FillNames(cboCustomer, UiHelpers.CustomerNames(ws), card?.Customer);
            UiHelpers.FillNames(cboSite, UiHelpers.SiteNames(ws), card?.Site);
            UiHelpers.FillNames(cboEquipment, UiHelpers.EquipmentNames(ws), card?.Equipment);
            foreach (var p in ws.Programs.OrderBy(p => p.Name))
            {
                cboProgram.Items.Add(p.Name);
            }

            var preset = program ?? card?.TargetSystem;
            var match = cboProgram.Items.Cast<string>().FirstOrDefault(n => string.Equals(n, preset, StringComparison.OrdinalIgnoreCase));
            if (match != null)
            {
                cboProgram.SelectedItem = match;
            }
            else if (cboProgram.Items.Count > 0)
            {
                cboProgram.SelectedIndex = 0;
            }
            else
            {
                lblState.Text = "등록된 프로그램이 없습니다. 먼저 '① 프로그램 등록'을 하세요.";
                btnOk.Enabled = false;
            }
        }

        /// <summary>업무 카드에 적을 한 줄 (성공했을 때).</summary>
        public string ResultLine { get; private set; }

        public ReleaseRecord Record { get; private set; }

        private ProgramInfo Program => ws.FindProgram(cboProgram.SelectedItem as string);

        private void Log(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private async void cboProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadState();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadState();
        }

        private async Task LoadState()
        {
            var p = Program;
            if (p == null)
            {
                return;
            }

            lblState.Text = "Git 상태를 읽는 중…";
            btnOk.Enabled = false;
            try
            {
                var service = new ProgramService(ws);
                pending = await Task.Run(() => service.GetPending(p));
            }
            catch (Exception ex)
            {
                lblState.Text = "✖ " + ex.Message;
                lblState.ForeColor = DarkTheme.Danger;
                return;
            }

            ShowState(p);
            FillSites(p);
        }

        private void ShowState(ProgramInfo p)
        {
            var latest = pending.LatestVersion;
            var lines = new List<string>();
            var ok = true;
            if (!pending.IsRepo)
            {
                lines.Add("✖ 코드 폴더가 Git 저장소가 아닙니다: " + p.CodeFolder);
                ok = false;
            }
            else
            {
                lines.Add("최신 버전 " + (latest == null ? "없음" : "v" + latest) + " · 그 뒤 커밋 " + pending.NewCommits.Count + "개"
                          + (pending.BuildTime.HasValue ? " · 빌드 " + pending.BuildTime.Value.ToString("yyyy-MM-dd HH:mm") : " · 빌드 폴더 없음"));
                if (pending.UncommittedFiles.Count > 0)
                {
                    lines.Add("⚠ 커밋 안 한 변경 " + pending.UncommittedFiles.Count + "개 → VS2022 'Git 변경 내용'에서 먼저 커밋하고 '상태 다시 읽기'");
                    ok = false;
                }
                else if (pending.NewCommits.Count == 0)
                {
                    lines.Add("⚠ 마지막 버전 뒤에 새 커밋이 없습니다. 고친 코드를 먼저 커밋하세요.");
                }
                else if (!pending.BuildTime.HasValue)
                {
                    lines.Add("⚠ 빌드 결과 폴더를 못 찾았습니다 → Release로 빌드하거나 프로그램 보기 › 설정 고치기에서 지정 (그대로면 실행 파일 없이 배포)");
                }
                else if (pending.BuildIsOld)
                {
                    lines.Add("⚠ 빌드가 마지막 커밋보다 오래됐습니다 → VS2022에서 Release로 다시 빌드");
                }
                else
                {
                    lines.Add("✔ 배포할 준비가 됐습니다.");
                }
            }

            lblState.Text = string.Join("\r\n", lines);
            lblState.ForeColor = ok ? DarkTheme.Text : DarkTheme.Danger;
            btnOk.Enabled = ok;

            var current = latest ?? "0.0.0";
            rbPatch.Text = "버그 수정 → " + VersionUtil.Next(current, VersionStep.Patch);
            rbMinor.Text = "기능 추가 → " + VersionUtil.Next(current, VersionStep.Minor);
            rbMajor.Text = "큰 변경 → " + VersionUtil.Next(current, VersionStep.Major);
            ApplyStep();

            var ids = new List<string>();
            if (card != null && !string.IsNullOrEmpty(card.Id))
            {
                ids.Add(card.Id);
            }

            ids.AddRange(pending.WorkItemIds.Where(id => !ids.Contains(id)));
            txtWorkItems.Text = string.Join(", ", ids);
            txtNotes.Text = pending.SuggestedNotes;
        }

        private void ApplyStep()
        {
            var current = pending?.LatestVersion ?? "0.0.0";
            var step = rbPatch.Checked ? VersionStep.Patch : rbMajor.Checked ? VersionStep.Major : VersionStep.Minor;
            txtVersion.Text = pending?.LatestVersion == null ? VersionUtil.BaseVersion : VersionUtil.Next(current, step);
        }

        private void step_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                ApplyStep();
            }
        }

        /// <summary>이 프로그램이 깔려 있는 곳을 지금 버전과 함께 보여 준다. 업무 카드의 위치는 미리 체크.</summary>
        private void FillSites(ProgramInfo p)
        {
            clbSites.Items.Clear();
            var installed = new ProgramService(ws).InstallStatus().Where(r => string.Equals(r.Program, p.Name, StringComparison.OrdinalIgnoreCase));
            foreach (var row in installed)
            {
                var d = new Deployment { Customer = row.Customer, Site = row.Site, Equipment = row.Equipment };
                clbSites.Items.Add(new Choice<Deployment>(d, row.Location + "   (지금 v" + row.Version + ")"), IsCardLocation(d));
            }

            if (card != null && !clbSites.Items.Cast<Choice<Deployment>>().Any(c => IsCardLocation(c.Value))
                && (card.Site.Length > 0 || card.Equipment.Length > 0))
            {
                AddSite(new Deployment { Customer = card.Customer, Site = card.Site, Equipment = card.Equipment });
            }
        }

        private bool IsCardLocation(Deployment d)
        {
            return card != null && Same(d.Customer, card.Customer) && Same(d.Site, card.Site) && Same(d.Equipment, card.Equipment);
        }

        private void AddSite(Deployment d)
        {
            var label = string.Join(" / ", new[] { d.Customer, d.Site, d.Equipment }.Where(s => s.Length > 0)) + "   (새 위치)";
            clbSites.Items.Add(new Choice<Deployment>(d, label), true);
        }

        private void btnAddSite_Click(object sender, EventArgs e)
        {
            var d = new Deployment { Customer = cboCustomer.Text.Trim(), Site = cboSite.Text.Trim(), Equipment = cboEquipment.Text.Trim() };
            if (d.Site.Length + d.Equipment.Length == 0)
            {
                MessageBox.Show(this, "사이트/라인이나 설비를 입력하세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddSite(d);
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            var p = Program;
            if (p == null)
            {
                return;
            }

            var request = new NewReleaseRequest
            {
                Program = p.Name,
                Version = txtVersion.Text.Trim(),
                Notes = txtNotes.Text.Trim(),
                WorkItemIds = txtWorkItems.Text.Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim().ToUpperInvariant()).Distinct().ToList(),
                Targets = clbSites.CheckedItems.Cast<Choice<Deployment>>().Select(c => new Deployment { Customer = c.Value.Customer, Site = c.Value.Site, Equipment = c.Value.Equipment }).ToList(),
                DeployedAt = dateDeployedAt.Value ?? DateTime.Now,
                SkipCardId = card?.Id ?? ""
            };

            if (request.Targets.Count == 0 && MessageBox.Show(this, "설치한 곳을 체크하지 않았습니다. 배포본만 만들고 설치 기록은 나중에 할까요?",
                    Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            btnOk.Enabled = false;
            SetRunning(true);
            Cursor = Cursors.WaitCursor;
            try
            {
                var progress = new Progress<string>(Log);
                var status = new Progress<ReleaseProgress>(ShowProgress);
                var service = new ProgramService(ws);
                ReleaseRecord record = null;
                var line = await Task.Run(() => service.NewRelease(request, progress, out record, status));
                ResultLine = line;
                Record = record;
                SetRunning(false);
                ShowFinished(true, "✔ 배포를 마쳤습니다");
                MessageBox.Show(this, p.Name + " v" + record.Version + " 배포를 마쳤습니다.\n\n배포본: " + record.PackagePath
                                      + "\n설치 기록: " + request.Targets.Count + "곳", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                SetRunning(false);
                ShowFinished(false, "✖ 실패" + (current != null ? " — " + current.Title + " 단계" : ""));
                Log("✖ " + ex.Message);
                ItemActions.ShowError(this, "새 버전 배포", ex);
                btnOk.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SetRunning(bool value)
        {
            running = value;
            btnClose.Enabled = !value;
            btnRefresh.Enabled = !value;
            cboProgram.Enabled = !value;
            if (value)
            {
                startedAt = DateTime.Now;
                current = null;
                lblCurrent.ForeColor = DarkTheme.Text;
                lblCurrent.Text = "시작하는 중…";
                prgStep.Style = ProgressBarStyle.Marquee;
                pnlProgress.Visible = true;
                elapsedTimer.Start();
            }
            else
            {
                elapsedTimer.Stop();
            }
        }

        private void ShowProgress(ReleaseProgress p)
        {
            if (!running)
            {
                return;
            }

            current = p;
            if (p.Total > 0)
            {
                prgStep.Style = ProgressBarStyle.Continuous;
                prgStep.Maximum = p.Total;
                prgStep.Value = Math.Min(p.Done, p.Total);
            }
            else
            {
                prgStep.Style = ProgressBarStyle.Marquee;
            }

            UpdateCurrent();
        }

        private void UpdateCurrent()
        {
            var text = current == null ? "시작하는 중…" : "단계 " + current.Step + "/" + ReleaseProgress.StepCount + " · " + current.Title;
            if (current != null && current.Detail.Length > 0)
            {
                text += " › " + current.Detail;
            }

            if (current != null && current.Total > 0)
            {
                text += "  " + current.Done.ToString("N0") + " / " + current.Total.ToString("N0") + " 파일";
            }

            lblCurrent.Text = text + "   (경과 " + Elapsed() + ")";
        }

        private void ShowFinished(bool ok, string text)
        {
            prgStep.Style = ProgressBarStyle.Continuous;
            prgStep.Maximum = 1;
            prgStep.Value = ok ? 1 : 0;
            lblCurrent.ForeColor = ok ? DarkTheme.Text : DarkTheme.Danger;
            lblCurrent.Text = text + "   (걸린 시간 " + Elapsed() + ")";
        }

        private string Elapsed()
        {
            var t = DateTime.Now - startedAt;
            return ((int)t.TotalMinutes).ToString("00") + ":" + t.Seconds.ToString("00");
        }

        private void elapsedTimer_Tick(object sender, EventArgs e)
        {
            UpdateCurrent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (running && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MessageBox.Show(this, "배포가 진행 중입니다" + (current != null ? " (" + current.Title + ")" : "") + ".\n\n"
                                      + "창을 닫아도 작업은 멈추지 않으므로, 끝날 때까지 기다려 주세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            base.OnFormClosing(e);
        }

        private static bool Same(string a, string b)
        {
            return string.Equals((a ?? "").Trim(), (b ?? "").Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
