namespace TSWorkBench.Forms
{
    partial class ProgramSetupDialog
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
            this.lblHint = new System.Windows.Forms.Label();
            this.tbl = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.pnlCode = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnCode = new TSWorkBench.Theme.DarkButton();
            this.lblBuild = new System.Windows.Forms.Label();
            this.pnlBuild = new System.Windows.Forms.Panel();
            this.txtBuild = new System.Windows.Forms.TextBox();
            this.btnBuild = new TSWorkBench.Theme.DarkButton();
            this.lblManual = new System.Windows.Forms.Label();
            this.pnlManual = new System.Windows.Forms.Panel();
            this.txtManual = new System.Windows.Forms.TextBox();
            this.btnManual = new TSWorkBench.Theme.DarkButton();
            this.lblRemote = new System.Windows.Forms.Label();
            this.pnlRemote = new System.Windows.Forms.Panel();
            this.txtRemote = new System.Windows.Forms.TextBox();
            this.btnRemote = new TSWorkBench.Theme.DarkButton();
            this.lblBase = new System.Windows.Forms.Label();
            this.flpBase = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBaseVersion = new System.Windows.Forms.TextBox();
            this.lblBaseDate = new System.Windows.Forms.Label();
            this.dateBase = new TSWorkBench.Theme.DateBox();
            this.lblSites = new System.Windows.Forms.Label();
            this.gridSites = new TSWorkBench.Theme.DarkGrid();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new TSWorkBench.Theme.DarkButton();
            this.btnOk = new TSWorkBench.Theme.DarkButton();
            this.tbl.SuspendLayout();
            this.pnlCode.SuspendLayout();
            this.pnlBuild.SuspendLayout();
            this.pnlManual.SuspendLayout();
            this.pnlRemote.SuspendLayout();
            this.flpBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSites)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // lblHint
            //
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(860, 64);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "코드가 들어 있는 폴더(.sln이 있는 곳)를 고르면 Git 저장소 만들기 · 기준 버전 기록 · NAS 코드 백업을 TS WorkBench가 대신 합니다.\r\n이미 Git인 폴더면 있는 버전 이름표(v1.0.0 …)를 그대로 불러옵니다. 등록한 뒤에는 VS2022에서 커밋만 하면 됩니다.";
            //
            // tbl
            //
            this.tbl.ColumnCount = 2;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Controls.Add(this.lblName, 0, 0);
            this.tbl.Controls.Add(this.txtName, 1, 0);
            this.tbl.Controls.Add(this.lblCode, 0, 1);
            this.tbl.Controls.Add(this.pnlCode, 1, 1);
            this.tbl.Controls.Add(this.lblBuild, 0, 2);
            this.tbl.Controls.Add(this.pnlBuild, 1, 2);
            this.tbl.Controls.Add(this.lblManual, 0, 3);
            this.tbl.Controls.Add(this.pnlManual, 1, 3);
            this.tbl.Controls.Add(this.lblRemote, 0, 4);
            this.tbl.Controls.Add(this.pnlRemote, 1, 4);
            this.tbl.Controls.Add(this.lblBase, 0, 5);
            this.tbl.Controls.Add(this.flpBase, 1, 5);
            this.tbl.Controls.Add(this.lblSites, 0, 6);
            this.tbl.Controls.Add(this.gridSites, 1, 6);
            this.tbl.Controls.Add(this.lblLog, 0, 7);
            this.tbl.Controls.Add(this.txtLog, 1, 7);
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 8;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tbl.TabIndex = 0;
            //
            // lblName
            //
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblName.Name = "lblName";
            this.lblName.Text = "프로그램 이름 *";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtName
            //
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtName.Name = "txtName";
            this.txtName.TabIndex = 0;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            //
            // lblCode
            //
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCode.Name = "lblCode";
            this.lblCode.Text = "코드 폴더 *";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlCode
            //
            this.pnlCode.Controls.Add(this.txtCode);
            this.pnlCode.Controls.Add(this.btnCode);
            this.pnlCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCode.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlCode.Name = "pnlCode";
            this.pnlCode.TabIndex = 1;
            //
            // txtCode
            //
            this.txtCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCode.Name = "txtCode";
            this.txtCode.TabIndex = 0;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            //
            // btnCode
            //
            this.btnCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCode.Name = "btnCode";
            this.btnCode.Size = new System.Drawing.Size(96, 28);
            this.btnCode.TabIndex = 1;
            this.btnCode.Text = "찾아보기";
            this.btnCode.Click += new System.EventHandler(this.btnCode_Click);
            //
            // lblBuild
            //
            this.lblBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Text = "빌드 결과 폴더";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlBuild
            //
            this.pnlBuild.Controls.Add(this.txtBuild);
            this.pnlBuild.Controls.Add(this.btnBuild);
            this.pnlBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuild.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlBuild.Name = "pnlBuild";
            this.pnlBuild.TabIndex = 2;
            //
            // txtBuild
            //
            this.txtBuild.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtBuild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtBuild.Name = "txtBuild";
            this.txtBuild.TabIndex = 0;
            //
            // btnBuild
            //
            this.btnBuild.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(96, 28);
            this.btnBuild.TabIndex = 1;
            this.btnBuild.Text = "찾아보기";
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            //
            // lblManual
            //
            this.lblManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblManual.Name = "lblManual";
            this.lblManual.Text = "매뉴얼 폴더";
            this.lblManual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlManual
            //
            this.pnlManual.Controls.Add(this.txtManual);
            this.pnlManual.Controls.Add(this.btnManual);
            this.pnlManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlManual.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlManual.Name = "pnlManual";
            this.pnlManual.TabIndex = 3;
            //
            // txtManual
            //
            this.txtManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtManual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtManual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtManual.Name = "txtManual";
            this.txtManual.TabIndex = 0;
            //
            // btnManual
            //
            this.btnManual.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(96, 28);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "찾아보기";
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            //
            // lblRemote
            //
            this.lblRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRemote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblRemote.Name = "lblRemote";
            this.lblRemote.Text = "NAS 코드 백업";
            this.lblRemote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlRemote
            //
            this.pnlRemote.Controls.Add(this.txtRemote);
            this.pnlRemote.Controls.Add(this.btnRemote);
            this.pnlRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRemote.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlRemote.Name = "pnlRemote";
            this.pnlRemote.TabIndex = 4;
            //
            // txtRemote
            //
            this.txtRemote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtRemote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtRemote.Name = "txtRemote";
            this.txtRemote.TabIndex = 0;
            //
            // btnRemote
            //
            this.btnRemote.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnRemote.Name = "btnRemote";
            this.btnRemote.Size = new System.Drawing.Size(96, 28);
            this.btnRemote.TabIndex = 1;
            this.btnRemote.Text = "찾아보기";
            this.btnRemote.Click += new System.EventHandler(this.btnRemote_Click);
            //
            // lblBase
            //
            this.lblBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBase.Name = "lblBase";
            this.lblBase.Text = "기준 버전";
            this.lblBase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // flpBase
            //
            this.flpBase.Controls.Add(this.txtBaseVersion);
            this.flpBase.Controls.Add(this.lblBaseDate);
            this.flpBase.Controls.Add(this.dateBase);
            this.flpBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBase.Margin = new System.Windows.Forms.Padding(0);
            this.flpBase.Name = "flpBase";
            this.flpBase.TabIndex = 5;
            this.flpBase.WrapContents = false;
            //
            // txtBaseVersion
            //
            this.txtBaseVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtBaseVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBaseVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtBaseVersion.Margin = new System.Windows.Forms.Padding(3, 7, 16, 0);
            this.txtBaseVersion.Name = "txtBaseVersion";
            this.txtBaseVersion.Size = new System.Drawing.Size(90, 25);
            this.txtBaseVersion.TabIndex = 0;
            this.txtBaseVersion.Text = "1.0.0";
            //
            // lblBaseDate
            //
            this.lblBaseDate.AutoSize = true;
            this.lblBaseDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBaseDate.Margin = new System.Windows.Forms.Padding(0, 11, 6, 0);
            this.lblBaseDate.Name = "lblBaseDate";
            this.lblBaseDate.Text = "기준본 날짜 (설치일)";
            //
            // dateBase
            //
            this.dateBase.Margin = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.dateBase.Name = "dateBase";
            this.dateBase.Size = new System.Drawing.Size(150, 25);
            this.dateBase.TabIndex = 1;
            //
            // lblSites
            //
            this.lblSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSites.Name = "lblSites";
            this.lblSites.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblSites.Text = "지금 이 버전을\r\n쓰는 곳\r\n(맨 아래 줄에\r\n입력하면 추가)";
            //
            // gridSites
            //
            this.gridSites.AllowUserToAddRows = true;
            this.gridSites.AllowUserToDeleteRows = true;
            this.gridSites.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCustomer,
            this.colSite,
            this.colEquipment});
            this.gridSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSites.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridSites.Name = "gridSites";
            this.gridSites.ReadOnly = false;
            this.gridSites.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridSites.TabIndex = 6;
            //
            // colCustomer
            //
            this.colCustomer.HeaderText = "고객사";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.Width = 180;
            //
            // colSite
            //
            this.colSite.HeaderText = "사이트/라인";
            this.colSite.Name = "colSite";
            this.colSite.Width = 220;
            //
            // colEquipment
            //
            this.colEquipment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colEquipment.HeaderText = "설비";
            this.colEquipment.Name = "colEquipment";
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
            // flpButtons
            //
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(860, 58);
            this.flpButtons.TabIndex = 1;
            //
            // btnClose
            //
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 38);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "닫기";
            //
            // btnOk
            //
            this.btnOk.Accent = true;
            this.btnOk.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(170, 38);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "등록 시작";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // ProgramSetupDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(900, 780);
            this.Controls.Add(this.tbl);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lblHint);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 700);
            this.Name = "ProgramSetupDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "① 프로그램 등록";
            this.tbl.ResumeLayout(false);
            this.tbl.PerformLayout();
            this.pnlCode.ResumeLayout(false);
            this.pnlCode.PerformLayout();
            this.pnlBuild.ResumeLayout(false);
            this.pnlBuild.PerformLayout();
            this.pnlManual.ResumeLayout(false);
            this.pnlManual.PerformLayout();
            this.pnlRemote.ResumeLayout(false);
            this.pnlRemote.PerformLayout();
            this.flpBase.ResumeLayout(false);
            this.flpBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSites)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Panel pnlCode;
        private System.Windows.Forms.TextBox txtCode;
        private TSWorkBench.Theme.DarkButton btnCode;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.Panel pnlBuild;
        private System.Windows.Forms.TextBox txtBuild;
        private TSWorkBench.Theme.DarkButton btnBuild;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.TextBox txtManual;
        private TSWorkBench.Theme.DarkButton btnManual;
        private System.Windows.Forms.Label lblRemote;
        private System.Windows.Forms.Panel pnlRemote;
        private System.Windows.Forms.TextBox txtRemote;
        private TSWorkBench.Theme.DarkButton btnRemote;
        private System.Windows.Forms.Label lblBase;
        private System.Windows.Forms.FlowLayoutPanel flpBase;
        private System.Windows.Forms.TextBox txtBaseVersion;
        private System.Windows.Forms.Label lblBaseDate;
        private TSWorkBench.Theme.DateBox dateBase;
        private System.Windows.Forms.Label lblSites;
        private TSWorkBench.Theme.DarkGrid gridSites;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private TSWorkBench.Theme.DarkButton btnClose;
        private TSWorkBench.Theme.DarkButton btnOk;
    }
}
