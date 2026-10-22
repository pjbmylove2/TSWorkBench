using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Pages;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>지금 업무와 비슷한 과거 업무를 보여 주고, 고른 사례를 원인 근거에 인용할 수 있게 한다.</summary>
    public partial class SimilarCasesForm : DarkForm
    {
        public SimilarCasesForm()
        {
            InitializeComponent();
        }

        public SimilarCasesForm(List<WorkItem> cases) : this()
        {
            WorkGrid.Fill(grid, cases);
            Text = "유사 사례 " + cases.Count + "건";
            btnUse.Enabled = cases.Count > 0;
            if (cases.Count == 0)
            {
                txtDetail.Text = "비슷한 업무가 없습니다.\r\n설비·대상 시스템·태그를 채우면 더 잘 찾습니다.";
            }
        }

        /// <summary>"원인 근거에 추가"로 고른 사례. 없으면 null.</summary>
        public WorkItem SelectedCase { get; private set; }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            var item = grid.SelectedTag<WorkItem>();
            if (item != null)
            {
                txtDetail.Text = KnowledgePage.DetailText(item);
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnUse_Click(sender, e);
            }
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            SelectedCase = grid.SelectedTag<WorkItem>();
            if (SelectedCase != null)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
