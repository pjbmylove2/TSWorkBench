namespace TSWorkBench.Pages
{
    partial class DashboardPage
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
            this.flpTiles = new System.Windows.Forms.FlowLayoutPanel();
            this.tileActive = new TSWorkBench.Theme.StatTile();
            this.tileOverdue = new TSWorkBench.Theme.StatTile();
            this.tileDue7 = new TSWorkBench.Theme.StatTile();
            this.tileFollowUp = new TSWorkBench.Theme.StatTile();
            this.tileDoneMonth = new TSWorkBench.Theme.StatTile();
            this.tblLists = new System.Windows.Forms.TableLayoutPanel();
            this.lblTodo = new System.Windows.Forms.Label();
            this.lblRecent = new System.Windows.Forms.Label();
            this.gridTodo = new TSWorkBench.Theme.DarkGrid();
            this.colTodoDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodoStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodoPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodoLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTodoTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecent = new TSWorkBench.Theme.DarkGrid();
            this.colRecentDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecentTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpTiles.SuspendLayout();
            this.tblLists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).BeginInit();
            this.SuspendLayout();
            //
            // flpTiles
            //
            this.flpTiles.Controls.Add(this.tileActive);
            this.flpTiles.Controls.Add(this.tileOverdue);
            this.flpTiles.Controls.Add(this.tileDue7);
            this.flpTiles.Controls.Add(this.tileFollowUp);
            this.flpTiles.Controls.Add(this.tileDoneMonth);
            this.flpTiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTiles.Location = new System.Drawing.Point(0, 0);
            this.flpTiles.Name = "flpTiles";
            this.flpTiles.Size = new System.Drawing.Size(1100, 112);
            this.flpTiles.TabIndex = 0;
            this.flpTiles.WrapContents = false;
            //
            // tileActive
            //
            this.tileActive.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.tileActive.Caption = "진행 중";
            this.tileActive.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.tileActive.Name = "tileActive";
            this.tileActive.Size = new System.Drawing.Size(200, 92);
            this.tileActive.TabIndex = 0;
            this.tileActive.Click += new System.EventHandler(this.tileActive_Click);
            //
            // tileOverdue
            //
            this.tileOverdue.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.tileOverdue.Caption = "기한 지남";
            this.tileOverdue.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.tileOverdue.Name = "tileOverdue";
            this.tileOverdue.Size = new System.Drawing.Size(200, 92);
            this.tileOverdue.TabIndex = 1;
            this.tileOverdue.Click += new System.EventHandler(this.tileOverdue_Click);
            //
            // tileDue7
            //
            this.tileDue7.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.tileDue7.Caption = "7일 안에 기한";
            this.tileDue7.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.tileDue7.Name = "tileDue7";
            this.tileDue7.Size = new System.Drawing.Size(200, 92);
            this.tileDue7.TabIndex = 2;
            this.tileDue7.Click += new System.EventHandler(this.tileDue7_Click);
            //
            // tileFollowUp
            //
            this.tileFollowUp.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.tileFollowUp.Caption = "모니터링·후속";
            this.tileFollowUp.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.tileFollowUp.Name = "tileFollowUp";
            this.tileFollowUp.Size = new System.Drawing.Size(200, 92);
            this.tileFollowUp.TabIndex = 3;
            this.tileFollowUp.Click += new System.EventHandler(this.tileFollowUp_Click);
            //
            // tileDoneMonth
            //
            this.tileDoneMonth.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.tileDoneMonth.Caption = "이번 달 완료";
            this.tileDoneMonth.Margin = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.tileDoneMonth.Name = "tileDoneMonth";
            this.tileDoneMonth.Size = new System.Drawing.Size(200, 92);
            this.tileDoneMonth.TabIndex = 4;
            this.tileDoneMonth.Click += new System.EventHandler(this.tileDoneMonth_Click);
            //
            // tblLists
            //
            this.tblLists.ColumnCount = 2;
            this.tblLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tblLists.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tblLists.Controls.Add(this.lblTodo, 0, 0);
            this.tblLists.Controls.Add(this.lblRecent, 1, 0);
            this.tblLists.Controls.Add(this.gridTodo, 0, 1);
            this.tblLists.Controls.Add(this.gridRecent, 1, 1);
            this.tblLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLists.Location = new System.Drawing.Point(0, 112);
            this.tblLists.Name = "tblLists";
            this.tblLists.RowCount = 2;
            this.tblLists.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblLists.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLists.Size = new System.Drawing.Size(1100, 538);
            this.tblLists.TabIndex = 1;
            //
            // lblTodo
            //
            this.lblTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTodo.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTodo.Name = "lblTodo";
            this.lblTodo.Text = "해야 할 일 — 기한순  (빨강: 기한 지남 · 노랑: 2일 이내)";
            this.lblTodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblRecent
            //
            this.lblRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRecent.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblRecent.Margin = new System.Windows.Forms.Padding(14, 0, 3, 0);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Text = "최근 완료";
            this.lblRecent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // gridTodo
            //
            this.gridTodo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTodoDue,
            this.colTodoStatus,
            this.colTodoPriority,
            this.colTodoId,
            this.colTodoLocation,
            this.colTodoTitle});
            this.gridTodo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTodo.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.gridTodo.Name = "gridTodo";
            this.gridTodo.TabIndex = 0;
            this.gridTodo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            //
            // colTodoDue
            //
            this.colTodoDue.DataPropertyName = "DueDate";
            this.colTodoDue.HeaderText = "기한";
            this.colTodoDue.Name = "colTodoDue";
            this.colTodoDue.Width = 90;
            //
            // colTodoStatus
            //
            this.colTodoStatus.DataPropertyName = "Status";
            this.colTodoStatus.HeaderText = "상태";
            this.colTodoStatus.Name = "colTodoStatus";
            this.colTodoStatus.Width = 100;
            //
            // colTodoPriority
            //
            this.colTodoPriority.DataPropertyName = "Priority";
            this.colTodoPriority.HeaderText = "우선";
            this.colTodoPriority.Name = "colTodoPriority";
            this.colTodoPriority.Width = 50;
            //
            // colTodoId
            //
            this.colTodoId.DataPropertyName = "Id";
            this.colTodoId.HeaderText = "ID";
            this.colTodoId.Name = "colTodoId";
            this.colTodoId.Width = 105;
            //
            // colTodoLocation
            //
            this.colTodoLocation.DataPropertyName = "Location";
            this.colTodoLocation.HeaderText = "위치";
            this.colTodoLocation.Name = "colTodoLocation";
            this.colTodoLocation.Width = 150;
            //
            // colTodoTitle
            //
            this.colTodoTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTodoTitle.DataPropertyName = "Title";
            this.colTodoTitle.HeaderText = "제목";
            this.colTodoTitle.Name = "colTodoTitle";
            //
            // gridRecent
            //
            this.gridRecent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecentDone,
            this.colRecentId,
            this.colRecentLocation,
            this.colRecentTitle});
            this.gridRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRecent.Margin = new System.Windows.Forms.Padding(14, 3, 0, 3);
            this.gridRecent.Name = "gridRecent";
            this.gridRecent.TabIndex = 1;
            this.gridRecent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            //
            // colRecentDone
            //
            this.colRecentDone.DataPropertyName = "CompletedAt";
            this.colRecentDone.HeaderText = "완료일";
            this.colRecentDone.Name = "colRecentDone";
            this.colRecentDone.Width = 90;
            //
            // colRecentId
            //
            this.colRecentId.DataPropertyName = "Id";
            this.colRecentId.HeaderText = "ID";
            this.colRecentId.Name = "colRecentId";
            this.colRecentId.Width = 105;
            //
            // colRecentLocation
            //
            this.colRecentLocation.DataPropertyName = "Location";
            this.colRecentLocation.HeaderText = "위치";
            this.colRecentLocation.Name = "colRecentLocation";
            this.colRecentLocation.Width = 130;
            //
            // colRecentTitle
            //
            this.colRecentTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colRecentTitle.DataPropertyName = "Title";
            this.colRecentTitle.HeaderText = "제목";
            this.colRecentTitle.Name = "colRecentTitle";
            //
            // DashboardPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tblLists);
            this.Controls.Add(this.flpTiles);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "DashboardPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.flpTiles.ResumeLayout(false);
            this.tblLists.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRecent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTiles;
        private TSWorkBench.Theme.StatTile tileActive;
        private TSWorkBench.Theme.StatTile tileOverdue;
        private TSWorkBench.Theme.StatTile tileDue7;
        private TSWorkBench.Theme.StatTile tileFollowUp;
        private TSWorkBench.Theme.StatTile tileDoneMonth;
        private System.Windows.Forms.TableLayoutPanel tblLists;
        private System.Windows.Forms.Label lblTodo;
        private System.Windows.Forms.Label lblRecent;
        private TSWorkBench.Theme.DarkGrid gridTodo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTodoDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTodoStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTodoPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTodoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTodoLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTodoTitle;
        private TSWorkBench.Theme.DarkGrid gridRecent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentDone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecentTitle;
    }
}
