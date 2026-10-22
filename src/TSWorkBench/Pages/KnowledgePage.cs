using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;

namespace TSWorkBench.Pages
{
    /// <summary>지식베이스: 같은 증상이 다시 왔을 때 과거 해결 사례(증상 → 원인 → 조치)를 바로 찾는다.</summary>
    public partial class KnowledgePage : PageBase
    {
        public KnowledgePage()
        {
            InitializeComponent();
        }

        public override string PageTitle => "지식베이스 (해결 사례)";

        public override string PageSubtitle => "완료된 업무의 현상 · 원인 · 조치 · 재발방지를 검색합니다. 예) \"카메라 끊김\", \"2라인 오판정\"";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            grid.ContextMenuStrip = host.CreateItemMenu(grid);
        }

        public override void RefreshData()
        {
            var items = Ws.Items.All
                .Where(i => chkIncludeActive.Checked || i.Status == WorkStatus.Done)
                .Where(i => WorkQuery.MatchesText(i, txtSearch.Text))
                .OrderByDescending(i => i.CompletedAt ?? i.ReceivedAt)
                .ToList();
            WorkGrid.Fill(grid, items);
            lblCount.Text = items.Count + "건";
            ShowDetail();
        }

        private void ShowDetail()
        {
            var item = grid.SelectedTag<WorkItem>();
            if (item == null)
            {
                txtDetail.Text = "";
                return;
            }

            var sb = new StringBuilder();
            sb.AppendLine("[" + item.Id + "] " + item.Title);
            sb.AppendLine(Labels.Of(item.Type) + " · " + Labels.Of(item.Status) + " · " + item.Location + (item.TargetSystem.Length > 0 ? " · " + item.TargetSystem : ""));
            sb.AppendLine("접수 " + ReportGenerator.Day(item.ReceivedAt) + "   완료 " + ReportGenerator.Day(item.CompletedAt));
            Section(sb, "■ 현상", item.Symptom, item.SymptomWhen, item.Reproduction);
            Section(sb, "■ 원인", item.Cause, item.CauseEvidence);
            Section(sb, "■ 조치", item.ActionHardware, item.ActionSoftware, item.ChangedFiles);
            Section(sb, "■ 검증 · 재발방지", item.Verification, item.Prevention);
            if (item.Attachments.Count > 0)
            {
                Section(sb, "■ 첨부", string.Join("\r\n", item.Attachments.Select(a => a.Name)));
            }

            txtDetail.Text = sb.ToString();
        }

        private static void Section(StringBuilder sb, string title, params string[] parts)
        {
            sb.AppendLine();
            sb.AppendLine(title);
            var text = string.Join("\r\n", parts.Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p.Trim()));
            sb.AppendLine(text.Length == 0 ? "-" : text.Replace("\r\n", "\n").Replace("\n", "\r\n"));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            RefreshData();
        }

        private void chkIncludeActive_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnOpen_Click(sender, e);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            var item = grid.SelectedTag<WorkItem>();
            if (item != null)
            {
                Host.OpenItem(item);
            }
        }
    }
}
