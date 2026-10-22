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
            this.flpActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnRegister = new TSWorkBench.Theme.DarkButton();
            this.btnNewRelease = new TSWorkBench.Theme.DarkButton();
            this.btnDeploy = new TSWorkBench.Theme.DarkButton();
            this.btnImport = new TSWorkBench.Theme.DarkButton();
            this.btnBackup = new TSWorkBench.Theme.DarkButton();
            this.btnStore = new TSWorkBench.Theme.DarkButton();
            this.flpView = new System.Windows.Forms.FlowLayoutPanel();
            this.viewStatus = new TSWorkBench.Theme.NavButton();
            this.viewVersions = new TSWorkBench.Theme.NavButton();
            this.viewPrograms = new TSWorkBench.Theme.NavButton();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cboProgram = new TSWorkBench.Theme.DarkComboBox();
            this.gridStatus = new TSWorkBench.Theme.DarkGrid();
            this.colStCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStProgram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStLatest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStDeployedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gridPrograms = new TSWorkBench.Theme.DarkGrid();
            this.colPgName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPgLatest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPgSites = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPgState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPgCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPgRemote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHelp = new System.Windows.Forms.Label();
            this.flpActions.SuspendLayout();
            this.flpView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReleases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeploy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrograms)).BeginInit();
            this.SuspendLayout();
            //
            // flpActions
            //
            this.flpActions.Controls.Add(this.btnRegister);
            this.flpActions.Controls.Add(this.btnNewRelease);
            this.flpActions.Controls.Add(this.btnDeploy);
            this.flpActions.Controls.Add(this.btnImport);
            this.flpActions.Controls.Add(this.btnBackup);
            this.flpActions.Controls.Add(this.btnStore);
            this.flpActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpActions.Name = "flpActions";
            this.flpActions.Size = new System.Drawing.Size(1180, 52);
            this.flpActions.TabIndex = 0;
            this.flpActions.WrapContents = false;
            //
            // btnRegister
            //
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0, 2, 8, 0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(170, 40);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "① 프로그램 등록";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            //
            // btnNewRelease
            //
            this.btnNewRelease.Accent = true;
            this.btnNewRelease.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNewRelease.Margin = new System.Windows.Forms.Padding(0, 2, 8, 0);
            this.btnNewRelease.Name = "btnNewRelease";
            this.btnNewRelease.Size = new System.Drawing.Size(180, 40);
            this.btnNewRelease.TabIndex = 1;
            this.btnNewRelease.Text = "② 새 버전 배포";
            this.btnNewRelease.Click += new System.EventHandler(this.btnNewRelease_Click);
            //
            // btnDeploy
            //
            this.btnDeploy.Margin = new System.Windows.Forms.Padding(0, 2, 24, 0);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(210, 40);
            this.btnDeploy.TabIndex = 2;
            this.btnDeploy.Text = "③ 다른 곳에 설치 기록";
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            //
            // btnImport
            //
            this.btnImport.Margin = new System.Windows.Forms.Padding(0, 2, 8, 0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(170, 40);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "과거 버전 가져오기";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            //
            // btnBackup
            //
            this.btnBackup.Margin = new System.Windows.Forms.Padding(0, 2, 8, 0);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(150, 40);
            this.btnBackup.TabIndex = 4;
            this.btnBackup.Text = "NAS 코드 백업";
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            //
            // btnStore
            //
            this.btnStore.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(130, 40);
            this.btnStore.TabIndex = 5;
            this.btnStore.Text = "보관소 열기";
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            //
            // flpView
            //
            this.flpView.Controls.Add(this.viewStatus);
            this.flpView.Controls.Add(this.viewVersions);
            this.flpView.Controls.Add(this.viewPrograms);
            this.flpView.Controls.Add(this.lblProgram);
            this.flpView.Controls.Add(this.cboProgram);
            this.flpView.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpView.Name = "flpView";
            this.flpView.Size = new System.Drawing.Size(1180, 50);
            this.flpView.TabIndex = 1;
            this.flpView.WrapContents = false;
            //
            // viewStatus
            //
            this.viewStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.viewStatus.BarAtBottom = true;
            this.viewStatus.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.viewStatus.Name = "viewStatus";
            this.viewStatus.Padding = new System.Windows.Forms.Padding(0);
            this.viewStatus.Size = new System.Drawing.Size(170, 40);
            this.viewStatus.TabIndex = 0;
            this.viewStatus.Text = "설치 현황 (어디에 몇 버전)";
            this.viewStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewStatus.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            //
            // viewVersions
            //
            this.viewVersions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.viewVersions.BarAtBottom = true;
            this.viewVersions.Margin = new System.Windows.Forms.Padding(0, 4, 4, 0);
            this.viewVersions.Name = "viewVersions";
            this.viewVersions.Padding = new System.Windows.Forms.Padding(0);
            this.viewVersions.Size = new System.Drawing.Size(130, 40);
            this.viewVersions.TabIndex = 1;
            this.viewVersions.Text = "버전 목록";
            this.viewVersions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewVersions.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            //
            // viewPrograms
            //
            this.viewPrograms.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.viewPrograms.BarAtBottom = true;
            this.viewPrograms.Margin = new System.Windows.Forms.Padding(0, 4, 32, 0);
            this.viewPrograms.Name = "viewPrograms";
            this.viewPrograms.Padding = new System.Windows.Forms.Padding(0);
            this.viewPrograms.Size = new System.Drawing.Size(150, 40);
            this.viewPrograms.TabIndex = 2;
            this.viewPrograms.Text = "프로그램 · 코드";
            this.viewPrograms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.viewPrograms.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            //
            // lblProgram
            //
            this.lblProgram.AutoSize = true;
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProgram.Margin = new System.Windows.Forms.Padding(0, 16, 6, 0);
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Text = "프로그램";
            //
            // cboProgram
            //
            this.cboProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgram.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.Size = new System.Drawing.Size(200, 25);
            this.cboProgram.TabIndex = 3;
            this.cboProgram.SelectedIndexChanged += new System.EventHandler(this.cboProgram_SelectedIndexChanged);
            //
            // gridStatus
            //
            this.gridStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStCustomer,
            this.colStSite,
            this.colStEquipment,
            this.colStProgram,
            this.colStVersion,
            this.colStLatest,
            this.colStState,
            this.colStDeployedAt,
            this.colStItem});
            this.gridStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.TabIndex = 2;
            //
            // colStCustomer
            //
            this.colStCustomer.HeaderText = "고객사";
            this.colStCustomer.Name = "colStCustomer";
            this.colStCustomer.Width = 110;
            //
            // colStSite
            //
            this.colStSite.HeaderText = "사이트/라인";
            this.colStSite.Name = "colStSite";
            this.colStSite.Width = 150;
            //
            // colStEquipment
            //
            this.colStEquipment.HeaderText = "설비";
            this.colStEquipment.Name = "colStEquipment";
            this.colStEquipment.Width = 150;
            //
            // colStProgram
            //
            this.colStProgram.HeaderText = "프로그램";
            this.colStProgram.Name = "colStProgram";
            this.colStProgram.Width = 130;
            //
            // colStVersion
            //
            this.colStVersion.HeaderText = "설치 버전";
            this.colStVersion.Name = "colStVersion";
            this.colStVersion.Width = 90;
            //
            // colStLatest
            //
            this.colStLatest.HeaderText = "최신 버전";
            this.colStLatest.Name = "colStLatest";
            this.colStLatest.Width = 90;
            //
            // colStState
            //
            this.colStState.HeaderText = "상태";
            this.colStState.Name = "colStState";
            this.colStState.Width = 120;
            //
            // colStDeployedAt
            //
            this.colStDeployedAt.HeaderText = "설치 일시";
            this.colStDeployedAt.Name = "colStDeployedAt";
            this.colStDeployedAt.Width = 140;
            //
            // colStItem
            //
            this.colStItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colStItem.HeaderText = "관련 업무";
            this.colStItem.Name = "colStItem";
            //
            // split
            //
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.split.Size = new System.Drawing.Size(1180, 540);
            this.split.SplitterDistance = 480;
            this.split.SplitterWidth = 3;
            this.split.TabIndex = 3;
            this.split.Visible = false;
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
            this.lblDeployTitle.Size = new System.Drawing.Size(673, 36);
            this.lblDeployTitle.TabIndex = 1;
            this.lblDeployTitle.Text = "설치 이력  (더블클릭: 고치기 · 오른쪽 클릭: 되돌림·삭제)";
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
            this.txtDetail.Size = new System.Drawing.Size(673, 220);
            this.txtDetail.TabIndex = 0;
            //
            // gridPrograms
            //
            this.gridPrograms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPgName,
            this.colPgLatest,
            this.colPgSites,
            this.colPgState,
            this.colPgCode,
            this.colPgRemote});
            this.gridPrograms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPrograms.Name = "gridPrograms";
            this.gridPrograms.TabIndex = 4;
            this.gridPrograms.Visible = false;
            this.gridPrograms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPrograms_CellDoubleClick);
            //
            // colPgName
            //
            this.colPgName.HeaderText = "프로그램";
            this.colPgName.Name = "colPgName";
            this.colPgName.Width = 140;
            //
            // colPgLatest
            //
            this.colPgLatest.HeaderText = "최신 버전";
            this.colPgLatest.Name = "colPgLatest";
            this.colPgLatest.Width = 90;
            //
            // colPgSites
            //
            this.colPgSites.HeaderText = "설치 위치";
            this.colPgSites.Name = "colPgSites";
            this.colPgSites.Width = 90;
            //
            // colPgState
            //
            this.colPgState.HeaderText = "코드 상태";
            this.colPgState.Name = "colPgState";
            this.colPgState.Width = 230;
            //
            // colPgCode
            //
            this.colPgCode.HeaderText = "코드 폴더";
            this.colPgCode.Name = "colPgCode";
            this.colPgCode.Width = 320;
            //
            // colPgRemote
            //
            this.colPgRemote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPgRemote.HeaderText = "NAS 코드 백업";
            this.colPgRemote.Name = "colPgRemote";
            //
            // lblHelp
            //
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblHelp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(1180, 44);
            this.lblHelp.TabIndex = 5;
            this.lblHelp.Text = "도움말";
            this.lblHelp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // ReleasesPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.gridStatus);
            this.Controls.Add(this.split);
            this.Controls.Add(this.gridPrograms);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.flpView);
            this.Controls.Add(this.flpActions);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "ReleasesPage";
            this.Size = new System.Drawing.Size(1180, 700);
            this.flpActions.ResumeLayout(false);
            this.flpView.ResumeLayout(false);
            this.flpView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).EndInit();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReleases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDeploy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrograms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpActions;
        private TSWorkBench.Theme.DarkButton btnRegister;
        private TSWorkBench.Theme.DarkButton btnNewRelease;
        private TSWorkBench.Theme.DarkButton btnDeploy;
        private TSWorkBench.Theme.DarkButton btnImport;
        private TSWorkBench.Theme.DarkButton btnBackup;
        private TSWorkBench.Theme.DarkButton btnStore;
        private System.Windows.Forms.FlowLayoutPanel flpView;
        private TSWorkBench.Theme.NavButton viewStatus;
        private TSWorkBench.Theme.NavButton viewVersions;
        private TSWorkBench.Theme.NavButton viewPrograms;
        private System.Windows.Forms.Label lblProgram;
        private TSWorkBench.Theme.DarkComboBox cboProgram;
        private TSWorkBench.Theme.DarkGrid gridStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStProgram;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStLatest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStDeployedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStItem;
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
        private TSWorkBench.Theme.DarkGrid gridPrograms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPgName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPgLatest;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPgSites;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPgState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPgCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPgRemote;
        private System.Windows.Forms.Label lblHelp;
    }
}
