namespace TSWorkBench.Pages
{
    partial class ReportsPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblKind = new System.Windows.Forms.Label();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.lblBase = new System.Windows.Forms.Label();
            this.dateBase = new TSWorkBench.Theme.DateBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dateFrom = new TSWorkBench.Theme.DateBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dateTo = new TSWorkBench.Theme.DateBox();
            this.lblRange = new System.Windows.Forms.Label();
            this.btnPeriodReport = new TSWorkBench.Theme.DarkButton();
            this.btnCopyMd = new TSWorkBench.Theme.DarkButton();
            this.btnExcel = new TSWorkBench.Theme.DarkButton();
            this.chkExcelAll = new System.Windows.Forms.CheckBox();
            this.btnOpenReports = new TSWorkBench.Theme.DarkButton();
            this.lblPreview = new System.Windows.Forms.Label();
            this.txtPreview = new System.Windows.Forms.TextBox();
            this.pnlOptions.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlOptions
            //
            this.pnlOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlOptions.Controls.Add(this.lblKind);
            this.pnlOptions.Controls.Add(this.rbWeek);
            this.pnlOptions.Controls.Add(this.rbMonth);
            this.pnlOptions.Controls.Add(this.rbCustom);
            this.pnlOptions.Controls.Add(this.lblBase);
            this.pnlOptions.Controls.Add(this.dateBase);
            this.pnlOptions.Controls.Add(this.lblFrom);
            this.pnlOptions.Controls.Add(this.dateFrom);
            this.pnlOptions.Controls.Add(this.lblTo);
            this.pnlOptions.Controls.Add(this.dateTo);
            this.pnlOptions.Controls.Add(this.lblRange);
            this.pnlOptions.Controls.Add(this.btnPeriodReport);
            this.pnlOptions.Controls.Add(this.btnCopyMd);
            this.pnlOptions.Controls.Add(this.btnExcel);
            this.pnlOptions.Controls.Add(this.chkExcelAll);
            this.pnlOptions.Controls.Add(this.btnOpenReports);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(1100, 150);
            this.pnlOptions.TabIndex = 0;
            //
            // lblKind
            //
            this.lblKind.AutoSize = true;
            this.lblKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblKind.Location = new System.Drawing.Point(18, 18);
            this.lblKind.Name = "lblKind";
            this.lblKind.Text = "보고 종류";
            //
            // rbWeek
            //
            this.rbWeek.AutoSize = true;
            this.rbWeek.Checked = true;
            this.rbWeek.Location = new System.Drawing.Point(100, 16);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.TabIndex = 0;
            this.rbWeek.TabStop = true;
            this.rbWeek.Text = "주간 (월~일)";
            this.rbWeek.CheckedChanged += new System.EventHandler(this.period_Changed);
            //
            // rbMonth
            //
            this.rbMonth.AutoSize = true;
            this.rbMonth.Location = new System.Drawing.Point(220, 16);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.TabIndex = 1;
            this.rbMonth.Text = "월간";
            this.rbMonth.CheckedChanged += new System.EventHandler(this.period_Changed);
            //
            // rbCustom
            //
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(300, 16);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.TabIndex = 2;
            this.rbCustom.Text = "기간 직접 지정";
            this.rbCustom.CheckedChanged += new System.EventHandler(this.period_Changed);
            //
            // lblBase
            //
            this.lblBase.AutoSize = true;
            this.lblBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBase.Location = new System.Drawing.Point(18, 58);
            this.lblBase.Name = "lblBase";
            this.lblBase.Text = "기준일";
            //
            // dateBase
            //
            this.dateBase.Location = new System.Drawing.Point(100, 54);
            this.dateBase.Name = "dateBase";
            this.dateBase.Size = new System.Drawing.Size(140, 25);
            this.dateBase.TabIndex = 3;
            this.dateBase.ValueChanged += new System.EventHandler(this.period_Changed);
            //
            // lblFrom
            //
            this.lblFrom.AutoSize = true;
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblFrom.Location = new System.Drawing.Point(270, 58);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Text = "시작";
            //
            // dateFrom
            //
            this.dateFrom.Location = new System.Drawing.Point(310, 54);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(140, 25);
            this.dateFrom.TabIndex = 4;
            this.dateFrom.ValueChanged += new System.EventHandler(this.period_Changed);
            //
            // lblTo
            //
            this.lblTo.AutoSize = true;
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTo.Location = new System.Drawing.Point(462, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Text = "끝";
            //
            // dateTo
            //
            this.dateTo.Location = new System.Drawing.Point(490, 54);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(140, 25);
            this.dateTo.TabIndex = 5;
            this.dateTo.ValueChanged += new System.EventHandler(this.period_Changed);
            //
            // lblRange
            //
            this.lblRange.AutoSize = true;
            this.lblRange.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRange.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblRange.Location = new System.Drawing.Point(650, 58);
            this.lblRange.Name = "lblRange";
            this.lblRange.Text = "기간";
            //
            // btnPeriodReport
            //
            this.btnPeriodReport.Accent = true;
            this.btnPeriodReport.Location = new System.Drawing.Point(18, 98);
            this.btnPeriodReport.Name = "btnPeriodReport";
            this.btnPeriodReport.Size = new System.Drawing.Size(210, 36);
            this.btnPeriodReport.TabIndex = 6;
            this.btnPeriodReport.Text = "업무 보고 만들기 (MD + HTML)";
            this.btnPeriodReport.Click += new System.EventHandler(this.btnPeriodReport_Click);
            //
            // btnCopyMd
            //
            this.btnCopyMd.Location = new System.Drawing.Point(236, 98);
            this.btnCopyMd.Name = "btnCopyMd";
            this.btnCopyMd.Size = new System.Drawing.Size(170, 36);
            this.btnCopyMd.TabIndex = 7;
            this.btnCopyMd.Text = "보고 MD 복사 (Notion)";
            this.btnCopyMd.Click += new System.EventHandler(this.btnCopyMd_Click);
            //
            // btnExcel
            //
            this.btnExcel.Location = new System.Drawing.Point(430, 98);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(140, 36);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Text = "엑셀 업무대장";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            //
            // chkExcelAll
            //
            this.chkExcelAll.AutoSize = true;
            this.chkExcelAll.Location = new System.Drawing.Point(580, 106);
            this.chkExcelAll.Name = "chkExcelAll";
            this.chkExcelAll.TabIndex = 9;
            this.chkExcelAll.Text = "기간 무시하고 전체 업무";
            //
            // btnOpenReports
            //
            this.btnOpenReports.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenReports.Location = new System.Drawing.Point(940, 98);
            this.btnOpenReports.Name = "btnOpenReports";
            this.btnOpenReports.Size = new System.Drawing.Size(140, 36);
            this.btnOpenReports.TabIndex = 10;
            this.btnOpenReports.Text = "보고서 폴더 열기";
            this.btnOpenReports.Click += new System.EventHandler(this.btnOpenReports_Click);
            //
            // lblPreview
            //
            this.lblPreview.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPreview.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblPreview.Location = new System.Drawing.Point(0, 150);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(1100, 40);
            this.lblPreview.TabIndex = 1;
            this.lblPreview.Text = "미리보기 (Markdown)";
            this.lblPreview.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtPreview
            //
            this.txtPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtPreview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtPreview.Multiline = true;
            this.txtPreview.Name = "txtPreview";
            this.txtPreview.ReadOnly = true;
            this.txtPreview.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPreview.TabIndex = 2;
            this.txtPreview.WordWrap = false;
            //
            // ReportsPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.txtPreview);
            this.Controls.Add(this.lblPreview);
            this.Controls.Add(this.pnlOptions);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "ReportsPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblKind;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.Label lblBase;
        private TSWorkBench.Theme.DateBox dateBase;
        private System.Windows.Forms.Label lblFrom;
        private TSWorkBench.Theme.DateBox dateFrom;
        private System.Windows.Forms.Label lblTo;
        private TSWorkBench.Theme.DateBox dateTo;
        private System.Windows.Forms.Label lblRange;
        private TSWorkBench.Theme.DarkButton btnPeriodReport;
        private TSWorkBench.Theme.DarkButton btnCopyMd;
        private TSWorkBench.Theme.DarkButton btnExcel;
        private System.Windows.Forms.CheckBox chkExcelAll;
        private TSWorkBench.Theme.DarkButton btnOpenReports;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.TextBox txtPreview;
    }
}
