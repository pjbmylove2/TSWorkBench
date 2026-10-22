namespace TSWorkBench.Pages
{
    partial class WorkListPage
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
            this.components = new System.ComponentModel.Container();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cboStatus = new TSWorkBench.Theme.DarkComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new TSWorkBench.Theme.DarkComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new TSWorkBench.Theme.DarkComboBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dateFrom = new TSWorkBench.Theme.DateBox();
            this.lblTilde = new System.Windows.Forms.Label();
            this.dateTo = new TSWorkBench.Theme.DateBox();
            this.btnReset = new TSWorkBench.Theme.DarkButton();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExport = new TSWorkBench.Theme.DarkButton();
            this.grid = new TSWorkBench.Theme.DarkGrid();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCompleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlFilter.SuspendLayout();
            this.flpFilter.SuspendLayout();
            this.flpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            //
            // pnlFilter
            //
            this.pnlFilter.Controls.Add(this.flpFilter);
            this.pnlFilter.Controls.Add(this.flpActions);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1100, 84);
            this.pnlFilter.TabIndex = 0;
            //
            // flpFilter
            //
            this.flpFilter.Controls.Add(this.lblSearch);
            this.flpFilter.Controls.Add(this.txtSearch);
            this.flpFilter.Controls.Add(this.lblStatus);
            this.flpFilter.Controls.Add(this.cboStatus);
            this.flpFilter.Controls.Add(this.lblType);
            this.flpFilter.Controls.Add(this.cboType);
            this.flpFilter.Controls.Add(this.lblCustomer);
            this.flpFilter.Controls.Add(this.cboCustomer);
            this.flpFilter.Controls.Add(this.lblPeriod);
            this.flpFilter.Controls.Add(this.dateFrom);
            this.flpFilter.Controls.Add(this.lblTilde);
            this.flpFilter.Controls.Add(this.dateTo);
            this.flpFilter.Controls.Add(this.btnReset);
            this.flpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFilter.Name = "flpFilter";
            this.flpFilter.TabIndex = 0;
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSearch.Margin = new System.Windows.Forms.Padding(0, 10, 4, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "검색";
            //
            // txtSearch
            //
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(210, 25);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0, 10, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "상태";
            //
            // cboStatus
            //
            this.cboStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboStatus.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(180, 25);
            this.cboStatus.TabIndex = 1;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.filter_Changed);
            //
            // lblType
            //
            this.lblType.AutoSize = true;
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblType.Margin = new System.Windows.Forms.Padding(0, 10, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Text = "유형";
            //
            // cboType
            //
            this.cboType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboType.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(140, 25);
            this.cboType.TabIndex = 2;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.filter_Changed);
            //
            // lblCustomer
            //
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(0, 10, 4, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Text = "고객사";
            //
            // cboCustomer
            //
            this.cboCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(150, 25);
            this.cboCustomer.TabIndex = 3;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.filter_Changed);
            //
            // lblPeriod
            //
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPeriod.Margin = new System.Windows.Forms.Padding(0, 10, 4, 0);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Text = "기간(접수·완료)";
            //
            // dateFrom
            //
            this.dateFrom.Margin = new System.Windows.Forms.Padding(0, 6, 4, 0);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(130, 25);
            this.dateFrom.TabIndex = 4;
            this.dateFrom.ValueChanged += new System.EventHandler(this.filter_Changed);
            //
            // lblTilde
            //
            this.lblTilde.AutoSize = true;
            this.lblTilde.Margin = new System.Windows.Forms.Padding(0, 10, 4, 0);
            this.lblTilde.Name = "lblTilde";
            this.lblTilde.Text = "~";
            //
            // dateTo
            //
            this.dateTo.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(130, 25);
            this.dateTo.TabIndex = 5;
            this.dateTo.ValueChanged += new System.EventHandler(this.filter_Changed);
            //
            // btnReset
            //
            this.btnReset.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 30);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "초기화";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            //
            // flpActions
            //
            this.flpActions.Controls.Add(this.btnExport);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(150, 84);
            this.flpActions.TabIndex = 1;
            //
            // btnExport
            //
            this.btnExport.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(140, 32);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "이 목록 엑셀로";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            //
            // grid
            //
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colReceived,
            this.colDue,
            this.colStatus,
            this.colPriority,
            this.colType,
            this.colCustomer,
            this.colSite,
            this.colEquipment,
            this.colSystem,
            this.colTitle,
            this.colCompleted});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 1;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 105;
            //
            // colReceived
            //
            this.colReceived.DataPropertyName = "ReceivedAt";
            this.colReceived.HeaderText = "접수일";
            this.colReceived.Name = "colReceived";
            this.colReceived.Width = 85;
            //
            // colDue
            //
            this.colDue.DataPropertyName = "DueDate";
            this.colDue.HeaderText = "기한";
            this.colDue.Name = "colDue";
            this.colDue.Width = 85;
            //
            // colStatus
            //
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "상태";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 90;
            //
            // colPriority
            //
            this.colPriority.DataPropertyName = "Priority";
            this.colPriority.HeaderText = "우선";
            this.colPriority.Name = "colPriority";
            this.colPriority.Width = 50;
            //
            // colType
            //
            this.colType.DataPropertyName = "Type";
            this.colType.HeaderText = "유형";
            this.colType.Name = "colType";
            this.colType.Width = 100;
            //
            // colCustomer
            //
            this.colCustomer.DataPropertyName = "Customer";
            this.colCustomer.HeaderText = "고객사";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Width = 80;
            //
            // colSite
            //
            this.colSite.DataPropertyName = "Site";
            this.colSite.HeaderText = "사이트/라인";
            this.colSite.Name = "colSite";
            this.colSite.Width = 90;
            //
            // colEquipment
            //
            this.colEquipment.DataPropertyName = "Equipment";
            this.colEquipment.HeaderText = "설비";
            this.colEquipment.Name = "colEquipment";
            this.colEquipment.Width = 90;
            //
            // colSystem
            //
            this.colSystem.DataPropertyName = "TargetSystem";
            this.colSystem.HeaderText = "시스템";
            this.colSystem.Name = "colSystem";
            this.colSystem.Width = 80;
            //
            // colTitle
            //
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "제목";
            this.colTitle.MinimumWidth = 160;
            this.colTitle.Name = "colTitle";
            //
            // colCompleted
            //
            this.colCompleted.DataPropertyName = "CompletedAt";
            this.colCompleted.HeaderText = "완료일";
            this.colCompleted.Name = "colCompleted";
            this.colCompleted.Width = 85;
            //
            // lblCount
            //
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(1100, 30);
            this.lblCount.TabIndex = 2;
            this.lblCount.Text = "0건";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // searchTimer
            //
            this.searchTimer.Interval = 300;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            //
            // WorkListPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.grid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.pnlFilter);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "WorkListPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlFilter.ResumeLayout(false);
            this.flpFilter.ResumeLayout(false);
            this.flpFilter.PerformLayout();
            this.flpActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblStatus;
        private TSWorkBench.Theme.DarkComboBox cboStatus;
        private System.Windows.Forms.Label lblType;
        private TSWorkBench.Theme.DarkComboBox cboType;
        private System.Windows.Forms.Label lblCustomer;
        private TSWorkBench.Theme.DarkComboBox cboCustomer;
        private System.Windows.Forms.Label lblPeriod;
        private TSWorkBench.Theme.DateBox dateFrom;
        private System.Windows.Forms.Label lblTilde;
        private TSWorkBench.Theme.DateBox dateTo;
        private TSWorkBench.Theme.DarkButton btnReset;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private TSWorkBench.Theme.DarkButton btnExport;
        private TSWorkBench.Theme.DarkGrid grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCompleted;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Timer searchTimer;
    }
}
