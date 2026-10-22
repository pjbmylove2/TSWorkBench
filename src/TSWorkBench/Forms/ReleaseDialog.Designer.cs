namespace TSWorkBench.Forms
{
    partial class ReleaseDialog
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
            this.tbl = new System.Windows.Forms.TableLayoutPanel();
            this.flpMode = new System.Windows.Forms.FlowLayoutPanel();
            this.rbPackage = new System.Windows.Forms.RadioButton();
            this.rbRegister = new System.Windows.Forms.RadioButton();
            this.lblProgram = new System.Windows.Forms.Label();
            this.cboProgram = new TSWorkBench.Theme.DarkComboBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblTag = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.lblCommit = new System.Windows.Forms.Label();
            this.txtCommit = new System.Windows.Forms.TextBox();
            this.lblBuild = new System.Windows.Forms.Label();
            this.pnlBuild = new System.Windows.Forms.Panel();
            this.txtBuild = new System.Windows.Forms.TextBox();
            this.btnBuild = new TSWorkBench.Theme.DarkButton();
            this.lblManual = new System.Windows.Forms.Label();
            this.pnlManual = new System.Windows.Forms.Panel();
            this.txtManual = new System.Windows.Forms.TextBox();
            this.btnManual = new TSWorkBench.Theme.DarkButton();
            this.lblPackage = new System.Windows.Forms.Label();
            this.pnlPackage = new System.Windows.Forms.Panel();
            this.txtPackage = new System.Windows.Forms.TextBox();
            this.btnPackage = new TSWorkBench.Theme.DarkButton();
            this.lblWorkItems = new System.Windows.Forms.Label();
            this.txtWorkItems = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new TSWorkBench.Theme.DarkButton();
            this.btnOk = new TSWorkBench.Theme.DarkButton();
            this.tbl.SuspendLayout();
            this.flpMode.SuspendLayout();
            this.pnlBuild.SuspendLayout();
            this.pnlManual.SuspendLayout();
            this.pnlPackage.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tbl
            //
            this.tbl.ColumnCount = 2;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Controls.Add(this.flpMode, 0, 0);
            this.tbl.Controls.Add(this.lblProgram, 0, 1);
            this.tbl.Controls.Add(this.cboProgram, 1, 1);
            this.tbl.Controls.Add(this.lblVersion, 0, 2);
            this.tbl.Controls.Add(this.txtVersion, 1, 2);
            this.tbl.Controls.Add(this.lblTag, 0, 3);
            this.tbl.Controls.Add(this.txtTag, 1, 3);
            this.tbl.Controls.Add(this.lblCommit, 0, 4);
            this.tbl.Controls.Add(this.txtCommit, 1, 4);
            this.tbl.Controls.Add(this.lblBuild, 0, 5);
            this.tbl.Controls.Add(this.pnlBuild, 1, 5);
            this.tbl.Controls.Add(this.lblManual, 0, 6);
            this.tbl.Controls.Add(this.pnlManual, 1, 6);
            this.tbl.Controls.Add(this.lblPackage, 0, 7);
            this.tbl.Controls.Add(this.pnlPackage, 1, 7);
            this.tbl.Controls.Add(this.lblWorkItems, 0, 8);
            this.tbl.Controls.Add(this.txtWorkItems, 1, 8);
            this.tbl.Controls.Add(this.lblNotes, 0, 9);
            this.tbl.Controls.Add(this.txtNotes, 1, 9);
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Location = new System.Drawing.Point(20, 16);
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 10;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Size = new System.Drawing.Size(760, 540);
            this.tbl.TabIndex = 0;
            //
            // flpMode
            //
            this.tbl.SetColumnSpan(this.flpMode, 2);
            this.flpMode.Controls.Add(this.rbPackage);
            this.flpMode.Controls.Add(this.rbRegister);
            this.flpMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMode.Name = "flpMode";
            this.flpMode.TabIndex = 0;
            //
            // rbPackage
            //
            this.rbPackage.AutoSize = true;
            this.rbPackage.Checked = true;
            this.rbPackage.Margin = new System.Windows.Forms.Padding(0, 8, 24, 0);
            this.rbPackage.Name = "rbPackage";
            this.rbPackage.TabIndex = 0;
            this.rbPackage.TabStop = true;
            this.rbPackage.Text = "빌드 폴더로 배포 패키지 만들기 (보관소에 새 버전 폴더 생성)";
            this.rbPackage.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            //
            // rbRegister
            //
            this.rbRegister.AutoSize = true;
            this.rbRegister.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.rbRegister.Name = "rbRegister";
            this.rbRegister.TabIndex = 1;
            this.rbRegister.Text = "이미 있는 배포본 등록만";
            this.rbRegister.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            //
            // lblProgram
            //
            this.lblProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProgram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblProgram.Name = "lblProgram";
            this.lblProgram.Text = "프로그램 *";
            this.lblProgram.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboProgram
            //
            this.cboProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboProgram.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cboProgram.Name = "cboProgram";
            this.cboProgram.TabIndex = 1;
            //
            // lblVersion
            //
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Text = "버전 * (예: 2.4.2)";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtVersion
            //
            this.txtVersion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtVersion.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.TabIndex = 2;
            this.txtVersion.TextChanged += new System.EventHandler(this.txtVersion_TextChanged);
            //
            // lblTag
            //
            this.lblTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTag.Name = "lblTag";
            this.lblTag.Text = "Git 태그";
            this.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTag
            //
            this.txtTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtTag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtTag.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtTag.Name = "txtTag";
            this.txtTag.TabIndex = 3;
            //
            // lblCommit
            //
            this.lblCommit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCommit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCommit.Name = "lblCommit";
            this.lblCommit.Text = "커밋 (선택)";
            this.lblCommit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtCommit
            //
            this.txtCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCommit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCommit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCommit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCommit.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtCommit.Name = "txtCommit";
            this.txtCommit.TabIndex = 4;
            //
            // lblBuild
            //
            this.lblBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBuild.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Text = "빌드 폴더 *";
            this.lblBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlBuild
            //
            this.pnlBuild.Controls.Add(this.txtBuild);
            this.pnlBuild.Controls.Add(this.btnBuild);
            this.pnlBuild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBuild.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlBuild.Name = "pnlBuild";
            this.pnlBuild.TabIndex = 5;
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
            this.pnlManual.TabIndex = 6;
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
            // lblPackage
            //
            this.lblPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPackage.Name = "lblPackage";
            this.lblPackage.Text = "배포본 폴더 *";
            this.lblPackage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlPackage
            //
            this.pnlPackage.Controls.Add(this.txtPackage);
            this.pnlPackage.Controls.Add(this.btnPackage);
            this.pnlPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPackage.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnlPackage.Name = "pnlPackage";
            this.pnlPackage.TabIndex = 7;
            //
            // txtPackage
            //
            this.txtPackage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPackage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtPackage.Name = "txtPackage";
            this.txtPackage.TabIndex = 0;
            //
            // btnPackage
            //
            this.btnPackage.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPackage.Name = "btnPackage";
            this.btnPackage.Size = new System.Drawing.Size(96, 28);
            this.btnPackage.TabIndex = 1;
            this.btnPackage.Text = "찾아보기";
            this.btnPackage.Click += new System.EventHandler(this.btnPackage_Click);
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
            this.txtWorkItems.TabIndex = 8;
            //
            // lblNotes
            //
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblNotes.Text = "변경 내역\r\n(배포 노트)";
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
            this.txtNotes.TabIndex = 9;
            //
            // lblHint
            //
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Location = new System.Drawing.Point(20, 16);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(760, 44);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "보관소";
            //
            // flpButtons
            //
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(760, 58);
            this.flpButtons.TabIndex = 1;
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            //
            // btnOk
            //
            this.btnOk.Accent = true;
            this.btnOk.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(180, 38);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "패키지 만들기";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // ReleaseDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 680);
            this.Controls.Add(this.tbl);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lblHint);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 600);
            this.Name = "ReleaseDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "배포본 등록";
            this.tbl.ResumeLayout(false);
            this.tbl.PerformLayout();
            this.flpMode.ResumeLayout(false);
            this.flpMode.PerformLayout();
            this.pnlBuild.ResumeLayout(false);
            this.pnlBuild.PerformLayout();
            this.pnlManual.ResumeLayout(false);
            this.pnlManual.PerformLayout();
            this.pnlPackage.ResumeLayout(false);
            this.pnlPackage.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.FlowLayoutPanel flpMode;
        private System.Windows.Forms.RadioButton rbPackage;
        private System.Windows.Forms.RadioButton rbRegister;
        private System.Windows.Forms.Label lblProgram;
        private TSWorkBench.Theme.DarkComboBox cboProgram;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Label lblCommit;
        private System.Windows.Forms.TextBox txtCommit;
        private System.Windows.Forms.Label lblBuild;
        private System.Windows.Forms.Panel pnlBuild;
        private System.Windows.Forms.TextBox txtBuild;
        private TSWorkBench.Theme.DarkButton btnBuild;
        private System.Windows.Forms.Label lblManual;
        private System.Windows.Forms.Panel pnlManual;
        private System.Windows.Forms.TextBox txtManual;
        private TSWorkBench.Theme.DarkButton btnManual;
        private System.Windows.Forms.Label lblPackage;
        private System.Windows.Forms.Panel pnlPackage;
        private System.Windows.Forms.TextBox txtPackage;
        private TSWorkBench.Theme.DarkButton btnPackage;
        private System.Windows.Forms.Label lblWorkItems;
        private System.Windows.Forms.TextBox txtWorkItems;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private TSWorkBench.Theme.DarkButton btnCancel;
        private TSWorkBench.Theme.DarkButton btnOk;
    }
}
