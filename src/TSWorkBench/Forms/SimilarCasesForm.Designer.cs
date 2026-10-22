namespace TSWorkBench.Forms
{
    partial class SimilarCasesForm
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
            this.split = new System.Windows.Forms.SplitContainer();
            this.grid = new TSWorkBench.Theme.DarkGrid();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblHint = new System.Windows.Forms.Label();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new TSWorkBench.Theme.DarkButton();
            this.btnUse = new TSWorkBench.Theme.DarkButton();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // split
            //
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(16, 16);
            this.split.Name = "split";
            //
            // split.Panel1
            //
            this.split.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.split.Panel1.Controls.Add(this.grid);
            //
            // split.Panel2
            //
            this.split.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.split.Panel2.Controls.Add(this.txtDetail);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(14, 10, 10, 10);
            this.split.Size = new System.Drawing.Size(1068, 560);
            this.split.SplitterDistance = 560;
            this.split.SplitterWidth = 3;
            this.split.TabIndex = 0;
            //
            // grid
            //
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStatus,
            this.colDone,
            this.colId,
            this.colEquipment,
            this.colTitle});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 0;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            //
            // colStatus
            //
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "상태";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 90;
            //
            // colDone
            //
            this.colDone.DataPropertyName = "CompletedAt";
            this.colDone.HeaderText = "완료일";
            this.colDone.Name = "colDone";
            this.colDone.Width = 90;
            //
            // colId
            //
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 120;
            //
            // colEquipment
            //
            this.colEquipment.DataPropertyName = "Equipment";
            this.colEquipment.HeaderText = "설비";
            this.colEquipment.Name = "colEquipment";
            this.colEquipment.Width = 90;
            //
            // colTitle
            //
            this.colTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "제목";
            this.colTitle.Name = "colTitle";
            //
            // txtDetail
            //
            this.txtDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.TabIndex = 0;
            //
            // pnlBottom
            //
            this.pnlBottom.Controls.Add(this.lblHint);
            this.pnlBottom.Controls.Add(this.flpButtons);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(16, 576);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1068, 56);
            this.pnlBottom.TabIndex = 1;
            //
            // lblHint
            //
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Name = "lblHint";
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "같은 설비·시스템·고객사, 겹치는 태그와 단어가 많은 순서입니다.";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // flpButtons
            //
            this.flpButtons.Controls.Add(this.btnClose);
            this.flpButtons.Controls.Add(this.btnUse);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(420, 56);
            this.flpButtons.TabIndex = 1;
            this.flpButtons.WrapContents = false;
            //
            // btnClose
            //
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "닫기";
            //
            // btnUse
            //
            this.btnUse.Accent = true;
            this.btnUse.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(230, 36);
            this.btnUse.TabIndex = 0;
            this.btnUse.Text = "원인 근거에 이 사례 추가";
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            //
            // SimilarCasesForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1100, 648);
            this.Controls.Add(this.split);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.MinimizeBox = false;
            this.Name = "SimilarCasesForm";
            this.Padding = new System.Windows.Forms.Padding(16, 16, 16, 0);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "유사 사례";
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer split;
        private TSWorkBench.Theme.DarkGrid grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private TSWorkBench.Theme.DarkButton btnClose;
        private TSWorkBench.Theme.DarkButton btnUse;
    }
}
