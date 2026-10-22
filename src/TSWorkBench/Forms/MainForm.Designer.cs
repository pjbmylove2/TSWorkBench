namespace TSWorkBench.Forms
{
    partial class MainForm
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
            this.pnlNav = new System.Windows.Forms.Panel();
            this.navSettings = new TSWorkBench.Theme.NavButton();
            this.navImport = new TSWorkBench.Theme.NavButton();
            this.navReleases = new TSWorkBench.Theme.NavButton();
            this.navReports = new TSWorkBench.Theme.NavButton();
            this.navKnowledge = new TSWorkBench.Theme.NavButton();
            this.navPlanned = new TSWorkBench.Theme.NavButton();
            this.navList = new TSWorkBench.Theme.NavButton();
            this.navDashboard = new TSWorkBench.Theme.NavButton();
            this.pnlNavBottom = new System.Windows.Forms.Panel();
            this.lblWorkspace = new System.Windows.Forms.Label();
            this.btnQuickAdd = new TSWorkBench.Theme.DarkButton();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnNewItem = new TSWorkBench.Theme.DarkButton();
            this.lblPageSubtitle = new System.Windows.Forms.Label();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlNav.SuspendLayout();
            this.pnlNavBottom.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlNav
            //
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlNav.Controls.Add(this.navSettings);
            this.pnlNav.Controls.Add(this.navImport);
            this.pnlNav.Controls.Add(this.navReleases);
            this.pnlNav.Controls.Add(this.navReports);
            this.pnlNav.Controls.Add(this.navKnowledge);
            this.pnlNav.Controls.Add(this.navPlanned);
            this.pnlNav.Controls.Add(this.navList);
            this.pnlNav.Controls.Add(this.navDashboard);
            this.pnlNav.Controls.Add(this.pnlNavBottom);
            this.pnlNav.Controls.Add(this.lblBrandSub);
            this.pnlNav.Controls.Add(this.lblBrand);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(210, 861);
            this.pnlNav.TabIndex = 0;
            //
            // navSettings
            //
            this.navSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.navSettings.Location = new System.Drawing.Point(0, 380);
            this.navSettings.Name = "navSettings";
            this.navSettings.Size = new System.Drawing.Size(210, 46);
            this.navSettings.TabIndex = 7;
            this.navSettings.Text = "설정 · 기준 정보";
            //
            // navImport
            //
            this.navImport.Dock = System.Windows.Forms.DockStyle.Top;
            this.navImport.Location = new System.Drawing.Point(0, 334);
            this.navImport.Name = "navImport";
            this.navImport.Size = new System.Drawing.Size(210, 46);
            this.navImport.TabIndex = 6;
            this.navImport.Text = "과거 자료 가져오기";
            //
            // navReports
            //
            this.navReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.navReports.Location = new System.Drawing.Point(0, 288);
            this.navReports.Name = "navReports";
            this.navReports.Size = new System.Drawing.Size(210, 46);
            this.navReports.TabIndex = 5;
            this.navReports.Text = "보고서 · 업무대장";
            //
            // navReleases
            //
            this.navReleases.Dock = System.Windows.Forms.DockStyle.Top;
            this.navReleases.Name = "navReleases";
            this.navReleases.Size = new System.Drawing.Size(210, 46);
            this.navReleases.TabIndex = 6;
            this.navReleases.Text = "프로그램 · 배포";
            //
            // navKnowledge
            //
            this.navKnowledge.Dock = System.Windows.Forms.DockStyle.Top;
            this.navKnowledge.Location = new System.Drawing.Point(0, 242);
            this.navKnowledge.Name = "navKnowledge";
            this.navKnowledge.Size = new System.Drawing.Size(210, 46);
            this.navKnowledge.TabIndex = 4;
            this.navKnowledge.Text = "지식베이스 (해결 사례)";
            //
            // navPlanned
            //
            this.navPlanned.Dock = System.Windows.Forms.DockStyle.Top;
            this.navPlanned.Location = new System.Drawing.Point(0, 196);
            this.navPlanned.Name = "navPlanned";
            this.navPlanned.Size = new System.Drawing.Size(210, 46);
            this.navPlanned.TabIndex = 3;
            this.navPlanned.Text = "할 일 · 예정 업무";
            //
            // navList
            //
            this.navList.Dock = System.Windows.Forms.DockStyle.Top;
            this.navList.Location = new System.Drawing.Point(0, 150);
            this.navList.Name = "navList";
            this.navList.Size = new System.Drawing.Size(210, 46);
            this.navList.TabIndex = 2;
            this.navList.Text = "전체 업무 목록";
            //
            // navDashboard
            //
            this.navDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.navDashboard.Location = new System.Drawing.Point(0, 104);
            this.navDashboard.Name = "navDashboard";
            this.navDashboard.Size = new System.Drawing.Size(210, 46);
            this.navDashboard.TabIndex = 1;
            this.navDashboard.Text = "대시보드";
            //
            // pnlNavBottom
            //
            this.pnlNavBottom.Controls.Add(this.lblWorkspace);
            this.pnlNavBottom.Controls.Add(this.btnQuickAdd);
            this.pnlNavBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavBottom.Location = new System.Drawing.Point(0, 741);
            this.pnlNavBottom.Name = "pnlNavBottom";
            this.pnlNavBottom.Padding = new System.Windows.Forms.Padding(14, 0, 14, 14);
            this.pnlNavBottom.Size = new System.Drawing.Size(210, 120);
            this.pnlNavBottom.TabIndex = 8;
            //
            // lblWorkspace
            //
            this.lblWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkspace.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.lblWorkspace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblWorkspace.Location = new System.Drawing.Point(14, 0);
            this.lblWorkspace.Name = "lblWorkspace";
            this.lblWorkspace.Size = new System.Drawing.Size(182, 62);
            this.lblWorkspace.TabIndex = 1;
            this.lblWorkspace.Text = "데이터 폴더";
            this.lblWorkspace.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // btnQuickAdd
            //
            this.btnQuickAdd.Accent = true;
            this.btnQuickAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuickAdd.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuickAdd.Location = new System.Drawing.Point(14, 62);
            this.btnQuickAdd.Name = "btnQuickAdd";
            this.btnQuickAdd.Size = new System.Drawing.Size(182, 44);
            this.btnQuickAdd.TabIndex = 0;
            this.btnQuickAdd.Text = "+ 빠른 접수  (Ctrl+N)";
            this.btnQuickAdd.Click += new System.EventHandler(this.btnQuickAdd_Click);
            //
            // lblBrandSub
            //
            this.lblBrandSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBrandSub.Location = new System.Drawing.Point(0, 62);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblBrandSub.Size = new System.Drawing.Size(210, 42);
            this.lblBrandSub.TabIndex = 9;
            this.lblBrandSub.Text = "TS 업무 관리";
            //
            // lblBrand
            //
            this.lblBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBrand.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblBrand.Location = new System.Drawing.Point(0, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblBrand.Size = new System.Drawing.Size(210, 62);
            this.lblBrand.TabIndex = 10;
            this.lblBrand.Text = "TS WorkBench";
            this.lblBrand.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // pnlHeader
            //
            this.pnlHeader.Controls.Add(this.btnNewItem);
            this.pnlHeader.Controls.Add(this.lblPageSubtitle);
            this.pnlHeader.Controls.Add(this.lblPageTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(210, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1174, 78);
            this.pnlHeader.TabIndex = 1;
            //
            // btnNewItem
            //
            this.btnNewItem.Accent = true;
            this.btnNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewItem.Location = new System.Drawing.Point(1024, 20);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(130, 38);
            this.btnNewItem.TabIndex = 2;
            this.btnNewItem.Text = "+ 새 업무 카드";
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            //
            // lblPageSubtitle
            //
            this.lblPageSubtitle.AutoSize = true;
            this.lblPageSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPageSubtitle.Location = new System.Drawing.Point(22, 48);
            this.lblPageSubtitle.Name = "lblPageSubtitle";
            this.lblPageSubtitle.Size = new System.Drawing.Size(63, 17);
            this.lblPageSubtitle.TabIndex = 1;
            this.lblPageSubtitle.Text = "페이지 설명";
            //
            // lblPageTitle
            //
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.Location = new System.Drawing.Point(18, 14);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(98, 30);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "대시보드";
            //
            // pnlContent
            //
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(210, 78);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(20, 4, 20, 16);
            this.pnlContent.Size = new System.Drawing.Size(1174, 783);
            this.pnlContent.TabIndex = 2;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1440, 900);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlNav);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1400, 860);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TS WorkBench";
            this.pnlNav.ResumeLayout(false);
            this.pnlNavBottom.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNav;
        private TSWorkBench.Theme.NavButton navDashboard;
        private TSWorkBench.Theme.NavButton navList;
        private TSWorkBench.Theme.NavButton navPlanned;
        private TSWorkBench.Theme.NavButton navKnowledge;
        private TSWorkBench.Theme.NavButton navReports;
        private TSWorkBench.Theme.NavButton navImport;
        private TSWorkBench.Theme.NavButton navReleases;
        private TSWorkBench.Theme.NavButton navSettings;
        private System.Windows.Forms.Panel pnlNavBottom;
        private TSWorkBench.Theme.DarkButton btnQuickAdd;
        private System.Windows.Forms.Label lblWorkspace;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblPageSubtitle;
        private TSWorkBench.Theme.DarkButton btnNewItem;
        private System.Windows.Forms.Panel pnlContent;
    }
}
