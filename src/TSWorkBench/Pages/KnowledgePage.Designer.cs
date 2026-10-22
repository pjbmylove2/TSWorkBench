namespace TSWorkBench.Pages
{
    partial class KnowledgePage
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
            this.pnlSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkIncludeActive = new System.Windows.Forms.CheckBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.split = new System.Windows.Forms.SplitContainer();
            this.grid = new TSWorkBench.Theme.DarkGrid();
            this.colDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.pnlDetailBottom = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpen = new TSWorkBench.Theme.DarkButton();
            this.lblCount = new System.Windows.Forms.Label();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.pnlDetailBottom.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlSearch
            //
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.chkIncludeActive);
            this.pnlSearch.Controls.Add(this.lblHint);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(1100, 50);
            this.pnlSearch.TabIndex = 0;
            this.pnlSearch.WrapContents = false;
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSearch.Margin = new System.Windows.Forms.Padding(0, 12, 6, 0);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Text = "증상 · 원인 · 설비 · 키워드";
            //
            // txtSearch
            //
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(420, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // chkIncludeActive
            //
            this.chkIncludeActive.AutoSize = true;
            this.chkIncludeActive.Margin = new System.Windows.Forms.Padding(0, 11, 16, 0);
            this.chkIncludeActive.Name = "chkIncludeActive";
            this.chkIncludeActive.TabIndex = 1;
            this.chkIncludeActive.Text = "진행 중 업무도 포함";
            this.chkIncludeActive.CheckedChanged += new System.EventHandler(this.chkIncludeActive_CheckedChanged);
            //
            // lblHint
            //
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "띄어쓰기로 여러 단어를 넣으면 모두 들어 있는 사례만 찾습니다";
            //
            // split
            //
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 50);
            this.split.Name = "split";
            //
            // split.Panel1
            //
            this.split.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.split.Panel1.Controls.Add(this.grid);
            this.split.Panel1.Controls.Add(this.lblCount);
            //
            // split.Panel2
            //
            this.split.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.split.Panel2.Controls.Add(this.txtDetail);
            this.split.Panel2.Controls.Add(this.pnlDetailBottom);
            this.split.Panel2.Padding = new System.Windows.Forms.Padding(14, 10, 10, 10);
            this.split.Size = new System.Drawing.Size(1100, 600);
            this.split.SplitterDistance = 560;
            this.split.SplitterWidth = 3;
            this.split.TabIndex = 1;
            //
            // grid
            //
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDone,
            this.colId,
            this.colEquipment,
            this.colSystem,
            this.colTitle});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Name = "grid";
            this.grid.TabIndex = 0;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
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
            this.colId.Width = 105;
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
            // pnlDetailBottom
            //
            this.pnlDetailBottom.Controls.Add(this.btnOpen);
            this.pnlDetailBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetailBottom.Name = "pnlDetailBottom";
            this.pnlDetailBottom.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlDetailBottom.Size = new System.Drawing.Size(500, 50);
            this.pnlDetailBottom.TabIndex = 1;
            //
            // btnOpen
            //
            this.btnOpen.Accent = true;
            this.btnOpen.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(140, 34);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "업무 카드 열기";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            //
            // lblCount
            //
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(560, 28);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0건";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // searchTimer
            //
            this.searchTimer.Interval = 300;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            //
            // KnowledgePage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.split);
            this.Controls.Add(this.pnlSearch);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "KnowledgePage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            this.split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.pnlDetailBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkIncludeActive;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.SplitContainer split;
        private TSWorkBench.Theme.DarkGrid grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.FlowLayoutPanel pnlDetailBottom;
        private TSWorkBench.Theme.DarkButton btnOpen;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Timer searchTimer;
    }
}
