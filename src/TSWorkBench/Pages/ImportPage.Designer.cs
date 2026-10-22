namespace TSWorkBench.Pages
{
    partial class ImportPage
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new TSWorkBench.Theme.DarkButton();
            this.lblDepth = new System.Windows.Forms.Label();
            this.numDepth = new System.Windows.Forms.NumericUpDown();
            this.btnScan = new TSWorkBench.Theme.DarkButton();
            this.lblHelp = new System.Windows.Forms.Label();
            this.grid = new TSWorkBench.Theme.DarkGrid();
            this.colSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.flpBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImport = new TSWorkBench.Theme.DarkButton();
            this.chkCopyFiles = new System.Windows.Forms.CheckBox();
            this.btnNone = new TSWorkBench.Theme.DarkButton();
            this.btnAll = new TSWorkBench.Theme.DarkButton();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDepth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.flpBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.lblFolder);
            this.pnlTop.Controls.Add(this.txtFolder);
            this.pnlTop.Controls.Add(this.btnBrowse);
            this.pnlTop.Controls.Add(this.lblDepth);
            this.pnlTop.Controls.Add(this.numDepth);
            this.pnlTop.Controls.Add(this.btnScan);
            this.pnlTop.Controls.Add(this.lblHelp);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 100);
            this.pnlTop.TabIndex = 0;
            //
            // lblFolder
            //
            this.lblFolder.AutoSize = true;
            this.lblFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblFolder.Location = new System.Drawing.Point(0, 12);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Text = "과거 자료 폴더";
            //
            // txtFolder
            //
            this.txtFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtFolder.Location = new System.Drawing.Point(100, 8);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(520, 25);
            this.txtFolder.TabIndex = 0;
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(628, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 31);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "찾아보기";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // lblDepth
            //
            this.lblDepth.AutoSize = true;
            this.lblDepth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDepth.Location = new System.Drawing.Point(736, 12);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Text = "업무 단위 깊이";
            //
            // numDepth
            //
            this.numDepth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.numDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDepth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.numDepth.Location = new System.Drawing.Point(836, 8);
            this.numDepth.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDepth.Name = "numDepth";
            this.numDepth.Size = new System.Drawing.Size(50, 25);
            this.numDepth.TabIndex = 2;
            this.numDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // btnScan
            //
            this.btnScan.Accent = true;
            this.btnScan.Location = new System.Drawing.Point(900, 5);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(100, 31);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "스캔";
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            //
            // lblHelp
            //
            this.lblHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHelp.Location = new System.Drawing.Point(0, 44);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(1100, 52);
            this.lblHelp.Text = "깊이 1: 선택한 폴더 바로 아래 폴더 하나 = 업무 1건.   깊이 2: 연도·고객사로 나눈 폴더 안의 폴더 하나 = 업무 1건.\r\n중간에 낱개로 있는 문서(.docx .xlsx .pdf .hwp .eml .msg …)는 파일 하나 = 업무 1건. 날짜는 이름 → 메일 헤더 → 수정일 순으로 추정합니다. 표에서 고친 뒤 등록하세요.";
            //
            // grid
            //
            this.grid.AllowUserToResizeRows = false;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelect,
            this.colDate,
            this.colDateSource,
            this.colTitle,
            this.colType,
            this.colCustomer,
            this.colEquipment,
            this.colSystem,
            this.colFiles,
            this.colPath});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Name = "grid";
            this.grid.ReadOnly = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.TabIndex = 1;
            this.grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellValueChanged);
            this.grid.CurrentCellDirtyStateChanged += new System.EventHandler(this.grid_CurrentCellDirtyStateChanged);
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            //
            // colSelect
            //
            this.colSelect.HeaderText = "등록";
            this.colSelect.Name = "colSelect";
            this.colSelect.Width = 45;
            //
            // colDate
            //
            this.colDate.HeaderText = "날짜 ✎";
            this.colDate.Name = "colDate";
            this.colDate.Width = 95;
            //
            // colDateSource
            //
            this.colDateSource.HeaderText = "근거";
            this.colDateSource.Name = "colDateSource";
            this.colDateSource.ReadOnly = true;
            this.colDateSource.Width = 55;
            //
            // colTitle
            //
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.HeaderText = "제목 ✎";
            this.colTitle.MinimumWidth = 200;
            this.colTitle.Name = "colTitle";
            //
            // colType
            //
            this.colType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colType.HeaderText = "유형 ✎";
            this.colType.Name = "colType";
            this.colType.Width = 120;
            //
            // colCustomer
            //
            this.colCustomer.HeaderText = "고객사 ✎";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Width = 100;
            //
            // colEquipment
            //
            this.colEquipment.HeaderText = "설비 ✎";
            this.colEquipment.Name = "colEquipment";
            this.colEquipment.Width = 100;
            //
            // colSystem
            //
            this.colSystem.HeaderText = "시스템 ✎";
            this.colSystem.Name = "colSystem";
            this.colSystem.Width = 90;
            //
            // colFiles
            //
            this.colFiles.HeaderText = "파일";
            this.colFiles.Name = "colFiles";
            this.colFiles.ReadOnly = true;
            this.colFiles.Width = 50;
            //
            // colPath
            //
            this.colPath.HeaderText = "원본 경로";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            this.colPath.Width = 260;
            //
            // pnlBottom
            //
            this.pnlBottom.Controls.Add(this.lblSummary);
            this.pnlBottom.Controls.Add(this.flpBottom);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1100, 54);
            this.pnlBottom.TabIndex = 2;
            //
            // lblSummary
            //
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "폴더를 고르고 스캔하세요.";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // flpBottom
            //
            this.flpBottom.Controls.Add(this.btnImport);
            this.flpBottom.Controls.Add(this.chkCopyFiles);
            this.flpBottom.Controls.Add(this.btnNone);
            this.flpBottom.Controls.Add(this.btnAll);
            this.flpBottom.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpBottom.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBottom.Name = "flpBottom";
            this.flpBottom.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpBottom.Size = new System.Drawing.Size(720, 54);
            this.flpBottom.TabIndex = 1;
            this.flpBottom.WrapContents = false;
            //
            // btnImport
            //
            this.btnImport.Accent = true;
            this.btnImport.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(220, 36);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "선택 항목을 완료 업무로 등록";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // chkCopyFiles
            //
            this.chkCopyFiles.AutoSize = true;
            this.chkCopyFiles.Margin = new System.Windows.Forms.Padding(16, 8, 0, 0);
            this.chkCopyFiles.Name = "chkCopyFiles";
            this.chkCopyFiles.TabIndex = 2;
            this.chkCopyFiles.Text = "원본 파일을 업무 폴더로 복사 (기본: 위치만 링크)";
            //
            // btnNone
            //
            this.btnNone.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnNone.Name = "btnNone";
            this.btnNone.Size = new System.Drawing.Size(90, 36);
            this.btnNone.TabIndex = 1;
            this.btnNone.Text = "모두 해제";
            this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
            //
            // btnAll
            //
            this.btnAll.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(90, 36);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "모두 선택";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            //
            // ImportPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "ImportPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDepth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.flpBottom.ResumeLayout(false);
            this.flpBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private TSWorkBench.Theme.DarkButton btnBrowse;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.NumericUpDown numDepth;
        private TSWorkBench.Theme.DarkButton btnScan;
        private System.Windows.Forms.Label lblHelp;
        private TSWorkBench.Theme.DarkGrid grid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.FlowLayoutPanel flpBottom;
        private TSWorkBench.Theme.DarkButton btnImport;
        private System.Windows.Forms.CheckBox chkCopyFiles;
        private TSWorkBench.Theme.DarkButton btnNone;
        private TSWorkBench.Theme.DarkButton btnAll;
    }
}
