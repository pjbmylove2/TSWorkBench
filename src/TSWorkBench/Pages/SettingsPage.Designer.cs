namespace TSWorkBench.Pages
{
    partial class SettingsPage
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
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.lblTemplatesHint = new System.Windows.Forms.Label();
            this.lblReleaseStore = new System.Windows.Forms.Label();
            this.txtReleaseStore = new System.Windows.Forms.TextBox();
            this.btnReleaseStore = new TSWorkBench.Theme.DarkButton();
            this.lblBackupFolder = new System.Windows.Forms.Label();
            this.txtBackupFolder = new System.Windows.Forms.TextBox();
            this.btnBackupFolder = new TSWorkBench.Theme.DarkButton();
            this.lblBackupKeep = new System.Windows.Forms.Label();
            this.numBackupKeep = new System.Windows.Forms.NumericUpDown();
            this.btnBackupNow = new TSWorkBench.Theme.DarkButton();
            this.btnOpenTemplates = new TSWorkBench.Theme.DarkButton();
            this.btnSaveSettings = new TSWorkBench.Theme.DarkButton();
            this.numFollowUp = new System.Windows.Forms.NumericUpDown();
            this.lblFollowUp = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnOpenData = new TSWorkBench.Theme.DarkButton();
            this.btnChangeFolder = new TSWorkBench.Theme.DarkButton();
            this.txtDataFolder = new System.Windows.Forms.TextBox();
            this.lblDataFolder = new System.Windows.Forms.Label();
            this.lblSecGeneral = new System.Windows.Forms.Label();
            this.tblRight = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMasters = new System.Windows.Forms.Panel();
            this.gridMasters = new TSWorkBench.Theme.DarkGrid();
            this.colMasterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMasterKeywords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMastersTop = new System.Windows.Forms.Panel();
            this.cboMasterKind = new TSWorkBench.Theme.DarkComboBox();
            this.lblSecMasters = new System.Windows.Forms.Label();
            this.btnSaveMasters = new TSWorkBench.Theme.DarkButton();
            this.pnlChecklist = new System.Windows.Forms.Panel();
            this.txtChecklist = new System.Windows.Forms.TextBox();
            this.pnlChecklistTop = new System.Windows.Forms.Panel();
            this.cboChecklistType = new TSWorkBench.Theme.DarkComboBox();
            this.lblSecChecklist = new System.Windows.Forms.Label();
            this.btnSaveChecklist = new TSWorkBench.Theme.DarkButton();
            this.pnlGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFollowUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBackupKeep)).BeginInit();
            this.tblRight.SuspendLayout();
            this.pnlMasters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMasters)).BeginInit();
            this.pnlMastersTop.SuspendLayout();
            this.pnlChecklist.SuspendLayout();
            this.pnlChecklistTop.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlGeneral
            //
            this.pnlGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlGeneral.Controls.Add(this.lblTemplatesHint);
            this.pnlGeneral.Controls.Add(this.lblReleaseStore);
            this.pnlGeneral.Controls.Add(this.txtReleaseStore);
            this.pnlGeneral.Controls.Add(this.btnReleaseStore);
            this.pnlGeneral.Controls.Add(this.lblBackupFolder);
            this.pnlGeneral.Controls.Add(this.txtBackupFolder);
            this.pnlGeneral.Controls.Add(this.btnBackupFolder);
            this.pnlGeneral.Controls.Add(this.lblBackupKeep);
            this.pnlGeneral.Controls.Add(this.numBackupKeep);
            this.pnlGeneral.Controls.Add(this.btnBackupNow);
            this.pnlGeneral.Controls.Add(this.btnOpenTemplates);
            this.pnlGeneral.Controls.Add(this.btnSaveSettings);
            this.pnlGeneral.Controls.Add(this.numFollowUp);
            this.pnlGeneral.Controls.Add(this.lblFollowUp);
            this.pnlGeneral.Controls.Add(this.txtPrefix);
            this.pnlGeneral.Controls.Add(this.lblPrefix);
            this.pnlGeneral.Controls.Add(this.txtCompany);
            this.pnlGeneral.Controls.Add(this.lblCompany);
            this.pnlGeneral.Controls.Add(this.txtDepartment);
            this.pnlGeneral.Controls.Add(this.lblDepartment);
            this.pnlGeneral.Controls.Add(this.txtUser);
            this.pnlGeneral.Controls.Add(this.lblUser);
            this.pnlGeneral.Controls.Add(this.btnOpenData);
            this.pnlGeneral.Controls.Add(this.btnChangeFolder);
            this.pnlGeneral.Controls.Add(this.txtDataFolder);
            this.pnlGeneral.Controls.Add(this.lblDataFolder);
            this.pnlGeneral.Controls.Add(this.lblSecGeneral);
            this.pnlGeneral.AutoScroll = true;
            this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(390, 650);
            this.pnlGeneral.TabIndex = 0;
            //
            // lblSecGeneral
            //
            this.lblSecGeneral.AutoSize = true;
            this.lblSecGeneral.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSecGeneral.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblSecGeneral.Location = new System.Drawing.Point(18, 16);
            this.lblSecGeneral.Name = "lblSecGeneral";
            this.lblSecGeneral.Text = "기본 정보";
            //
            // lblDataFolder
            //
            this.lblDataFolder.AutoSize = true;
            this.lblDataFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDataFolder.Location = new System.Drawing.Point(18, 56);
            this.lblDataFolder.Name = "lblDataFolder";
            this.lblDataFolder.Text = "데이터 폴더 (통째로 복사하면 이전 끝)";
            //
            // txtDataFolder
            //
            this.txtDataFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtDataFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtDataFolder.Location = new System.Drawing.Point(18, 78);
            this.txtDataFolder.Name = "txtDataFolder";
            this.txtDataFolder.ReadOnly = true;
            this.txtDataFolder.Size = new System.Drawing.Size(352, 25);
            this.txtDataFolder.TabIndex = 0;
            //
            // btnChangeFolder
            //
            this.btnChangeFolder.Location = new System.Drawing.Point(18, 110);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(120, 30);
            this.btnChangeFolder.TabIndex = 1;
            this.btnChangeFolder.Text = "다른 폴더 열기…";
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            //
            // btnOpenData
            //
            this.btnOpenData.Location = new System.Drawing.Point(146, 110);
            this.btnOpenData.Name = "btnOpenData";
            this.btnOpenData.Size = new System.Drawing.Size(120, 30);
            this.btnOpenData.TabIndex = 2;
            this.btnOpenData.Text = "탐색기로 열기";
            this.btnOpenData.Click += new System.EventHandler(this.btnOpenData_Click);
            //
            // lblUser
            //
            this.lblUser.AutoSize = true;
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblUser.Location = new System.Drawing.Point(18, 160);
            this.lblUser.Name = "lblUser";
            this.lblUser.Text = "이름 (보고서 작성자)";
            //
            // txtUser
            //
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtUser.Location = new System.Drawing.Point(18, 182);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(352, 25);
            this.txtUser.TabIndex = 3;
            //
            // lblDepartment
            //
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDepartment.Location = new System.Drawing.Point(18, 218);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Text = "부서";
            //
            // txtDepartment
            //
            this.txtDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtDepartment.Location = new System.Drawing.Point(18, 240);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.Size = new System.Drawing.Size(352, 25);
            this.txtDepartment.TabIndex = 4;
            //
            // lblCompany
            //
            this.lblCompany.AutoSize = true;
            this.lblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCompany.Location = new System.Drawing.Point(18, 276);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Text = "회사";
            //
            // txtCompany
            //
            this.txtCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCompany.Location = new System.Drawing.Point(18, 298);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(352, 25);
            this.txtCompany.TabIndex = 5;
            //
            // lblPrefix
            //
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPrefix.Location = new System.Drawing.Point(18, 334);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Text = "업무 ID 앞머리 (예: TS → TS-2026-10-0001)";
            //
            // txtPrefix
            //
            this.txtPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtPrefix.Location = new System.Drawing.Point(18, 356);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(120, 25);
            this.txtPrefix.TabIndex = 6;
            //
            // lblFollowUp
            //
            this.lblFollowUp.AutoSize = true;
            this.lblFollowUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblFollowUp.Location = new System.Drawing.Point(18, 392);
            this.lblFollowUp.Name = "lblFollowUp";
            this.lblFollowUp.Text = "완료 후 모니터링 업무 기한 (일, 0 = 만들지 않음)";
            //
            // numFollowUp
            //
            this.numFollowUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.numFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numFollowUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.numFollowUp.Location = new System.Drawing.Point(18, 414);
            this.numFollowUp.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numFollowUp.Name = "numFollowUp";
            this.numFollowUp.Size = new System.Drawing.Size(80, 25);
            this.numFollowUp.TabIndex = 7;
            //
            // lblReleaseStore
            //
            this.lblReleaseStore.AutoSize = true;
            this.lblReleaseStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblReleaseStore.Location = new System.Drawing.Point(18, 452);
            this.lblReleaseStore.Name = "lblReleaseStore";
            this.lblReleaseStore.Text = "배포본 보관소 (공유 폴더, 예: \\\\NAS\\Releases)";
            //
            // txtReleaseStore
            //
            this.txtReleaseStore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtReleaseStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReleaseStore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtReleaseStore.Location = new System.Drawing.Point(18, 474);
            this.txtReleaseStore.Name = "txtReleaseStore";
            this.txtReleaseStore.Size = new System.Drawing.Size(256, 25);
            this.txtReleaseStore.TabIndex = 8;
            //
            // btnReleaseStore
            //
            this.btnReleaseStore.Location = new System.Drawing.Point(282, 472);
            this.btnReleaseStore.Name = "btnReleaseStore";
            this.btnReleaseStore.Size = new System.Drawing.Size(88, 29);
            this.btnReleaseStore.TabIndex = 9;
            this.btnReleaseStore.Text = "찾아보기";
            this.btnReleaseStore.Click += new System.EventHandler(this.btnReleaseStore_Click);
            //
            // lblBackupFolder
            //
            this.lblBackupFolder.AutoSize = true;
            this.lblBackupFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBackupFolder.Location = new System.Drawing.Point(18, 512);
            this.lblBackupFolder.Name = "lblBackupFolder";
            this.lblBackupFolder.Text = "자동 백업 폴더 (비우면 데이터 폴더\\Backups)";
            //
            // txtBackupFolder
            //
            this.txtBackupFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtBackupFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackupFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtBackupFolder.Location = new System.Drawing.Point(18, 534);
            this.txtBackupFolder.Name = "txtBackupFolder";
            this.txtBackupFolder.Size = new System.Drawing.Size(256, 25);
            this.txtBackupFolder.TabIndex = 10;
            //
            // btnBackupFolder
            //
            this.btnBackupFolder.Location = new System.Drawing.Point(282, 532);
            this.btnBackupFolder.Name = "btnBackupFolder";
            this.btnBackupFolder.Size = new System.Drawing.Size(88, 29);
            this.btnBackupFolder.TabIndex = 11;
            this.btnBackupFolder.Text = "찾아보기";
            this.btnBackupFolder.Click += new System.EventHandler(this.btnBackupFolder_Click);
            //
            // lblBackupKeep
            //
            this.lblBackupKeep.AutoSize = true;
            this.lblBackupKeep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBackupKeep.Location = new System.Drawing.Point(18, 572);
            this.lblBackupKeep.Name = "lblBackupKeep";
            this.lblBackupKeep.Text = "백업 보관 개수 (하루 1개, 0 = 지우지 않음)";
            //
            // numBackupKeep
            //
            this.numBackupKeep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.numBackupKeep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numBackupKeep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.numBackupKeep.Location = new System.Drawing.Point(18, 594);
            this.numBackupKeep.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.numBackupKeep.Name = "numBackupKeep";
            this.numBackupKeep.Size = new System.Drawing.Size(80, 25);
            this.numBackupKeep.TabIndex = 12;
            //
            // btnBackupNow
            //
            this.btnBackupNow.Location = new System.Drawing.Point(110, 592);
            this.btnBackupNow.Name = "btnBackupNow";
            this.btnBackupNow.Size = new System.Drawing.Size(120, 29);
            this.btnBackupNow.TabIndex = 13;
            this.btnBackupNow.Text = "지금 백업";
            this.btnBackupNow.Click += new System.EventHandler(this.btnBackupNow_Click);
            //
            // btnSaveSettings
            //
            this.btnSaveSettings.Accent = true;
            this.btnSaveSettings.Location = new System.Drawing.Point(18, 636);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(120, 36);
            this.btnSaveSettings.TabIndex = 8;
            this.btnSaveSettings.Text = "기본 정보 저장";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            //
            // btnOpenTemplates
            //
            this.btnOpenTemplates.Location = new System.Drawing.Point(18, 696);
            this.btnOpenTemplates.Name = "btnOpenTemplates";
            this.btnOpenTemplates.Size = new System.Drawing.Size(200, 32);
            this.btnOpenTemplates.TabIndex = 9;
            this.btnOpenTemplates.Text = "보고서 템플릿 폴더 열기";
            this.btnOpenTemplates.Click += new System.EventHandler(this.btnOpenTemplates_Click);
            //
            // lblTemplatesHint
            //
            this.lblTemplatesHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTemplatesHint.Location = new System.Drawing.Point(18, 734);
            this.lblTemplatesHint.Name = "lblTemplatesHint";
            this.lblTemplatesHint.Size = new System.Drawing.Size(352, 64);
            this.lblTemplatesHint.Text = "메모장으로 html·md 파일을 고치면 회사·고객 양식에 맞출 수 있습니다. 파일을 지우면 다음 실행 때 기본 템플릿이 다시 생깁니다.";
            //
            // tblRight
            //
            this.tblRight.ColumnCount = 2;
            this.tblRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tblRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblRight.Controls.Add(this.pnlMasters, 0, 0);
            this.tblRight.Controls.Add(this.pnlChecklist, 1, 0);
            this.tblRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblRight.Location = new System.Drawing.Point(390, 0);
            this.tblRight.Name = "tblRight";
            this.tblRight.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.tblRight.RowCount = 1;
            this.tblRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblRight.Size = new System.Drawing.Size(710, 650);
            this.tblRight.TabIndex = 1;
            //
            // pnlMasters
            //
            this.pnlMasters.Controls.Add(this.gridMasters);
            this.pnlMasters.Controls.Add(this.pnlMastersTop);
            this.pnlMasters.Controls.Add(this.btnSaveMasters);
            this.pnlMasters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMasters.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.pnlMasters.Name = "pnlMasters";
            this.pnlMasters.TabIndex = 0;
            //
            // gridMasters
            //
            this.gridMasters.AllowUserToAddRows = true;
            this.gridMasters.AllowUserToDeleteRows = true;
            this.gridMasters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMasterName,
            this.colMasterKeywords});
            this.gridMasters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMasters.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridMasters.Name = "gridMasters";
            this.gridMasters.ReadOnly = false;
            this.gridMasters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridMasters.TabIndex = 1;
            //
            // colMasterName
            //
            this.colMasterName.HeaderText = "이름";
            this.colMasterName.Name = "colMasterName";
            this.colMasterName.Width = 160;
            //
            // colMasterKeywords
            //
            this.colMasterKeywords.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colMasterKeywords.HeaderText = "별칭·폴더 이름 키워드 (쉼표 구분)";
            this.colMasterKeywords.Name = "colMasterKeywords";
            //
            // pnlMastersTop
            //
            this.pnlMastersTop.Controls.Add(this.cboMasterKind);
            this.pnlMastersTop.Controls.Add(this.lblSecMasters);
            this.pnlMastersTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMastersTop.Name = "pnlMastersTop";
            this.pnlMastersTop.Size = new System.Drawing.Size(380, 84);
            this.pnlMastersTop.TabIndex = 0;
            //
            // lblSecMasters
            //
            this.lblSecMasters.AutoSize = true;
            this.lblSecMasters.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSecMasters.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblSecMasters.Location = new System.Drawing.Point(0, 16);
            this.lblSecMasters.Name = "lblSecMasters";
            this.lblSecMasters.Text = "기준 정보 (입력 목록 · 가져오기 자동 인식)";
            //
            // cboMasterKind
            //
            this.cboMasterKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboMasterKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMasterKind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMasterKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboMasterKind.Items.AddRange(new object[] {
            "고객사",
            "사이트 / 라인",
            "설비",
            "대상 시스템",
            "프로그램 (배포용)"});
            this.cboMasterKind.Location = new System.Drawing.Point(0, 50);
            this.cboMasterKind.Name = "cboMasterKind";
            this.cboMasterKind.Size = new System.Drawing.Size(180, 25);
            this.cboMasterKind.TabIndex = 0;
            this.cboMasterKind.SelectedIndexChanged += new System.EventHandler(this.cboMasterKind_SelectedIndexChanged);
            //
            // btnSaveMasters
            //
            this.btnSaveMasters.Accent = true;
            this.btnSaveMasters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveMasters.Name = "btnSaveMasters";
            this.btnSaveMasters.Size = new System.Drawing.Size(380, 36);
            this.btnSaveMasters.TabIndex = 2;
            this.btnSaveMasters.Text = "기준 정보 저장";
            this.btnSaveMasters.Click += new System.EventHandler(this.btnSaveMasters_Click);
            //
            // pnlChecklist
            //
            this.pnlChecklist.Controls.Add(this.txtChecklist);
            this.pnlChecklist.Controls.Add(this.pnlChecklistTop);
            this.pnlChecklist.Controls.Add(this.btnSaveChecklist);
            this.pnlChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChecklist.Margin = new System.Windows.Forms.Padding(0);
            this.pnlChecklist.Name = "pnlChecklist";
            this.pnlChecklist.TabIndex = 1;
            //
            // txtChecklist
            //
            this.txtChecklist.AcceptsReturn = true;
            this.txtChecklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtChecklist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChecklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtChecklist.Multiline = true;
            this.txtChecklist.Name = "txtChecklist";
            this.txtChecklist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChecklist.TabIndex = 1;
            //
            // pnlChecklistTop
            //
            this.pnlChecklistTop.Controls.Add(this.cboChecklistType);
            this.pnlChecklistTop.Controls.Add(this.lblSecChecklist);
            this.pnlChecklistTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlChecklistTop.Name = "pnlChecklistTop";
            this.pnlChecklistTop.Size = new System.Drawing.Size(300, 84);
            this.pnlChecklistTop.TabIndex = 0;
            //
            // lblSecChecklist
            //
            this.lblSecChecklist.AutoSize = true;
            this.lblSecChecklist.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSecChecklist.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblSecChecklist.Location = new System.Drawing.Point(0, 16);
            this.lblSecChecklist.Name = "lblSecChecklist";
            this.lblSecChecklist.Text = "유형별 체크리스트 (한 줄 = 한 항목)";
            //
            // cboChecklistType
            //
            this.cboChecklistType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboChecklistType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChecklistType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChecklistType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboChecklistType.Location = new System.Drawing.Point(0, 50);
            this.cboChecklistType.Name = "cboChecklistType";
            this.cboChecklistType.Size = new System.Drawing.Size(180, 25);
            this.cboChecklistType.TabIndex = 0;
            this.cboChecklistType.SelectedIndexChanged += new System.EventHandler(this.cboChecklistType_SelectedIndexChanged);
            //
            // btnSaveChecklist
            //
            this.btnSaveChecklist.Accent = true;
            this.btnSaveChecklist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveChecklist.Name = "btnSaveChecklist";
            this.btnSaveChecklist.Size = new System.Drawing.Size(300, 36);
            this.btnSaveChecklist.TabIndex = 2;
            this.btnSaveChecklist.Text = "이 유형 체크리스트 저장";
            this.btnSaveChecklist.Click += new System.EventHandler(this.btnSaveChecklist_Click);
            //
            // SettingsPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tblRight);
            this.Controls.Add(this.pnlGeneral);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlGeneral.ResumeLayout(false);
            this.pnlGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFollowUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBackupKeep)).EndInit();
            this.tblRight.ResumeLayout(false);
            this.pnlMasters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMasters)).EndInit();
            this.pnlMastersTop.ResumeLayout(false);
            this.pnlMastersTop.PerformLayout();
            this.pnlChecklist.ResumeLayout(false);
            this.pnlChecklist.PerformLayout();
            this.pnlChecklistTop.ResumeLayout(false);
            this.pnlChecklistTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.Label lblSecGeneral;
        private System.Windows.Forms.Label lblDataFolder;
        private System.Windows.Forms.TextBox txtDataFolder;
        private TSWorkBench.Theme.DarkButton btnChangeFolder;
        private TSWorkBench.Theme.DarkButton btnOpenData;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblPrefix;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblFollowUp;
        private System.Windows.Forms.NumericUpDown numFollowUp;
        private TSWorkBench.Theme.DarkButton btnSaveSettings;
        private TSWorkBench.Theme.DarkButton btnOpenTemplates;
        private System.Windows.Forms.Label lblTemplatesHint;
        private System.Windows.Forms.Label lblReleaseStore;
        private System.Windows.Forms.TextBox txtReleaseStore;
        private TSWorkBench.Theme.DarkButton btnReleaseStore;
        private System.Windows.Forms.Label lblBackupFolder;
        private System.Windows.Forms.TextBox txtBackupFolder;
        private TSWorkBench.Theme.DarkButton btnBackupFolder;
        private System.Windows.Forms.Label lblBackupKeep;
        private System.Windows.Forms.NumericUpDown numBackupKeep;
        private TSWorkBench.Theme.DarkButton btnBackupNow;
        private System.Windows.Forms.TableLayoutPanel tblRight;
        private System.Windows.Forms.Panel pnlMasters;
        private TSWorkBench.Theme.DarkGrid gridMasters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMasterKeywords;
        private System.Windows.Forms.Panel pnlMastersTop;
        private TSWorkBench.Theme.DarkComboBox cboMasterKind;
        private System.Windows.Forms.Label lblSecMasters;
        private TSWorkBench.Theme.DarkButton btnSaveMasters;
        private System.Windows.Forms.Panel pnlChecklist;
        private System.Windows.Forms.TextBox txtChecklist;
        private System.Windows.Forms.Panel pnlChecklistTop;
        private TSWorkBench.Theme.DarkComboBox cboChecklistType;
        private System.Windows.Forms.Label lblSecChecklist;
        private TSWorkBench.Theme.DarkButton btnSaveChecklist;
    }
}
