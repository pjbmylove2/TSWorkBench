using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Services;

namespace TSWorkBench.Pages
{
    /// <summary>주간·월간 보고, 엑셀 업무대장, Notion용 Markdown을 만든다.</summary>
    public partial class ReportsPage : PageBase
    {
        private bool updating;

        public ReportsPage()
        {
            InitializeComponent();
        }

        public override string HelpTopic => "3.6";

        public override string PageTitle => "보고서 · 업무대장";

        public override string PageSubtitle => "기간을 고르고 버튼을 누르면 데이터 폴더\\Reports에 저장됩니다. 양식은 Templates 폴더의 파일을 고치면 바뀝니다";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            dateBase.Value = DateTime.Today;
        }

        public override void RefreshData()
        {
            UpdateRange();
        }

        private string ReportTitle => rbWeek.Checked ? "주간 업무 보고" : rbMonth.Checked ? "월간 업무 보고" : "업무 보고";

        /// <summary>기간 [from, to). 주간은 월요일 시작.</summary>
        private void GetRange(out DateTime from, out DateTime to)
        {
            var baseDay = (dateBase.Value ?? DateTime.Today).Date;
            if (rbWeek.Checked)
            {
                var offset = ((int)baseDay.DayOfWeek + 6) % 7;
                from = baseDay.AddDays(-offset);
                to = from.AddDays(7);
            }
            else if (rbMonth.Checked)
            {
                from = new DateTime(baseDay.Year, baseDay.Month, 1);
                to = from.AddMonths(1);
            }
            else
            {
                from = (dateFrom.Value ?? baseDay).Date;
                to = (dateTo.Value ?? from).Date.AddDays(1);
                if (to <= from)
                {
                    to = from.AddDays(1);
                }
            }
        }

        private void UpdateRange()
        {
            if (Host == null || updating)
            {
                return;
            }

            updating = true;
            try
            {
                DateTime from, to;
                GetRange(out from, out to);
                dateBase.Enabled = !rbCustom.Checked;
                dateFrom.Enabled = rbCustom.Checked;
                dateTo.Enabled = rbCustom.Checked;
                if (!rbCustom.Checked)
                {
                    dateFrom.Value = from;
                    dateTo.Value = to.AddDays(-1);
                }

                var stats = StatsService.Compute(Ws.Items.All.ToList(), from, to, DateTime.Today);
                lblRange.Text = ReportGenerator.Day(from) + " ~ " + ReportGenerator.Day(to.AddDays(-1))
                                + "   ·   접수 " + stats.Received + "건 · 완료 " + stats.Done + "건 · 진행 중 " + stats.ActiveNow + "건";
                txtPreview.Text = new ReportGenerator(Ws).PeriodMarkdown(ReportTitle, from, to, DateTime.Today).Replace("\n", "\r\n");
            }
            catch (IOException ex)
            {
                txtPreview.Text = "보고서 템플릿을 읽지 못했습니다: " + ex.Message;
            }
            finally
            {
                updating = false;
            }
        }

        private void period_Changed(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio == null || radio.Checked)
            {
                UpdateRange();
            }
        }

        private void btnPeriodReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from, to;
                GetRange(out from, out to);
                var files = new ReportGenerator(Ws).SavePeriodReport(ReportTitle, from, to, DateTime.Today);
                ItemActions.OpenPath(files[1]);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "보고서 생성", ex);
            }
        }

        private void btnCopyMd_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtPreview.Text);
            MessageBox.Show(this, "보고 Markdown을 클립보드에 복사했습니다. Notion에 붙여넣기 하세요.", "복사 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime from, to;
                GetRange(out from, out to);
                var all = Ws.Items.All.ToList();
                var items = chkExcelAll.Checked ? all : StatsService.Touched(all, from, to).ToList();
                Directory.CreateDirectory(Ws.ReportsDir);
                var name = chkExcelAll.Checked
                    ? "업무대장_전체_" + DateTime.Today.ToString("yyyyMMdd") + ".xlsx"
                    : "업무대장_" + ReportGenerator.Day(from) + "_" + ReportGenerator.Day(to.AddDays(-1)) + ".xlsx";
                var path = Path.Combine(Ws.ReportsDir, name);
                ExcelExporter.Export(path, items, StatsService.Compute(all, from, to, DateTime.Today), ReportTitle + " 통계");
                ItemActions.OpenPath(path);
            }
            catch (IOException ex)
            {
                ItemActions.ShowError(this, "엑셀 저장 (같은 파일이 엑셀에서 열려 있으면 닫고 다시 시도)", ex);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "엑셀 저장", ex);
            }
        }

        private void btnOpenReports_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Ws.ReportsDir);
            ItemActions.OpenPath(Ws.ReportsDir);
        }
    }
}
