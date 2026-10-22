using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Theme;

namespace TSWorkBench.Pages
{
    /// <summary>
    /// 프로그램 · 배포: ① 프로그램 등록 ② 새 버전 배포 ③ 다른 곳에 설치 기록.
    /// 보기는 설치 현황(어디에 몇 버전) · 버전 목록 · 프로그램(코드 폴더·NAS 백업 상태).
    /// </summary>
    public partial class ReleasesPage : PageBase
    {
        private const string AllText = "(전체)";
        private bool loading;

        public ReleasesPage()
        {
            InitializeComponent();
        }

        public override string PageTitle => "프로그램 · 배포";

        public override string PageSubtitle => "버전 관리 순서: ① 프로그램 등록(처음 한 번) → VS2022에서 커밋 → ② 새 버전 배포 → ③ 다른 곳에 설치 기록";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            var deployMenu = DarkMenuRenderer.CreateMenu();
            deployMenu.Items.Add("되돌림 표시 / 해제", null, (s, e) => ToggleRolledBack());
            gridDeploy.ContextMenuStrip = deployMenu;
            SelectRowOnRightClick(gridDeploy);

            var programMenu = DarkMenuRenderer.CreateMenu();
            programMenu.Items.Add("VS2022로 열기 (.sln)", null, (s, e) => OpenSolution());
            programMenu.Items.Add("코드 폴더 열기", null, (s, e) => OpenFolder(p => p.CodeFolder));
            programMenu.Items.Add("빌드 결과 폴더 열기", null, (s, e) => OpenFolder(p => p.BuildFolder));
            programMenu.Items.Add("과거 버전 가져오기", null, (s, e) => btnImport_Click(s, e));
            programMenu.Items.Add(new ToolStripSeparator());
            programMenu.Items.Add("설정 고치기 (폴더·NAS 위치)", null, (s, e) => EditProgram());
            gridPrograms.ContextMenuStrip = programMenu;
            SelectRowOnRightClick(gridPrograms);

            viewStatus.Checked = true;
        }

        private static void SelectRowOnRightClick(DarkGrid grid)
        {
            grid.CellMouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                {
                    grid.CurrentCell = grid.Rows[e.RowIndex].Cells[0];
                }
            };
        }

        public override void RefreshData()
        {
            loading = true;
            var selected = cboProgram.SelectedItem as string;
            cboProgram.Items.Clear();
            cboProgram.Items.Add(AllText);
            foreach (var name in UiHelpers.ProgramNames(Ws).Where(n => !string.IsNullOrWhiteSpace(n)).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy(n => n))
            {
                cboProgram.Items.Add(name);
            }

            cboProgram.SelectedItem = selected != null && cboProgram.Items.Contains(selected) ? selected : AllText;
            loading = false;
            FillAll();
        }

        private void FillAll()
        {
            FillStatus();
            FillReleases();
            FillPrograms();
        }

        private string ProgramFilter
        {
            get
            {
                var p = cboProgram.SelectedItem as string;
                return p == null || p == AllText ? null : p;
            }
        }

        private bool Matches(string program)
        {
            return ProgramFilter == null || string.Equals(program, ProgramFilter, StringComparison.OrdinalIgnoreCase);
        }

        // ── 설치 현황 ────────────────────────────────────────

        private void FillStatus()
        {
            gridStatus.Rows.Clear();
            var rows = new ProgramService(Ws).InstallStatus().Where(r => Matches(r.Program))
                .OrderBy(r => r.Program).ThenBy(r => r.Customer).ThenBy(r => r.Site).ThenBy(r => r.Equipment);
            foreach (var r in rows)
            {
                var state = r.IsLatest ? "✔ 최신" : "▲ 업데이트 가능";
                var row = gridStatus.Rows[gridStatus.Rows.Add(r.Customer, r.Site, r.Equipment, r.Program, "v" + r.Version, "v" + r.LatestVersion, state,
                    ReportGenerator.Minute(r.DeployedAt), r.WorkItemId)];
                row.Tag = r;
                var color = r.IsLatest ? DarkTheme.Ok : DarkTheme.Warning;
                row.Cells[colStState.Index].Style.ForeColor = color;
                row.Cells[colStState.Index].Style.SelectionForeColor = color;
                row.Cells[colStVersion.Index].Style.ForeColor = color;
                row.Cells[colStVersion.Index].Style.SelectionForeColor = color;
            }

            if (viewStatus.Checked)
            {
                lblHelp.Text = gridStatus.Rows.Count == 0
                    ? "아직 설치 기록이 없습니다. '① 프로그램 등록'에서 지금 쓰는 곳을 넣거나, '③ 다른 곳에 설치 기록'으로 추가하세요."
                    : "▲ 업데이트 가능 = 더 높은 버전이 있는 곳. 그 위치에 새 버전을 깔았으면 '③ 다른 곳에 설치 기록'으로 남기세요.";
            }
        }

        // ── 버전 목록 ────────────────────────────────────────

        private void FillReleases()
        {
            var keep = gridReleases.SelectedTag<ReleaseRecord>();
            gridReleases.Rows.Clear();
            foreach (var r in Ws.Releases.All.Where(r => Matches(r.Program))
                         .OrderBy(r => r.Program).ThenByDescending(r => r.Version, Comparer<string>.Create(VersionUtil.Compare)))
            {
                var row = gridReleases.Rows[gridReleases.Rows.Add(r.Program, "v" + r.Version, ReportGenerator.Day(r.ReleasedAt),
                    r.Deployments.Count(d => !d.RolledBack), string.Join(", ", r.WorkItemIds))];
                row.Tag = r;
                if (ReferenceEquals(r, keep))
                {
                    gridReleases.CurrentCell = row.Cells[0];
                }
            }

            ShowDetail();
        }

        private void ShowDetail()
        {
            var r = gridReleases.SelectedTag<ReleaseRecord>();
            gridDeploy.Rows.Clear();
            if (r == null)
            {
                txtDetail.Text = Ws.Releases.All.Count == 0 ? "아직 버전이 없습니다. '① 프로그램 등록'부터 하세요." : "";
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine(r.Program + " v" + r.Version + (r.Commit.Length > 0 ? "   커밋 " + r.Commit : "") + "   " + ReportGenerator.Minute(r.ReleasedAt));
            sb.AppendLine("배포본 " + (r.PackagePath.Length > 0 ? r.PackagePath : "-"));
            sb.AppendLine("관련 업무 " + (r.WorkItemIds.Count > 0 ? string.Join(", ", r.WorkItemIds) : "-"));
            sb.AppendLine();
            sb.AppendLine("■ 변경 내역");
            sb.AppendLine(string.IsNullOrWhiteSpace(r.Notes) ? "-" : r.Notes.Replace("\r\n", "\n").Replace("\n", "\r\n"));
            txtDetail.Text = sb.ToString();

            foreach (var d in r.Deployments.OrderByDescending(d => d.DeployedAt))
            {
                var row = gridDeploy.Rows[gridDeploy.Rows.Add(ReportGenerator.Minute(d.DeployedAt), d.Location, d.WorkItemId, d.RolledBack ? "되돌림" : "", d.Note)];
                row.Tag = d;
                if (d.RolledBack)
                {
                    row.DefaultCellStyle.ForeColor = DarkTheme.Muted;
                }
            }
        }

        private void ToggleRolledBack()
        {
            var r = gridReleases.SelectedTag<ReleaseRecord>();
            var d = gridDeploy.SelectedTag<Deployment>();
            if (r == null || d == null)
            {
                return;
            }

            d.RolledBack = !d.RolledBack;
            try
            {
                Ws.Releases.Save(r);
            }
            catch (Exception ex)
            {
                d.RolledBack = !d.RolledBack;
                ItemActions.ShowError(this, "저장", ex);
            }

            ShowDetail();
            FillStatus();
        }

        // ── 프로그램 ─────────────────────────────────────────

        private void FillPrograms()
        {
            gridPrograms.Rows.Clear();
            var service = new ProgramService(Ws);
            var installed = service.InstallStatus();
            foreach (var p in Ws.Programs.Where(p => Matches(p.Name)).OrderBy(p => p.Name))
            {
                var latest = service.LatestVersion(p.Name);
                var row = gridPrograms.Rows[gridPrograms.Rows.Add(p.Name, latest == null ? "-" : "v" + latest,
                    installed.Count(i => string.Equals(i.Program, p.Name, StringComparison.OrdinalIgnoreCase)) + "곳",
                    CodeState(service, p), p.CodeFolder, p.HasRemote ? p.GitRemote : "(없음)")];
                row.Tag = p;
            }

            if (viewPrograms.Checked)
            {
                lblHelp.Text = "더블클릭 또는 오른쪽 클릭: VS2022로 열기 · 폴더 열기 · 설정 고치기. 코드 상태가 '커밋 안 한 변경'이면 VS2022에서 커밋하세요.";
            }
        }

        private static string CodeState(ProgramService service, ProgramInfo p)
        {
            try
            {
                if (!Directory.Exists(p.CodeFolder))
                {
                    return "✖ 코드 폴더 없음 → ① 프로그램 등록";
                }

                var git = service.Git(p);
                if (!git.HasCommits)
                {
                    return "✖ Git 아님 → ① 프로그램 등록";
                }

                var pending = git.PendingChanges().Count;
                var latest = service.LatestVersion(p.Name);
                var newCommits = latest != null && git.TagExists("v" + latest) ? git.CommitsSince("v" + latest).Count : 0;
                if (pending > 0)
                {
                    return "● 커밋 안 한 변경 " + pending + "개";
                }

                return newCommits > 0 ? "▲ 배포 안 한 커밋 " + newCommits + "개" : "✔ 깨끗함";
            }
            catch (Exception ex)
            {
                return "✖ " + ex.Message;
            }
        }

        private ProgramInfo SelectedProgram()
        {
            var p = gridPrograms.SelectedTag<ProgramInfo>() ?? Ws.FindProgram(ProgramFilter);
            if (p == null)
            {
                MessageBox.Show(this, "프로그램 보기에서 프로그램을 고르거나 위쪽 '프로그램'에서 선택하세요.", "프로그램", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return p;
        }

        private void OpenSolution()
        {
            var p = SelectedProgram();
            if (p == null)
            {
                return;
            }

            var sln = Directory.Exists(p.CodeFolder) ? Directory.GetFiles(p.CodeFolder, "*.sln").FirstOrDefault() : null;
            if (sln == null)
            {
                ItemActions.OpenPath(p.CodeFolder);
                return;
            }

            Process.Start(new ProcessStartInfo(sln) { UseShellExecute = true });
        }

        private void OpenFolder(Func<ProgramInfo, string> path)
        {
            var p = SelectedProgram();
            if (p != null)
            {
                ItemActions.OpenPath(path(p));
            }
        }

        private void EditProgram()
        {
            var p = SelectedProgram();
            if (p == null)
            {
                return;
            }

            using (var dialog = new ProgramSetupDialog(Ws, p))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void gridPrograms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OpenSolution();
            }
        }

        // ── 화면 전환 · 버튼 ─────────────────────────────────

        private void view_CheckedChanged(object sender, EventArgs e)
        {
            gridStatus.Visible = viewStatus.Checked;
            split.Visible = viewVersions.Checked;
            gridPrograms.Visible = viewPrograms.Checked;
            if (viewVersions.Checked)
            {
                lblHelp.Text = "버전을 고르면 변경 내역과 설치한 곳이 보입니다. 설치 이력에서 오른쪽 클릭 › 되돌림 표시 (이전 버전으로 되돌렸을 때).";
            }

            if (Host != null)
            {
                FillAll();
            }
        }

        private void cboProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                FillAll();
            }
        }

        private void gridReleases_SelectionChanged(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (var dialog = new ProgramSetupDialog(Ws, null))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void btnNewRelease_Click(object sender, EventArgs e)
        {
            using (var dialog = new NewReleaseDialog(Ws, ProgramFilter ?? gridPrograms.SelectedTag<ProgramInfo>()?.Name, null))
            {
                dialog.ShowDialog(this);
            }

            RefreshData();
        }

        private void btnDeploy_Click(object sender, EventArgs e)
        {
            using (var dialog = new DeployDialog(Ws, gridReleases.SelectedTag<ReleaseRecord>(), null))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshData();
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            var p = SelectedProgram();
            if (p == null)
            {
                return;
            }

            using (var dialog = new ImportVersionsDialog(Ws, p))
            {
                dialog.ShowDialog(this);
            }

            RefreshData();
        }

        private async void btnBackup_Click(object sender, EventArgs e)
        {
            btnBackup.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var service = new ProgramService(Ws);
                var failures = await Task.Run(() => service.PushAll());
                var count = Ws.Programs.Count(p => p.HasRemote);
                MessageBox.Show(this, failures.Count == 0
                        ? "NAS 코드 백업을 마쳤습니다 (" + count + "개 프로그램)."
                        : "일부 프로그램을 백업하지 못했습니다.\n\n" + string.Join("\n", failures),
                    "NAS 코드 백업", MessageBoxButtons.OK, failures.Count == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            finally
            {
                btnBackup.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            var r = gridReleases.SelectedTag<ReleaseRecord>();
            var path = viewVersions.Checked && r != null && Directory.Exists(r.PackagePath) ? r.PackagePath : Ws.Settings.ReleaseStore;
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show(this, "설정 › 배포본 보관소 경로를 먼저 지정하세요.", "보관소", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ItemActions.OpenPath(path);
        }
    }
}
