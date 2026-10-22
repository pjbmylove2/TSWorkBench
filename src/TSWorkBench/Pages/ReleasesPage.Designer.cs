namespace TSWorkBench.Pages
{
    partial class ReleasesPage
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
            this.flpFilter = new System.Windows.Forms.FlowLayoutPanel();
            this.viewReleases = new TSWorkBench.Theme.NavButton();
            this.viewCurrent = new TSWorkBench.Theme.NavButton();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cboProgram = new TSWorkBench.Theme.DarkComboBox();
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStore = new TSWorkBench.Theme.DarkButton();
            this.btnDeploy = new TSWorkBench.Theme.DarkButton();
            this.btnRelease = new TSWorkBench.Theme.DarkButton();
            this.split = new System.Windows.Forms.SplitContainer();
            this.gridReleases = new TSWorkBench.Theme.DarkGrid();
            this.colProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReleasedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeployCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDeploy = new TSWorkBench.Theme.DarkGrid();
            this.colDeployedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeployItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRolledBack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDeployTitle = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.gridCurrent = new TSWorkBench.Theme.DarkGrid();
            this.colCurCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurDeployedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCurItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.flpFilter.SuspendLayout();
            this.flpActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReleases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeploy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCurrent)).BeginInit();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.flpFilter);
            this.pnlTop.Controls.Add(this.flpActions);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 54);
            this.pnlTop.TabIndex = 0;
            //
            // flpFilter
            //
            this.flpFilter.Controls.Add(this.viewReleases);
            this.flpFilter.Controls.Add(this.viewCurrent);
            this.flpFilter.Controls.Add(this.lblProgram);
            this.flpFilter.Controls.Add(this.cboProgram);
            this.flpFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFilter.Name = "flpFilter";
            this.flpFilter.TabIndex = 0;
            this.flpFilter.WrapContents = false;
            //
            // viewReleases
            //
            this.viewReleases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.viewReleases.BarAtBottom = true;
            this.viewReleases.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.viewReleases.Name = "viewReleases";
            this.viewReleases.Padding = new System.Windows.Forms.Padding(0);
            this.viewReleases.Size = new System.Drawing.Size(130, 40);
            this.viewReleases.TabIndex = 0;
            this.viewReleases.Text = "배포본";
            this.viewReleases.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewReleases.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            //
            // viewCurrent
            //
            this.viewCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.viewCurrent.BarAtBottom = true;
            this.viewCurrent.Margin = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.viewCurrent.Name = "viewCurrent";
            this.viewCurrent.Padding = new System.Windows.Forms.Padding(0);
            this.viewCurrent.Size = new System.Drawing.Size(160, 40);
            this.viewCurrent.TabIndex = 1;
            this.viewCurrent.Text = "설비별 현재 버전";
            this.viewCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewCurrent.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            //
            // lblProgram
            //
            this.lblProgram.AutoSize = true;
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProgram.Margin = new System.Windows.Forms.Padding(0, 12, 6, 0);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Text = "프로그램";
            //
            // cboProgram
            //
            this.cboProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgram.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.Size = new System.Drawing.Size(170, 25);
            this.cboProgram.TabIndex = 2;
            this.cboProgram.SelectedIndexChanged += new System.EventHandler(this.cboProgram_SelectedIndexChanged);
            //
            // flpActions
            //
            this.flpActions.Controls.Add(this.btnStore);
            this.flpActions.Controls.Add(this.btnDeploy);
            this.flpActions.Controls.Add(this.btnRelease);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpActions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(560, 54);
            this.flpActions.TabIndex = 1;
            this.flpActions.WrapContents = false;
            //
            // btnStore
            //
            this.btnStore.Margin = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(130, 36);
            this.btnStore.TabIndex = 2;
            this.btnStore.Text = "보관소 열기";
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            //
            // btnDeploy
            //
            this.btnDeploy.Margin = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(150, 36);
            this.btnDeploy.TabIndex = 1;
            this.btnDeploy.Text = "설비에 설치 기록";
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            //
            // btnRelease
            //
            this.btnRelease.Accent = true;
            this.btnRelease.Margin = new System.Windows.Forms.Padding(8, 2, 0, 0);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(220, 36);
            this.btnRelease.TabIndex = 0;
            this.btnRelease.Text = "+ 배포본 등록 · 패키지 만들기";
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            //
            // split
            //
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 54);
            this.split.Name = "split";
            //
            // split.Panel1
            //
            this.split.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.split.Panel1.Controls.Add(this.gridReleases);
            //
            // split.Panel2
            //
            this.split.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.split.Panel2.Controls.Add(this.gridDeploy);
            this.split.Panel2.Controls.Add(this.lblDeployTitle);
            this.split.Panel2.Controls.Add(this.txtDetail);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(14, 10, 10, 10);
            this.split.Size = new System.Drawing.Size(1100, 596);
            this.split.SplitterDistance = 480;
            this.split.SplitterWidth = 3;
            this.split.TabIndex = 1;
            //
            // gridReleases
            //
            this.gridReleases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProgram,
            this.colVersion,
            this.colReleasedAt,
            this.colDeployCount,
            this.colWorkItems});
            this.gridReleases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReleases.Name = "gridReleases";
            this.gridReleases.TabIndex = 0;
            this.gridReleases.SelectionChanged += new System.EventHandler(this.gridReleases_SelectionChanged);
            //
            // colProgram
            //
            this.colProgram.HeaderText = "프로그램";
            this.colProgram.Name = "colProgram";
            this.colProgram.Width = 110;
            //
            // colVersion
            //
            this.colVersion.HeaderText = "버전";
            this.colVersion.Name = "colVersion";
            this.colVersion.Width = 80;
            //
            // colReleasedAt
            //
            this.colReleasedAt.HeaderText = "배포일";
            this.colReleasedAt.Name = "colReleasedAt";
            this.colReleasedAt.Width = 95;
            //
            // colDeployCount
            //
            this.colDeployCount.HeaderText = "설치";
            this.colDeployCount.Name = "colDeployCount";
            this.colDeployCount.Width = 55;
            //
            // colWorkItems
            //
            this.colWorkItems.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colWorkItems.HeaderText = "관련 업무";
            this.colWorkItems.Name = "colWorkItems";
            //
            // gridDeploy
            //
            this.gridDeploy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeployedAt,
            this.colLocation,
            this.colDeployItem,
            this.colRolledBack,
            this.colNote});
            this.gridDeploy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDeploy.Name = "gridDeploy";
            this.gridDeploy.TabIndex = 2;
            //
            // colDeployedAt
            //
            this.colDeployedAt.HeaderText = "설치 일시";
            this.colDeployedAt.Name = "colDeployedAt";
            this.colDeployedAt.Width = 135;
            //
            // colLocation
            //
            this.colLocation.HeaderText = "위치";
            this.colLocation.Name = "colLocation";
            this.colLocation.Width = 200;
            //
            // colDeployItem
            //
            this.colDeployItem.HeaderText = "업무";
            this.colDeployItem.Name = "colDeployItem";
            this.colDeployItem.Width = 125;
            //
            // colRolledBack
            //
            this.colRolledBack.HeaderText = "되돌림";
            this.colRolledBack.Name = "colRolledBack";
            this.colRolledBack.Width = 65;
            //
            // colNote
            //
            this.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote.HeaderText = "메모";
            this.colNote.Name = "colNote";
            //
            // lblDeployTitle
            //
            this.lblDeployTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDeployTitle.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDeployTitle.Name = "lblDeployTitle";
            this.lblDeployTitle.Size = new System.Drawing.Size(593, 36);
            this.lblDeployTitle.TabIndex = 1;
            this.lblDeployTitle.Text = "설치 이력  (오른쪽 클릭: 되돌림 표시)";
            this.lblDeployTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtDetail
            //
            this.txtDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDetail.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(593, 230);
            this.txtDetail.TabIndex = 0;
            //
            // gridCurrent
            //
            this.gridCurrent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCurCustomer,
            this.colCurSite,
            this.colCurEquipment,
            this.colCurProgram,
            this.colCurVersion,
            this.colCurDeployedAt,
            this.colCurItem});
            this.gridCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCurrent.Location = new System.Drawing.Point(0, 54);
            this.gridCurrent.Name = "gridCurrent";
            this.gridCurrent.TabIndex = 2;
            this.gridCurrent.Visible = false;
            //
            // colCurCustomer
            //
            this.colCurCustomer.HeaderText = "고객사";
            this.colCurCustomer.Name = "colCurCustomer";
            this.colCurCustomer.Width = 120;
            //
            // colCurSite
            //
            this.colCurSite.HeaderText = "사이트/라인";
            this.colCurSite.Name = "colCurSite";
            this.colCurSite.Width = 170;
            //
            // colCurEquipment
            //
            this.colCurEquipment.HeaderText = "설비";
            this.colCurEquipment.Name = "colCurEquipment";
            this.colCurEquipment.Width = 160;
            //
            // colCurProgram
            //
            this.colCurProgram.HeaderText = "프로그램";
            this.colCurProgram.Name = "colCurProgram";
            this.colCurProgram.Width = 140;
            //
            // colCurVersion
            //
            this.colCurVersion.HeaderText = "현재 버전";
            this.colCurVersion.Name = "colCurVersion";
            this.colCurVersion.Width = 100;
            //
            // colCurDeployedAt
            //
            this.colCurDeployedAt.HeaderText = "설치 일시";
            this.colCurDeployedAt.Name = "colCurDeployedAt";
            this.colCurDeployedAt.Width = 140;
            //
            // colCurItem
            //
            this.colCurItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCurItem.HeaderText = "관련 업무";
            this.colCurItem.Name = "colCurItem";
            //
            // ReleasesPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.split);
            this.Controls.Add(this.gridCurrent);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "ReleasesPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlTop.ResumeLayout(false);
            this.flpFilter.ResumeLayout(false);
            this.flpFilter.PerformLayout();
            this.flpActions.ResumeLayout(false);
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReleases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeploy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCurrent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.FlowLayoutPanel flpFilter;
        private TSWorkBench.Theme.NavButton viewReleases;
        private TSWorkBench.Theme.NavButton viewCurrent;
        private System.Windows.Forms.Label lblProgram;
        private TSWorkBench.Theme.DarkComboBox cboProgram;
        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private TSWorkBench.Theme.DarkButton btnStore;
        private TSWorkBench.Theme.DarkButton btnDeploy;
        private TSWorkBench.Theme.DarkButton btnRelease;
        private System.Windows.Forms.SplitContainer split;
        private TSWorkBench.Theme.DarkGrid gridReleases;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReleasedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeployCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkItems;
        private TSWorkBench.Theme.DarkGrid gridDeploy;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeployedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeployItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRolledBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.Label lblDeployTitle;
        private System.Windows.Forms.TextBox txtDetail;
        private TSWorkBench.Theme.DarkGrid gridCurrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurDeployedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCurItem;
    }
}
