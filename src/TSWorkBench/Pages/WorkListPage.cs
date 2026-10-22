using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;

namespace TSWorkBench.Pages
{
    /// <summary>
    /// 업무 목록. PlannedMode면 "할 일 · 예정 업무" 화면으로, 진행 중 업무를 기한순으로 보여 준다.
    /// </summary>
    public partial class WorkListPage : PageBase
    {
        private const string AllText = "(전체)";

        /// <summary>상태 콤보 항목과 그 조건. 순서가 콤보 순서다.</summary>
        private static readonly List<KeyValuePair<string, Action<WorkQuery>>> StatusFilters = BuildStatusFilters();

        private List<WorkItem> shown = new List<WorkItem>();
        private bool suppress;

        public WorkListPage()
        {
            InitializeComponent();
        }

        public bool PlannedMode { get; set; }

        public override string PageTitle => PlannedMode ? "할 일 · 예정 업무" : "전체 업무 목록";

        public override string PageSubtitle => PlannedMode
            ? "진행 중인 업무를 기한·우선순위 순으로. 완료 시 자동 생성된 모니터링·재방문 업무도 여기에 나옵니다"
            : "더블클릭: 열기 · 오른쪽 클릭: 보고서·Notion·폴더 · Delete: 휴지통";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            grid.ContextMenuStrip = host.CreateItemMenu(grid);

            suppress = true;
            cboStatus.Items.AddRange(StatusFilters.Select(f => (object)f.Key).ToArray());
            cboStatus.SelectedIndex = PlannedMode ? 1 : 0;
            cboType.Items.Add(AllText);
            foreach (var choice in Labels.Choices<WorkType>())
            {
                cboType.Items.Add(choice);
            }

            cboType.SelectedIndex = 0;
            suppress = false;
        }

        public override void RefreshData()
        {
            suppress = true;
            var customer = cboCustomer.SelectedItem as string;
            cboCustomer.Items.Clear();
            cboCustomer.Items.Add(AllText);
            foreach (var name in UiHelpers.CustomerNames(Ws).Where(n => !string.IsNullOrWhiteSpace(n)).Distinct().OrderBy(n => n))
            {
                cboCustomer.Items.Add(name);
            }

            cboCustomer.SelectedItem = customer != null && cboCustomer.Items.Contains(customer) ? customer : AllText;
            suppress = false;
            ApplyFilter();
        }

        /// <summary>대시보드 숫자 카드에서 넘어올 때 조건을 건다.</summary>
        public void ApplyPreset(string preset)
        {
            suppress = true;
            ResetControls();
            switch (preset)
            {
                case "active": cboStatus.SelectedIndex = 1; break;
                case "overdue": cboStatus.SelectedIndex = 2; break;
                case "due7": cboStatus.SelectedIndex = 3; break;
                case "followup": cboStatus.SelectedIndex = 4; break;
                case "doneMonth":
                    cboStatus.SelectedIndex = StatusFilters.FindIndex(f => f.Key == Labels.Of(WorkStatus.Done));
                    dateFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    break;
            }

            suppress = false;
            ApplyFilter();
        }

        private WorkQuery BuildQuery()
        {
            var q = new WorkQuery { Text = txtSearch.Text.Trim(), From = dateFrom.Value, To = dateTo.Value };
            if (cboStatus.SelectedIndex >= 0)
            {
                StatusFilters[cboStatus.SelectedIndex].Value(q);
            }

            var type = cboType.SelectedItem as Choice<WorkType>;
            if (type != null)
            {
                q.Type = type.Value;
            }

            var customer = cboCustomer.SelectedItem as string;
            if (customer != null && customer != AllText)
            {
                q.Customer = customer;
            }

            return q;
        }

        private void ApplyFilter()
        {
            if (suppress || Host == null)
            {
                return;
            }

            var query = BuildQuery().Apply(Ws.Items.All, DateTime.Today);
            shown = (PlannedMode ? WorkQuery.SortForWork(query) : query.OrderByDescending(i => i.ReceivedAt)).ToList();
            WorkGrid.Fill(grid, shown);
            lblCount.Text = shown.Count + "건  ·  진행 중 " + shown.Count(i => i.IsActive) + "건  ·  기한 지남 " + shown.Count(i => i.IsOverdue(DateTime.Today)) + "건";
        }

        private void ResetControls()
        {
            txtSearch.Text = "";
            cboStatus.SelectedIndex = PlannedMode ? 1 : 0;
            cboType.SelectedIndex = 0;
            cboCustomer.SelectedItem = AllText;
            dateFrom.Value = null;
            dateTo.Value = null;
        }

        private static List<KeyValuePair<string, Action<WorkQuery>>> BuildStatusFilters()
        {
            var list = new List<KeyValuePair<string, Action<WorkQuery>>>
            {
                new KeyValuePair<string, Action<WorkQuery>>("(전체)", q => { }),
                new KeyValuePair<string, Action<WorkQuery>>("진행 중 (완료·취소 제외)", q => q.ActiveOnly = true),
                new KeyValuePair<string, Action<WorkQuery>>("기한 지남", q => q.OverdueOnly = true),
                new KeyValuePair<string, Action<WorkQuery>>("7일 안에 기한", q => q.DueWithinDays = 7),
                new KeyValuePair<string, Action<WorkQuery>>("모니터링·후속", q => q.FollowUpOnly = true)
            };
            foreach (var choice in Labels.Choices<WorkStatus>())
            {
                var status = choice.Value;
                list.Add(new KeyValuePair<string, Action<WorkQuery>>(choice.Text, q => q.Status = status));
            }

            return list;
        }

        private void filter_Changed(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            ApplyFilter();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            suppress = true;
            ResetControls();
            suppress = false;
            ApplyFilter();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = grid.SelectedTag<WorkItem>();
            if (e.RowIndex >= 0 && item != null)
            {
                Host.OpenItem(item);
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            var item = grid.SelectedTag<WorkItem>();
            if (item == null)
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Host.OpenItem(item);
            }
            else if (e.KeyCode == Keys.Delete && ItemActions.MoveToTrash(this, Ws, item))
            {
                Host.RefreshCurrentPage();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "Excel 통합 문서 (*.xlsx)|*.xlsx",
                FileName = "업무대장_" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx",
                InitialDirectory = Ws.ReportsDir
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    var from = dateFrom.Value ?? (shown.Count == 0 ? DateTime.Today : shown.Min(i => i.ReceivedAt).Date);
                    var to = (dateTo.Value ?? DateTime.Today).Date.AddDays(1);
                    var stats = StatsService.Compute(shown, from, to, DateTime.Today);
                    ExcelExporter.Export(dialog.FileName, shown, stats, "업무 목록 통계");
                    ItemActions.OpenPath(Path.GetDirectoryName(dialog.FileName));
                }
                catch (Exception ex)
                {
                    ItemActions.ShowError(this, "엑셀 저장", ex);
                }
            }
        }
    }
}
