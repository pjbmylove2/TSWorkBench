namespace TSWorkBench.Pages
{
    partial class HelpPage
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
            this.btnFolder = new TSWorkBench.Theme.DarkButton();
            this.lblHint = new System.Windows.Forms.Label();
            this.split = new System.Windows.Forms.SplitContainer();
            this.gridToc = new TSWorkBench.Theme.DarkGrid();
            this.colTopic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCount = new System.Windows.Forms.Label();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridToc)).BeginInit();
            this.SuspendLayout();
            //
            // pnlSearch
            //
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.btnFolder);
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
            this.lblSearch.Text = "도움말 찾기";
            //
            // txtSearch
            //
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0, 6, 12, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(340, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // btnFolder
            //
            this.btnFolder.Margin = new System.Windows.Forms.Padding(0, 4, 16, 0);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(150, 32);
            this.btnFolder.TabIndex = 1;
            this.btnFolder.Text = "도움말 폴더 열기";
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            //
            // lblHint
            //
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.lblHint.Name = "lblHint";
            this.lblHint.Text = "어느 화면에서든 F1 = 그 화면 설명 · 띄어쓰기로 여러 단어 · 본문에서 Ctrl+F";
            //
            // split
            //
            this.split.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.split.Location = new System.Drawing.Point(0, 50);
            this.split.Name = "split";
            //
            // split.Panel1
            //
            this.split.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.split.Panel1.Controls.Add(this.gridToc);
            this.split.Panel1.Controls.Add(this.lblCount);
            //
            // split.Panel2
            //
            this.split.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.split.Panel2.Controls.Add(this.browser);
            this.split.Size = new System.Drawing.Size(1100, 600);
            this.split.SplitterDistance = 340;
            this.split.SplitterWidth = 3;
            this.split.TabIndex = 1;
            //
            // gridToc
            //
            this.gridToc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTopic});
            this.gridToc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridToc.Name = "gridToc";
            this.gridToc.TabIndex = 0;
            this.gridToc.SelectionChanged += new System.EventHandler(this.gridToc_SelectionChanged);
            //
            // colTopic
            //
            this.colTopic.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTopic.HeaderText = "목차";
            this.colTopic.Name = "colTopic";
            //
            // lblCount
            //
            this.lblCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(340, 28);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // browser
            //
            this.browser.AllowWebBrowserDrop = false;
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Name = "browser";
            this.browser.ScriptErrorsSuppressed = true;
            this.browser.TabIndex = 0;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            this.browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browser_Navigating);
            //
            // searchTimer
            //
            this.searchTimer.Interval = 300;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            //
            // HelpPage
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.split);
            this.Controls.Add(this.pnlSearch);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.Name = "HelpPage";
            this.Size = new System.Drawing.Size(1100, 650);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridToc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private TSWorkBench.Theme.DarkButton btnFolder;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.SplitContainer split;
        private TSWorkBench.Theme.DarkGrid gridToc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTopic;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Timer searchTimer;
    }
}
