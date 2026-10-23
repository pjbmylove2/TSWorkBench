namespace TSWorkBench.Forms
{
    partial class NewReleaseDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHint = new System.Windows.Forms.Label();
            this.tbl = new System.Windows.Forms.TableLayoutPanel();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cboProgram = new TSWorkBench.Theme.DarkComboBox();
            this.lblStateCap = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.flpStep = new System.Windows.Forms.FlowLayoutPanel();
            this.rbPatch = new System.Windows.Forms.RadioButton();
            this.rbMinor = new System.Windows.Forms.RadioButton();
            this.rbMajor = new System.Windows.Forms.RadioButton();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblWorkItems = new System.Windows.Forms.Label();
            this.txtWorkItems = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblSites = new System.Windows.Forms.Label();
            this.pnlSites = new System.Windows.Forms.Panel();
            this.clbSites = new System.Windows.Forms.CheckedListBox();
            this.flpAddSite = new System.Windows.Forms.FlowLayoutPanel();
            this.cboCustomer = new TSWorkBench.Theme.DarkComboBox();
            this.cboSite = new TSWorkBench.Theme.DarkComboBox();
            this.cboEquipment = new TSWorkBench.Theme.DarkComboBox();
            this.btnAddSite = new TSWorkBench.Theme.DarkButton();
            this.lblDeployedAt = new System.Windows.Forms.Label();
            this.dateDeployedAt = new TSWorkBench.Theme.DateBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.prgStep = new System.Windows.Forms.ProgressBar();
            this.elapsedTimer = new System.Windows.Forms.Timer(this.components);
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new TSWorkBench.Theme.DarkButton();
            this.btnOk = new TSWorkBench.Theme.DarkButton();
            this.btnRefresh = new TSWorkBench.Theme.DarkButton();
            this.tbl.SuspendLayout();
            this.flpStep.SuspendLayout();
            this.pnlSites.SuspendLayout();
            this.flpAddSite.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // lblHint
            //
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(880, 48);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "순서: VS2022에서 커밋 → Release 빌드 → 여기서 '배포 만들기'. 이름표 붙이기·배포본 보관·업무 카드 기록·NAS 백업을 한 번에 합니다.";
            //
            // tbl
            //
            this.tbl.ColumnCount = 2;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Controls.Add(this.lblProgram, 0, 0);
            this.tbl.Controls.Add(this.cboProgram, 1, 0);
            this.tbl.Controls.Add(this.lblStateCap, 0, 1);
            this.tbl.Controls.Add(this.lblState, 1, 1);
            this.tbl.Controls.Add(this.lblStep, 0, 2);
            this.tbl.Controls.Add(this.flpStep, 1, 2);
            this.tbl.Controls.Add(this.lblVersion, 0, 3);
            this.tbl.Controls.Add(this.txtVersion, 1, 3);
            this.tbl.Controls.Add(this.lblWorkItems, 0, 4);
            this.tbl.Controls.Add(this.txtWorkItems, 1, 4);
            this.tbl.Controls.Add(this.lblNotes, 0, 5);
            this.tbl.Controls.Add(this.txtNotes, 1, 5);
            this.tbl.Controls.Add(this.lblSites, 0, 6);
            this.tbl.Controls.Add(this.pnlSites, 1, 6);
            this.tbl.Controls.Add(this.lblDeployedAt, 0, 7);
            this.tbl.Controls.Add(this.dateDeployedAt, 1, 7);
            this.tbl.Controls.Add(this.lblLog, 0, 8);
            this.tbl.Controls.Add(this.pnlLog, 1, 8);
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 9;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbl.TabIndex = 0;
            //
            // lblProgram
            //
            this.lblProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Text = "프로그램";
            this.lblProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboProgram
            //
            this.cboProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboProgram.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgram.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.TabIndex = 0;
            this.cboProgram.SelectedIndexChanged += new System.EventHandler(this.cboProgram_SelectedIndexChanged);
            //
            // lblStateCap
            //
            this.lblStateCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStateCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStateCap.Name = "lblStateCap";
            this.lblStateCap.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblStateCap.Text = "지금 상태";
            //
            // lblState
            //
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Name = "lblState";
            this.lblState.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblState.Text = "-";
            //
            // lblStep
            //
            this.lblStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStep.Name = "lblStep";
            this.lblStep.Text = "무엇을 바꿨나";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // flpStep
            //
            this.flpStep.Controls.Add(this.rbPatch);
            this.flpStep.Controls.Add(this.rbMinor);
            this.flpStep.Controls.Add(this.rbMajor);
            this.flpStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpStep.Margin = new System.Windows.Forms.Padding(0);
            this.flpStep.Name = "flpStep";
            this.flpStep.TabIndex = 1;
            this.flpStep.WrapContents = false;
            //
            // rbPatch
            //
            this.rbPatch.AutoSize = true;
            this.rbPatch.Margin = new System.Windows.Forms.Padding(3, 9, 20, 0);
            this.rbPatch.Name = "rbPatch";
            this.rbPatch.TabIndex = 0;
            this.rbPatch.Text = "버그 수정";
            this.rbPatch.CheckedChanged += new System.EventHandler(this.step_CheckedChanged);
            //
            // rbMinor
            //
            this.rbMinor.AutoSize = true;
            this.rbMinor.Checked = true;
            this.rbMinor.Margin = new System.Windows.Forms.Padding(3, 9, 20, 0);
            this.rbMinor.Name = "rbMinor";
            this.rbMinor.TabIndex = 1;
            this.rbMinor.TabStop = true;
            this.rbMinor.Text = "기능 추가";
            this.rbMinor.CheckedChanged += new System.EventHandler(this.step_CheckedChanged);
            //
            // rbMajor
            //
            this.rbMajor.AutoSize = true;
            this.rbMajor.Margin = new System.Windows.Forms.Padding(3, 9, 0, 0);
            this.rbMajor.Name = "rbMajor";
            this.rbMajor.TabIndex = 2;
            this.rbMajor.Text = "큰 변경 (설정·통신 형식 바뀜)";
            this.rbMajor.CheckedChanged += new System.EventHandler(this.step_CheckedChanged);
            //
            // lblVersion
            //
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Text = "새 버전";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtVersion
            //
            this.txtVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtVersion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(140, 27);
            this.txtVersion.TabIndex = 2;
            //
            // lblWorkItems
            //
            this.lblWorkItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblWorkItems.Name = "lblWorkItems";
            this.lblWorkItems.Text = "관련 업무 ID";
            this.lblWorkItems.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtWorkItems
            //
            this.txtWorkItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtWorkItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorkItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtWorkItems.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtWorkItems.Name = "txtWorkItems";
            this.txtWorkItems.TabIndex = 3;
            //
            // lblNotes
            //
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblNotes.Text = "변경 내역\r\n(커밋 메시지에서\r\n자동으로 채움)";
            //
            // txtNotes
            //
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.TabIndex = 4;
            //
            // lblSites
            //
            this.lblSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSites.Name = "lblSites";
            this.lblSites.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblSites.Text = "이번에 설치한 곳\r\n(체크)";
            //
            // pnlSites
            //
            this.pnlSites.Controls.Add(this.clbSites);
            this.pnlSites.Controls.Add(this.flpAddSite);
            this.pnlSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSites.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.pnlSites.Name = "pnlSites";
            this.pnlSites.TabIndex = 5;
            //
            // clbSites
            //
            this.clbSites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.clbSites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbSites.CheckOnClick = true;
            this.clbSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbSites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.clbSites.IntegralHeight = false;
            this.clbSites.Name = "clbSites";
            this.clbSites.TabIndex = 0;
            //
            // flpAddSite
            //
            this.flpAddSite.Controls.Add(this.cboCustomer);
            this.flpAddSite.Controls.Add(this.cboSite);
            this.flpAddSite.Controls.Add(this.cboEquipment);
            this.flpAddSite.Controls.Add(this.btnAddSite);
            this.flpAddSite.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpAddSite.Name = "flpAddSite";
            this.flpAddSite.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.flpAddSite.Size = new System.Drawing.Size(700, 42);
            this.flpAddSite.TabIndex = 1;
            this.flpAddSite.WrapContents = false;
            //
            // cboCustomer
            //
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(150, 25);
            this.cboCustomer.TabIndex = 0;
            //
            // cboSite
            //
            this.cboSite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSite.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(170, 25);
            this.cboSite.TabIndex = 1;
            //
            // cboEquipment
            //
            this.cboEquipment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEquipment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEquipment.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.cboEquipment.Name = "cboEquipment";
            this.cboEquipment.Size = new System.Drawing.Size(170, 25);
            this.cboEquipment.TabIndex = 2;
            //
            // btnAddSite
            //
            this.btnAddSite.Margin = new System.Windows.Forms.Padding(0, -2, 0, 0);
            this.btnAddSite.Name = "btnAddSite";
            this.btnAddSite.Size = new System.Drawing.Size(120, 30);
            this.btnAddSite.TabIndex = 3;
            this.btnAddSite.Text = "+ 위치 추가";
            this.btnAddSite.Click += new System.EventHandler(this.btnAddSite_Click);
            //
            // lblDeployedAt
            //
            this.lblDeployedAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeployedAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDeployedAt.Name = "lblDeployedAt";
            this.lblDeployedAt.Text = "설치 일시";
            this.lblDeployedAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dateDeployedAt
            //
            this.dateDeployedAt.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.dateDeployedAt.Name = "dateDeployedAt";
            this.dateDeployedAt.ShowTime = true;
            this.dateDeployedAt.Size = new System.Drawing.Size(190, 25);
            this.dateDeployedAt.TabIndex = 6;
            //
            // lblLog
            //
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblLog.Name = "lblLog";
            this.lblLog.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblLog.Text = "진행 상황";
            //
            // txtLog
            //
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtLog.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.TabIndex = 7;
            //
            // pnlLog
            //
            this.pnlLog.Controls.Add(this.txtLog);
            this.pnlLog.Controls.Add(this.pnlProgress);
            this.pnlLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLog.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.TabIndex = 7;
            //
            // pnlProgress
            //
            this.pnlProgress.Controls.Add(this.prgStep);
            this.pnlProgress.Controls.Add(this.lblCurrent);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlProgress.Size = new System.Drawing.Size(700, 46);
            this.pnlProgress.TabIndex = 0;
            this.pnlProgress.Visible = false;
            //
            // lblCurrent
            //
            this.lblCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCurrent.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(700, 24);
            this.lblCurrent.Text = "현재 작업";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // prgStep
            //
            this.prgStep.Dock = System.Windows.Forms.DockStyle.Top;
            this.prgStep.MarqueeAnimationSpeed = 30;
            this.prgStep.Name = "prgStep";
            this.prgStep.Size = new System.Drawing.Size(700, 12);
            this.prgStep.TabIndex = 0;
            //
            // elapsedTimer
            //
            this.elapsedTimer.Interval = 1000;
            this.elapsedTimer.Tick += new System.EventHandler(this.elapsedTimer_Tick);
            //
            // flpButtons
            //
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Controls.Add(this.btnRefresh);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(880, 58);
            this.flpButtons.TabIndex = 1;
            //
            // btnClose
            //
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "닫기";
            //
            // btnOk
            //
            this.btnOk.Accent = true;
            this.btnOk.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(170, 38);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "배포 만들기";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 38);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "상태 다시 읽기";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // NewReleaseDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(920, 860);
            this.Controls.Add(this.tbl);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lblHint);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(880, 760);
            this.Name = "NewReleaseDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "② 새 버전 배포";
            this.tbl.ResumeLayout(false);
            this.tbl.PerformLayout();
            this.flpStep.ResumeLayout(false);
            this.flpStep.PerformLayout();
            this.pnlSites.ResumeLayout(false);
            this.flpAddSite.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlLog.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Label lblProgram;
        private TSWorkBench.Theme.DarkComboBox cboProgram;
        private System.Windows.Forms.Label lblStateCap;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.FlowLayoutPanel flpStep;
        private System.Windows.Forms.RadioButton rbPatch;
        private System.Windows.Forms.RadioButton rbMinor;
        private System.Windows.Forms.RadioButton rbMajor;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblWorkItems;
        private System.Windows.Forms.TextBox txtWorkItems;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblSites;
        private System.Windows.Forms.Panel pnlSites;
        private System.Windows.Forms.CheckedListBox clbSites;
        private System.Windows.Forms.FlowLayoutPanel flpAddSite;
        private TSWorkBench.Theme.DarkComboBox cboCustomer;
        private TSWorkBench.Theme.DarkComboBox cboSite;
        private TSWorkBench.Theme.DarkComboBox cboEquipment;
        private TSWorkBench.Theme.DarkButton btnAddSite;
        private System.Windows.Forms.Label lblDeployedAt;
        private TSWorkBench.Theme.DateBox dateDeployedAt;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.ProgressBar prgStep;
        private System.Windows.Forms.Timer elapsedTimer;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private TSWorkBench.Theme.DarkButton btnClose;
        private TSWorkBench.Theme.DarkButton btnOk;
        private TSWorkBench.Theme.DarkButton btnRefresh;
    }
}
