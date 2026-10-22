namespace TSWorkBench.Forms
{
    partial class ImportVersionsDialog
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
            this.flpTools = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddZip = new TSWorkBench.Theme.DarkButton();
            this.btnAddFolder = new TSWorkBench.Theme.DarkButton();
            this.btnRemove = new TSWorkBench.Theme.DarkButton();
            this.lblState = new System.Windows.Forms.Label();
            this.grid = new TSWorkBench.Theme.DarkGrid();
            this.colSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWorkItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new TSWorkBench.Theme.DarkButton();
            this.btnOk = new TSWorkBench.Theme.DarkButton();
            this.flpTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // lblHint
            //
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(980, 66);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "예전처럼 버전마다 따로 보관한 zip·폴더(예: 20231213_LineScan_현장적용본.zip)를 날짜 순서대로 코드 폴더에 덮어쓰며 Git 기록으로 남깁니다.\r\n원본은 건드리지 않습니다. 날짜·버전·업무 ID·메모는 표에서 고칠 수 있고, 업무 ID를 넣으면 그 업무 카드에 커밋이 연결됩니다.";
            //
            // flpTools
            //
            this.flpTools.Controls.Add(this.btnAddZip);
            this.flpTools.Controls.Add(this.btnAddFolder);
            this.flpTools.Controls.Add(this.btnRemove);
            this.flpTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTools.Name = "flpTools";
            this.flpTools.Size = new System.Drawing.Size(980, 46);
            this.flpTools.TabIndex = 1;
            this.flpTools.WrapContents = false;
            //
            // btnAddZip
            //
            this.btnAddZip.Accent = true;
            this.btnAddZip.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAddZip.Name = "btnAddZip";
            this.btnAddZip.Size = new System.Drawing.Size(150, 36);
            this.btnAddZip.TabIndex = 0;
            this.btnAddZip.Text = "zip 파일 추가";
            this.btnAddZip.Click += new System.EventHandler(this.btnAddZip_Click);
            //
            // btnAddFolder
            //
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(150, 36);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "버전 폴더 추가";
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            //
            // btnRemove
            //
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(120, 36);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "선택 줄 빼기";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            //
            // lblState
            //
            this.lblState.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblState.Size = new System.Drawing.Size(980, 48);
            this.lblState.TabIndex = 5;
            this.lblState.Name = "lblState";
            this.lblState.Text = "-";
            //
            // grid
            //
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSource,
            this.colDate,
            this.colVersion,
            this.colWorkItem,
            this.colNote});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Name = "grid";
            this.grid.ReadOnly = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grid.TabIndex = 2;
            //
            // colSource
            //
            this.colSource.HeaderText = "원본 (zip·폴더)";
            this.colSource.Name = "colSource";
            this.colSource.ReadOnly = true;
            this.colSource.Width = 330;
            //
            // colDate
            //
            this.colDate.HeaderText = "날짜 ✎";
            this.colDate.Name = "colDate";
            this.colDate.Width = 110;
            //
            // colVersion
            //
            this.colVersion.HeaderText = "버전 ✎";
            this.colVersion.Name = "colVersion";
            this.colVersion.Width = 90;
            //
            // colWorkItem
            //
            this.colWorkItem.HeaderText = "업무 ID ✎";
            this.colWorkItem.Name = "colWorkItem";
            this.colWorkItem.Width = 150;
            //
            // colNote
            //
            this.colNote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNote.HeaderText = "메모 (커밋 메시지) ✎";
            this.colNote.Name = "colNote";
            //
            // txtLog
            //
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(980, 130);
            this.txtLog.TabIndex = 3;
            //
            // flpButtons
            //
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(980, 58);
            this.flpButtons.TabIndex = 4;
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
            this.btnOk.Text = "가져오기 시작";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // ImportVersionsDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.flpButtons);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.flpTools);
            this.Controls.Add(this.lblHint);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(980, 640);
            this.Name = "ImportVersionsDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "과거 버전 가져오기";
            this.flpTools.ResumeLayout(false);
            this.flpTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.FlowLayoutPanel flpTools;
        private TSWorkBench.Theme.DarkButton btnAddZip;
        private TSWorkBench.Theme.DarkButton btnAddFolder;
        private TSWorkBench.Theme.DarkButton btnRemove;
        private System.Windows.Forms.Label lblState;
        private TSWorkBench.Theme.DarkGrid grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWorkItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private TSWorkBench.Theme.DarkButton btnClose;
        private TSWorkBench.Theme.DarkButton btnOk;
    }
}
