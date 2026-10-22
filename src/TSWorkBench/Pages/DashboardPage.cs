using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Theme;

namespace TSWorkBench.Pages
{
    /// <summary>아침에 제일 먼저 보는 화면: 숫자 카드 + 해야 할 일 + 최근 완료.</summary>
    public partial class DashboardPage : PageBase
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        public override string HelpTopic => "3.1";

        public override string PageTitle => "대시보드";

        public override string PageSubtitle => DateTime.Today.ToString("yyyy-MM-dd (ddd)", CultureInfo.GetCultureInfo("ko-KR")) + " · 숫자 카드를 누르면 해당 목록으로 이동합니다";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            gridTodo.ContextMenuStrip = host.CreateItemMenu(gridTodo);
            gridRecent.ContextMenuStrip = host.CreateItemMenu(gridRecent);
        }

        public override void RefreshData()
        {
            var today = DateTime.Today;
            var all = Ws.Items.All;
            var active = all.Where(i => i.IsActive).ToList();
            var monthStart = new DateTime(today.Year, today.Month, 1);

            tileActive.ValueText = active.Count.ToString(CultureInfo.InvariantCulture);
            tileOverdue.ValueText = active.Count(i => i.IsOverdue(today)).ToString(CultureInfo.InvariantCulture);
            tileDue7.ValueText = active.Count(i => i.DueDate.HasValue && i.DueDate.Value.Date >= today && i.DueDate.Value.Date <= today.AddDays(7)).ToString(CultureInfo.InvariantCulture);
            tileFollowUp.ValueText = active.Count(IsFollowUp).ToString(CultureInfo.InvariantCulture);
            tileDoneMonth.ValueText = all.Count(i => i.Status == WorkStatus.Done && i.CompletedAt >= monthStart).ToString(CultureInfo.InvariantCulture);
            tileOverdue.BarColor = tileOverdue.ValueText == "0" ? DarkTheme.Ok : DarkTheme.Danger;

            WorkGrid.Fill(gridTodo, WorkQuery.SortForWork(active));
            WorkGrid.Fill(gridRecent, all.Where(i => i.Status == WorkStatus.Done).OrderByDescending(i => i.CompletedAt).Take(30));
        }

        public static bool IsFollowUp(WorkItem item)
        {
            return item.Type == WorkType.FollowUp || item.Status == WorkStatus.Verifying;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = ((DarkGrid)sender).SelectedTag<WorkItem>();
            if (e.RowIndex >= 0 && item != null)
            {
                Host.OpenItem(item);
            }
        }

        private void tileActive_Click(object sender, EventArgs e)
        {
            Host.ShowList("active");
        }

        private void tileOverdue_Click(object sender, EventArgs e)
        {
            Host.ShowList("overdue");
        }

        private void tileDue7_Click(object sender, EventArgs e)
        {
            Host.ShowList("due7");
        }

        private void tileFollowUp_Click(object sender, EventArgs e)
        {
            Host.ShowList("followup");
        }

        private void tileDoneMonth_Click(object sender, EventArgs e)
        {
            Host.ShowList("doneMonth");
        }
    }
}
