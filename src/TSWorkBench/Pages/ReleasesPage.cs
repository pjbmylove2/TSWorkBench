using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Pages
{
    /// <summary>배포 이력: 배포본(프로그램·버전)과 설비별 설치 기록, 설비별 현재 버전.</summary>
    public partial class ReleasesPage : PageBase
    {
        private const string AllText = "(전체)";
        private bool loading;

        public ReleasesPage()
        {
            InitializeComponent();
        }

        public override string PageTitle => "배포 이력";

        public override string PageSubtitle => "프로그램 버전별 배포본과 어느 설비에 언제 설치했는지. 배포 방법은 docs\\배포관리_가이드.md 참고";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            var menu = DarkMenuRenderer.CreateMenu();
            menu.Items.Add("되돌림 표시 / 해제", null, (s, e) => ToggleRolledBack());
            gridDeploy.ContextMenuStrip = menu;
            gridDeploy.CellMouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                {
                    gridDeploy.CurrentCell = gridDeploy.Rows[e.RowIndex].Cells[0];
                }
            };
            viewReleases.Checked = true;
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
            FillReleases();
            FillCurrent();
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

        private void FillReleases()
        {
            var keep = gridReleases.SelectedTag<ReleaseRecord>();
            gridReleases.Rows.Clear();
            foreach (var r in Ws.Releases.All.Where(r => Matches(r.Program)).OrderByDescending(r => r.ReleasedAt))
            {
                var row = gridReleases.Rows[gridReleases.Rows.Add(r.Program, r.Version, ReportGenerator.Day(r.ReleasedAt),
                    r.Deployments.Count, string.Join(", ", r.WorkItemIds))];
                row.Tag = r;
                if (ReferenceEquals(r, keep))
                {
                    gridReleases.CurrentCell = row.Cells[0];
                }
            }

            ShowDetail();
        }

        private void FillCurrent()
        {
            gridCurrent.Rows.Clear();
            foreach (var v in ReleaseRepository.CurrentVersions(Ws.Releases.All).Where(v => Matches(v.Program)))
            {
                gridCurrent.Rows.Add(v.Customer, v.Site, v.Equipment, v.Program, v.Version, ReportGenerator.Minute(v.DeployedAt), v.WorkItemId);
            }
        }

        private void ShowDetail()
        {
            var r = gridReleases.SelectedTag<ReleaseRecord>();
            gridDeploy.Rows.Clear();
            if (r == null)
            {
                txtDetail.Text = Ws.Releases.All.Count == 0
                    ? "등록된 배포본이 없습니다.\r\n\r\n'+ 배포본 등록 · 패키지 만들기'로 빌드 폴더를 보관소에 버전별로 보관하고,\r\n설비에 설치할 때마다 '설비에 설치 기록'을 남기세요."
                    : "";
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine(r.Key + (r.Tag.Length > 0 ? "   태그 " + r.Tag : "") + (r.Commit.Length > 0 ? "   커밋 " + r.Commit : ""));
            sb.AppendLine("배포일 " + ReportGenerator.Minute(r.ReleasedAt));
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
            FillCurrent();
        }

        private void view_CheckedChanged(object sender, EventArgs e)
        {
            split.Visible = viewReleases.Checked;
            gridCurrent.Visible = viewCurrent.Checked;
        }

        private void cboProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                FillReleases();
                FillCurrent();
            }
        }

        private void gridReleases_SelectionChanged(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            using (var dialog = new ReleaseDialog(Ws, ProgramFilter))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    RefreshData();
                }
            }
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

        private void btnStore_Click(object sender, EventArgs e)
        {
            var r = gridReleases.SelectedTag<ReleaseRecord>();
            var path = r != null && Directory.Exists(r.PackagePath) ? r.PackagePath : Ws.Settings.ReleaseStore;
            if (string.IsNullOrWhiteSpace(path))
            {
                MessageBox.Show(this, "설정 › 배포본 보관소 경로를 먼저 지정하세요.", "보관소", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ItemActions.OpenPath(path);
        }
    }
}
