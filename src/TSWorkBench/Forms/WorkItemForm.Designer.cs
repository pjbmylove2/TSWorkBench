namespace TSWorkBench.Forms
{
    partial class WorkItemForm
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
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.tblSummary = new System.Windows.Forms.TableLayoutPanel();
            this.lblIdCap = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblTitleCap = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTypeCap = new System.Windows.Forms.Label();
            this.cboType = new TSWorkBench.Theme.DarkComboBox();
            this.lblStatusCap = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPriorityCap = new System.Windows.Forms.Label();
            this.cboPriority = new TSWorkBench.Theme.DarkComboBox();
            this.lblTagsCap = new System.Windows.Forms.Label();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.lblCustomerCap = new System.Windows.Forms.Label();
            this.cboCustomer = new TSWorkBench.Theme.DarkComboBox();
            this.lblSiteCap = new System.Windows.Forms.Label();
            this.cboSite = new TSWorkBench.Theme.DarkComboBox();
            this.lblEquipmentCap = new System.Windows.Forms.Label();
            this.cboEquipment = new TSWorkBench.Theme.DarkComboBox();
            this.lblSystemCap = new System.Windows.Forms.Label();
            this.cboSystem = new TSWorkBench.Theme.DarkComboBox();
            this.lblReceivedCap = new System.Windows.Forms.Label();
            this.dateReceived = new TSWorkBench.Theme.DateBox();
            this.lblDueCap = new System.Windows.Forms.Label();
            this.dateDue = new TSWorkBench.Theme.DateBox();
            this.lblCompletedCap = new System.Windows.Forms.Label();
            this.dateCompleted = new TSWorkBench.Theme.DateBox();
            this.lblRequesterCap = new System.Windows.Forms.Label();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.pnlSectionNav = new System.Windows.Forms.Panel();
            this.flpSections = new System.Windows.Forms.FlowLayoutPanel();
            this.secSymptom = new TSWorkBench.Theme.NavButton();
            this.secCause = new TSWorkBench.Theme.NavButton();
            this.secAction = new TSWorkBench.Theme.NavButton();
            this.secVerify = new TSWorkBench.Theme.NavButton();
            this.secTimeline = new TSWorkBench.Theme.NavButton();
            this.secChecklist = new TSWorkBench.Theme.NavButton();
            this.secAttach = new TSWorkBench.Theme.NavButton();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tblSymptom = new System.Windows.Forms.TableLayoutPanel();
            this.lblSymptomCap = new System.Windows.Forms.Label();
            this.txtSymptom = new System.Windows.Forms.TextBox();
            this.lblSymptomWhenCap = new System.Windows.Forms.Label();
            this.txtSymptomWhen = new System.Windows.Forms.TextBox();
            this.lblReproductionCap = new System.Windows.Forms.Label();
            this.txtReproduction = new System.Windows.Forms.TextBox();
            this.lblImpactCap = new System.Windows.Forms.Label();
            this.txtImpact = new System.Windows.Forms.TextBox();
            this.tblCause = new System.Windows.Forms.TableLayoutPanel();
            this.lblCauseCap = new System.Windows.Forms.Label();
            this.txtCause = new System.Windows.Forms.TextBox();
            this.lblCauseEvidenceCap = new System.Windows.Forms.Label();
            this.txtCauseEvidence = new System.Windows.Forms.TextBox();
            this.tblAction = new System.Windows.Forms.TableLayoutPanel();
            this.lblActionHwCap = new System.Windows.Forms.Label();
            this.txtActionHw = new System.Windows.Forms.TextBox();
            this.lblActionSwCap = new System.Windows.Forms.Label();
            this.txtActionSw = new System.Windows.Forms.TextBox();
            this.lblChangedFilesCap = new System.Windows.Forms.Label();
            this.txtChangedFiles = new System.Windows.Forms.TextBox();
            this.tblVerify = new System.Windows.Forms.TableLayoutPanel();
            this.lblVerificationCap = new System.Windows.Forms.Label();
            this.txtVerification = new System.Windows.Forms.TextBox();
            this.lblPreventionCap = new System.Windows.Forms.Label();
            this.txtPrevention = new System.Windows.Forms.TextBox();
            this.lblCustomerNoteCap = new System.Windows.Forms.Label();
            this.txtCustomerNote = new System.Windows.Forms.TextBox();
            this.flpRevisit = new System.Windows.Forms.FlowLayoutPanel();
            this.chkRevisit = new System.Windows.Forms.CheckBox();
            this.dateRevisit = new TSWorkBench.Theme.DateBox();
            this.lblRevisitHint = new System.Windows.Forms.Label();
            this.pnlTimeline = new System.Windows.Forms.Panel();
            this.gridTimeline = new TSWorkBench.Theme.DarkGrid();
            this.colTlStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTlEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTlKind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTlHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTlText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTimelineEditor = new System.Windows.Forms.Panel();
            this.lblTlStart = new System.Windows.Forms.Label();
            this.dateTlStart = new TSWorkBench.Theme.DateBox();
            this.lblTlEnd = new System.Windows.Forms.Label();
            this.dateTlEnd = new TSWorkBench.Theme.DateBox();
            this.lblTlKind = new System.Windows.Forms.Label();
            this.cboTlKind = new TSWorkBench.Theme.DarkComboBox();
            this.lblTlText = new System.Windows.Forms.Label();
            this.txtTlText = new System.Windows.Forms.TextBox();
            this.btnTlStartNow = new TSWorkBench.Theme.DarkButton();
            this.btnTlEndNow = new TSWorkBench.Theme.DarkButton();
            this.btnTlAdd = new TSWorkBench.Theme.DarkButton();
            this.btnTlUpdate = new TSWorkBench.Theme.DarkButton();
            this.btnTlDelete = new TSWorkBench.Theme.DarkButton();
            this.lblTlHours = new System.Windows.Forms.Label();
            this.pnlChecklist = new System.Windows.Forms.Panel();
            this.clbChecklist = new System.Windows.Forms.CheckedListBox();
            this.flpCheckTools = new System.Windows.Forms.FlowLayoutPanel();
            this.txtCheckNew = new System.Windows.Forms.TextBox();
            this.btnCheckAdd = new TSWorkBench.Theme.DarkButton();
            this.btnCheckRemove = new TSWorkBench.Theme.DarkButton();
            this.btnCheckTemplate = new TSWorkBench.Theme.DarkButton();
            this.pnlAttach = new System.Windows.Forms.Panel();
            this.gridAttach = new TSWorkBench.Theme.DarkGrid();
            this.colAtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAtPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flpAttachTools = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAttachCopy = new TSWorkBench.Theme.DarkButton();
            this.btnAttachLink = new TSWorkBench.Theme.DarkButton();
            this.btnAttachFolder = new TSWorkBench.Theme.DarkButton();
            this.btnAttachPaste = new TSWorkBench.Theme.DarkButton();
            this.btnAttachOpen = new TSWorkBench.Theme.DarkButton();
            this.btnAttachRemove = new TSWorkBench.Theme.DarkButton();
            this.lblAttachHint = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.flpBottomLeft = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new TSWorkBench.Theme.DarkButton();
            this.btnAdvance = new TSWorkBench.Theme.DarkButton();
            this.btnStatus = new TSWorkBench.Theme.DarkButton();
            this.flpBottomRight = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new TSWorkBench.Theme.DarkButton();
            this.btnFolder = new TSWorkBench.Theme.DarkButton();
            this.btnNotion = new TSWorkBench.Theme.DarkButton();
            this.btnReport = new TSWorkBench.Theme.DarkButton();
            this.pnlSummary.SuspendLayout();
            this.tblSummary.SuspendLayout();
            this.pnlSectionNav.SuspendLayout();
            this.flpSections.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.tblSymptom.SuspendLayout();
            this.tblCause.SuspendLayout();
            this.tblAction.SuspendLayout();
            this.tblVerify.SuspendLayout();
            this.flpRevisit.SuspendLayout();
            this.pnlTimeline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimeline)).BeginInit();
            this.pnlTimelineEditor.SuspendLayout();
            this.pnlChecklist.SuspendLayout();
            this.flpCheckTools.SuspendLayout();
            this.pnlAttach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttach)).BeginInit();
            this.flpAttachTools.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.flpBottomLeft.SuspendLayout();
            this.flpBottomRight.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlSummary
            //
            this.pnlSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlSummary.Controls.Add(this.tblSummary);
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSummary.Location = new System.Drawing.Point(0, 0);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(16, 12, 16, 10);
            this.pnlSummary.Size = new System.Drawing.Size(1180, 186);
            this.pnlSummary.TabIndex = 0;
            //
            // tblSummary
            //
            this.tblSummary.ColumnCount = 8;
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tblSummary.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSummary.Controls.Add(this.lblIdCap, 0, 0);
            this.tblSummary.Controls.Add(this.lblId, 1, 0);
            this.tblSummary.Controls.Add(this.lblTitleCap, 2, 0);
            this.tblSummary.Controls.Add(this.txtTitle, 3, 0);
            this.tblSummary.Controls.Add(this.lblTypeCap, 0, 1);
            this.tblSummary.Controls.Add(this.cboType, 1, 1);
            this.tblSummary.Controls.Add(this.lblStatusCap, 2, 1);
            this.tblSummary.Controls.Add(this.lblStatus, 3, 1);
            this.tblSummary.Controls.Add(this.lblPriorityCap, 4, 1);
            this.tblSummary.Controls.Add(this.cboPriority, 5, 1);
            this.tblSummary.Controls.Add(this.lblTagsCap, 6, 1);
            this.tblSummary.Controls.Add(this.txtTags, 7, 1);
            this.tblSummary.Controls.Add(this.lblCustomerCap, 0, 2);
            this.tblSummary.Controls.Add(this.cboCustomer, 1, 2);
            this.tblSummary.Controls.Add(this.lblSiteCap, 2, 2);
            this.tblSummary.Controls.Add(this.cboSite, 3, 2);
            this.tblSummary.Controls.Add(this.lblEquipmentCap, 4, 2);
            this.tblSummary.Controls.Add(this.cboEquipment, 5, 2);
            this.tblSummary.Controls.Add(this.lblSystemCap, 6, 2);
            this.tblSummary.Controls.Add(this.cboSystem, 7, 2);
            this.tblSummary.Controls.Add(this.lblReceivedCap, 0, 3);
            this.tblSummary.Controls.Add(this.dateReceived, 1, 3);
            this.tblSummary.Controls.Add(this.lblDueCap, 2, 3);
            this.tblSummary.Controls.Add(this.dateDue, 3, 3);
            this.tblSummary.Controls.Add(this.lblCompletedCap, 4, 3);
            this.tblSummary.Controls.Add(this.dateCompleted, 5, 3);
            this.tblSummary.Controls.Add(this.lblRequesterCap, 6, 3);
            this.tblSummary.Controls.Add(this.txtRequester, 7, 3);
            this.tblSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSummary.Location = new System.Drawing.Point(16, 12);
            this.tblSummary.Name = "tblSummary";
            this.tblSummary.RowCount = 4;
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblSummary.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblSummary.Size = new System.Drawing.Size(1148, 164);
            this.tblSummary.TabIndex = 0;
            //
            // lblIdCap
            //
            this.lblIdCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIdCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblIdCap.Name = "lblIdCap";
            this.lblIdCap.Text = "업무 ID";
            this.lblIdCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblId
            //
            this.lblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblId.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblId.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblId.Name = "lblId";
            this.lblId.Text = "(저장 시 부여)";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblTitleCap
            //
            this.lblTitleCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitleCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTitleCap.Name = "lblTitleCap";
            this.lblTitleCap.Text = "제목 *";
            this.lblTitleCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTitle
            //
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tblSummary.SetColumnSpan(this.txtTitle, 5);
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.TabIndex = 0;
            //
            // lblTypeCap
            //
            this.lblTypeCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTypeCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTypeCap.Name = "lblTypeCap";
            this.lblTypeCap.Text = "유형";
            this.lblTypeCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboType
            //
            this.cboType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboType.Margin = new System.Windows.Forms.Padding(3, 7, 14, 3);
            this.cboType.Name = "cboType";
            this.cboType.TabIndex = 1;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            //
            // lblStatusCap
            //
            this.lblStatusCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStatusCap.Name = "lblStatusCap";
            this.lblStatusCap.Text = "상태";
            this.lblStatusCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStatus
            //
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "접수";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblPriorityCap
            //
            this.lblPriorityCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPriorityCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPriorityCap.Name = "lblPriorityCap";
            this.lblPriorityCap.Text = "우선순위";
            this.lblPriorityCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboPriority
            //
            this.cboPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboPriority.Margin = new System.Windows.Forms.Padding(3, 7, 14, 3);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.TabIndex = 2;
            //
            // lblTagsCap
            //
            this.lblTagsCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTagsCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTagsCap.Name = "lblTagsCap";
            this.lblTagsCap.Text = "태그";
            this.lblTagsCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTags
            //
            this.txtTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTags.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtTags.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtTags.Name = "txtTags";
            this.txtTags.TabIndex = 3;
            //
            // lblCustomerCap
            //
            this.lblCustomerCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCustomerCap.Name = "lblCustomerCap";
            this.lblCustomerCap.Text = "고객사";
            this.lblCustomerCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboCustomer
            //
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(3, 7, 14, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.TabIndex = 4;
            //
            // lblSiteCap
            //
            this.lblSiteCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSiteCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSiteCap.Name = "lblSiteCap";
            this.lblSiteCap.Text = "사이트/라인";
            this.lblSiteCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboSite
            //
            this.cboSite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboSite.Margin = new System.Windows.Forms.Padding(3, 7, 14, 3);
            this.cboSite.Name = "cboSite";
            this.cboSite.TabIndex = 5;
            //
            // lblEquipmentCap
            //
            this.lblEquipmentCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEquipmentCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblEquipmentCap.Name = "lblEquipmentCap";
            this.lblEquipmentCap.Text = "설비";
            this.lblEquipmentCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboEquipment
            //
            this.cboEquipment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEquipment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEquipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboEquipment.Margin = new System.Windows.Forms.Padding(3, 7, 14, 3);
            this.cboEquipment.Name = "cboEquipment";
            this.cboEquipment.TabIndex = 6;
            //
            // lblSystemCap
            //
            this.lblSystemCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSystemCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSystemCap.Name = "lblSystemCap";
            this.lblSystemCap.Text = "대상 시스템";
            this.lblSystemCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboSystem
            //
            this.cboSystem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSystem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSystem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboSystem.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.cboSystem.Name = "cboSystem";
            this.cboSystem.TabIndex = 7;
            //
            // lblReceivedCap
            //
            this.lblReceivedCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceivedCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblReceivedCap.Name = "lblReceivedCap";
            this.lblReceivedCap.Text = "접수 일시";
            this.lblReceivedCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dateReceived
            //
            this.dateReceived.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateReceived.Margin = new System.Windows.Forms.Padding(3, 7, 14, 6);
            this.dateReceived.Name = "dateReceived";
            this.dateReceived.ShowTime = true;
            this.dateReceived.TabIndex = 8;
            //
            // lblDueCap
            //
            this.lblDueCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDueCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDueCap.Name = "lblDueCap";
            this.lblDueCap.Text = "기한";
            this.lblDueCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dateDue
            //
            this.dateDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateDue.Margin = new System.Windows.Forms.Padding(3, 7, 14, 6);
            this.dateDue.Name = "dateDue";
            this.dateDue.ShowTime = true;
            this.dateDue.TabIndex = 9;
            //
            // lblCompletedCap
            //
            this.lblCompletedCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCompletedCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCompletedCap.Name = "lblCompletedCap";
            this.lblCompletedCap.Text = "완료 일시";
            this.lblCompletedCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dateCompleted
            //
            this.dateCompleted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateCompleted.Margin = new System.Windows.Forms.Padding(3, 7, 14, 6);
            this.dateCompleted.Name = "dateCompleted";
            this.dateCompleted.ShowTime = true;
            this.dateCompleted.TabIndex = 10;
            //
            // lblRequesterCap
            //
            this.lblRequesterCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRequesterCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblRequesterCap.Name = "lblRequesterCap";
            this.lblRequesterCap.Text = "요청자·연락처";
            this.lblRequesterCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtRequester
            //
            this.txtRequester.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtRequester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequester.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtRequester.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.TabIndex = 11;
            //
            // pnlSectionNav
            //
            this.pnlSectionNav.Controls.Add(this.flpSections);
            this.pnlSectionNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSectionNav.Location = new System.Drawing.Point(0, 186);
            this.pnlSectionNav.Name = "pnlSectionNav";
            this.pnlSectionNav.Padding = new System.Windows.Forms.Padding(16, 6, 16, 0);
            this.pnlSectionNav.Size = new System.Drawing.Size(1180, 48);
            this.pnlSectionNav.TabIndex = 1;
            //
            // flpSections
            //
            this.flpSections.Controls.Add(this.secSymptom);
            this.flpSections.Controls.Add(this.secCause);
            this.flpSections.Controls.Add(this.secAction);
            this.flpSections.Controls.Add(this.secVerify);
            this.flpSections.Controls.Add(this.secTimeline);
            this.flpSections.Controls.Add(this.secChecklist);
            this.flpSections.Controls.Add(this.secAttach);
            this.flpSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSections.Name = "flpSections";
            this.flpSections.WrapContents = false;
            this.flpSections.TabIndex = 0;
            //
            // secSymptom
            //
            this.secSymptom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secSymptom.BarAtBottom = true;
            this.secSymptom.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.secSymptom.Name = "secSymptom";
            this.secSymptom.Padding = new System.Windows.Forms.Padding(0);
            this.secSymptom.Size = new System.Drawing.Size(120, 40);
            this.secSymptom.Text = "① 현상";
            this.secSymptom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // secCause
            //
            this.secCause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secCause.BarAtBottom = true;
            this.secCause.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.secCause.Name = "secCause";
            this.secCause.Padding = new System.Windows.Forms.Padding(0);
            this.secCause.Size = new System.Drawing.Size(120, 40);
            this.secCause.Text = "② 원인";
            this.secCause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // secAction
            //
            this.secAction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secAction.BarAtBottom = true;
            this.secAction.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.secAction.Name = "secAction";
            this.secAction.Padding = new System.Windows.Forms.Padding(0);
            this.secAction.Size = new System.Drawing.Size(120, 40);
            this.secAction.Text = "③ 조치";
            this.secAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // secVerify
            //
            this.secVerify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secVerify.BarAtBottom = true;
            this.secVerify.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.secVerify.Name = "secVerify";
            this.secVerify.Padding = new System.Windows.Forms.Padding(0);
            this.secVerify.Size = new System.Drawing.Size(150, 40);
            this.secVerify.Text = "④ 검증·재발방지";
            this.secVerify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // secTimeline
            //
            this.secTimeline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secTimeline.BarAtBottom = true;
            this.secTimeline.Margin = new System.Windows.Forms.Padding(24, 0, 4, 0);
            this.secTimeline.Name = "secTimeline";
            this.secTimeline.Padding = new System.Windows.Forms.Padding(0);
            this.secTimeline.Size = new System.Drawing.Size(120, 40);
            this.secTimeline.Text = "작업 이력";
            this.secTimeline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // secChecklist
            //
            this.secChecklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secChecklist.BarAtBottom = true;
            this.secChecklist.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.secChecklist.Name = "secChecklist";
            this.secChecklist.Padding = new System.Windows.Forms.Padding(0);
            this.secChecklist.Size = new System.Drawing.Size(120, 40);
            this.secChecklist.Text = "체크리스트";
            this.secChecklist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // secAttach
            //
            this.secAttach.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.secAttach.BarAtBottom = true;
            this.secAttach.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.secAttach.Name = "secAttach";
            this.secAttach.Padding = new System.Windows.Forms.Padding(0);
            this.secAttach.Size = new System.Drawing.Size(120, 40);
            this.secAttach.Text = "첨부 (사진·로그)";
            this.secAttach.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // pnlBody
            //
            this.pnlBody.Controls.Add(this.tblSymptom);
            this.pnlBody.Controls.Add(this.tblCause);
            this.pnlBody.Controls.Add(this.tblAction);
            this.pnlBody.Controls.Add(this.tblVerify);
            this.pnlBody.Controls.Add(this.pnlTimeline);
            this.pnlBody.Controls.Add(this.pnlChecklist);
            this.pnlBody.Controls.Add(this.pnlAttach);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 234);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(16, 10, 16, 10);
            this.pnlBody.Size = new System.Drawing.Size(1180, 564);
            this.pnlBody.TabIndex = 2;
            //
            // tblSymptom
            //
            this.tblSymptom.ColumnCount = 1;
            this.tblSymptom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSymptom.Controls.Add(this.lblSymptomCap, 0, 0);
            this.tblSymptom.Controls.Add(this.txtSymptom, 0, 1);
            this.tblSymptom.Controls.Add(this.lblSymptomWhenCap, 0, 2);
            this.tblSymptom.Controls.Add(this.txtSymptomWhen, 0, 3);
            this.tblSymptom.Controls.Add(this.lblReproductionCap, 0, 4);
            this.tblSymptom.Controls.Add(this.txtReproduction, 0, 5);
            this.tblSymptom.Controls.Add(this.lblImpactCap, 0, 6);
            this.tblSymptom.Controls.Add(this.txtImpact, 0, 7);
            this.tblSymptom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSymptom.Name = "tblSymptom";
            this.tblSymptom.RowCount = 8;
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblSymptom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblSymptom.TabIndex = 0;
            //
            // lblSymptomCap
            //
            this.lblSymptomCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSymptomCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblSymptomCap.Name = "lblSymptomCap";
            this.lblSymptomCap.Text = "현상 — 무엇이, 어디서, 얼마나 (고객이 말한 내용 + 직접 확인한 사실)";
            this.lblSymptomCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtSymptom
            //
            this.txtSymptom.AcceptsReturn = true;
            this.txtSymptom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtSymptom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSymptom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSymptom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtSymptom.Multiline = true;
            this.txtSymptom.Name = "txtSymptom";
            this.txtSymptom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSymptom.TabIndex = 0;
            //
            // lblSymptomWhenCap
            //
            this.lblSymptomWhenCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSymptomWhenCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblSymptomWhenCap.Name = "lblSymptomWhenCap";
            this.lblSymptomWhenCap.Text = "발생 시점 · 빈도 (예: 10/21 야간조부터, 시간당 5~6회)";
            this.lblSymptomWhenCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtSymptomWhen
            //
            this.txtSymptomWhen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtSymptomWhen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSymptomWhen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSymptomWhen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtSymptomWhen.Name = "txtSymptomWhen";
            this.txtSymptomWhen.TabIndex = 1;
            //
            // lblReproductionCap
            //
            this.lblReproductionCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReproductionCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblReproductionCap.Name = "lblReproductionCap";
            this.lblReproductionCap.Text = "재현 조건 (언제 재현되고, 언제 안 되는가)";
            this.lblReproductionCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtReproduction
            //
            this.txtReproduction.AcceptsReturn = true;
            this.txtReproduction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtReproduction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReproduction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReproduction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtReproduction.Multiline = true;
            this.txtReproduction.Name = "txtReproduction";
            this.txtReproduction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReproduction.TabIndex = 2;
            //
            // lblImpactCap
            //
            this.lblImpactCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImpactCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblImpactCap.Name = "lblImpactCap";
            this.lblImpactCap.Text = "영향 (생산 중단 · 불량 유출 · 수율 저하 등)";
            this.lblImpactCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtImpact
            //
            this.txtImpact.AcceptsReturn = true;
            this.txtImpact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtImpact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImpact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtImpact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtImpact.Multiline = true;
            this.txtImpact.Name = "txtImpact";
            this.txtImpact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtImpact.TabIndex = 3;
            //
            // tblCause
            //
            this.tblCause.ColumnCount = 1;
            this.tblCause.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblCause.Controls.Add(this.lblCauseCap, 0, 0);
            this.tblCause.Controls.Add(this.txtCause, 0, 1);
            this.tblCause.Controls.Add(this.lblCauseEvidenceCap, 0, 2);
            this.tblCause.Controls.Add(this.txtCauseEvidence, 0, 3);
            this.tblCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCause.Name = "tblCause";
            this.tblCause.RowCount = 4;
            this.tblCause.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblCause.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCause.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblCause.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCause.TabIndex = 1;
            this.tblCause.Visible = false;
            //
            // lblCauseCap
            //
            this.lblCauseCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCauseCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblCauseCap.Name = "lblCauseCap";
            this.lblCauseCap.Text = "원인 — 확인된 사실 위주. 아직 추정이면 \'추정:\'으로 시작";
            this.lblCauseCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtCause
            //
            this.txtCause.AcceptsReturn = true;
            this.txtCause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCause.Multiline = true;
            this.txtCause.Name = "txtCause";
            this.txtCause.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCause.TabIndex = 0;
            //
            // lblCauseEvidenceCap
            //
            this.lblCauseEvidenceCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCauseEvidenceCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblCauseEvidenceCap.Name = "lblCauseEvidenceCap";
            this.lblCauseEvidenceCap.Text = "근거 — 로그 · 측정값 · 이미지 · 5 Why (왜? 를 다섯 번)";
            this.lblCauseEvidenceCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtCauseEvidence
            //
            this.txtCauseEvidence.AcceptsReturn = true;
            this.txtCauseEvidence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCauseEvidence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCauseEvidence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCauseEvidence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCauseEvidence.Multiline = true;
            this.txtCauseEvidence.Name = "txtCauseEvidence";
            this.txtCauseEvidence.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCauseEvidence.TabIndex = 1;
            //
            // tblAction
            //
            this.tblAction.ColumnCount = 1;
            this.tblAction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAction.Controls.Add(this.lblActionHwCap, 0, 0);
            this.tblAction.Controls.Add(this.txtActionHw, 0, 1);
            this.tblAction.Controls.Add(this.lblActionSwCap, 0, 2);
            this.tblAction.Controls.Add(this.txtActionSw, 0, 3);
            this.tblAction.Controls.Add(this.lblChangedFilesCap, 0, 4);
            this.tblAction.Controls.Add(this.txtChangedFiles, 0, 5);
            this.tblAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAction.Name = "tblAction";
            this.tblAction.RowCount = 6;
            this.tblAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblAction.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tblAction.TabIndex = 2;
            this.tblAction.Visible = false;
            //
            // lblActionHwCap
            //
            this.lblActionHwCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActionHwCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblActionHwCap.Name = "lblActionHwCap";
            this.lblActionHwCap.Text = "하드웨어 조치 (교체 부품 · 모델 · S/N, 조정값)";
            this.lblActionHwCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtActionHw
            //
            this.txtActionHw.AcceptsReturn = true;
            this.txtActionHw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtActionHw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionHw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActionHw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtActionHw.Multiline = true;
            this.txtActionHw.Name = "txtActionHw";
            this.txtActionHw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActionHw.TabIndex = 0;
            //
            // lblActionSwCap
            //
            this.lblActionSwCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActionSwCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblActionSwCap.Name = "lblActionSwCap";
            this.lblActionSwCap.Text = "소프트웨어 조치 (수정 내용 · 설정 변경)";
            this.lblActionSwCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtActionSw
            //
            this.txtActionSw.AcceptsReturn = true;
            this.txtActionSw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtActionSw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionSw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtActionSw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtActionSw.Multiline = true;
            this.txtActionSw.Name = "txtActionSw";
            this.txtActionSw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtActionSw.TabIndex = 1;
            //
            // lblChangedFilesCap
            //
            this.lblChangedFilesCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChangedFilesCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblChangedFilesCap.Name = "lblChangedFilesCap";
            this.lblChangedFilesCap.Text = "변경 내역 — 파일 · 버전 · 설정 전 → 후 (원복할 때 필요한 정보)";
            this.lblChangedFilesCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtChangedFiles
            //
            this.txtChangedFiles.AcceptsReturn = true;
            this.txtChangedFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtChangedFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChangedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChangedFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtChangedFiles.Multiline = true;
            this.txtChangedFiles.Name = "txtChangedFiles";
            this.txtChangedFiles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChangedFiles.TabIndex = 2;
            //
            // tblVerify
            //
            this.tblVerify.ColumnCount = 1;
            this.tblVerify.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblVerify.Controls.Add(this.lblVerificationCap, 0, 0);
            this.tblVerify.Controls.Add(this.txtVerification, 0, 1);
            this.tblVerify.Controls.Add(this.lblPreventionCap, 0, 2);
            this.tblVerify.Controls.Add(this.txtPrevention, 0, 3);
            this.tblVerify.Controls.Add(this.lblCustomerNoteCap, 0, 4);
            this.tblVerify.Controls.Add(this.txtCustomerNote, 0, 5);
            this.tblVerify.Controls.Add(this.flpRevisit, 0, 6);
            this.tblVerify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblVerify.Name = "tblVerify";
            this.tblVerify.RowCount = 7;
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblVerify.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tblVerify.TabIndex = 3;
            this.tblVerify.Visible = false;
            //
            // lblVerificationCap
            //
            this.lblVerificationCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVerificationCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblVerificationCap.Name = "lblVerificationCap";
            this.lblVerificationCap.Text = "검증 결과 (얼마 동안 · 몇 개 생산 · 무엇을 확인했는가)";
            this.lblVerificationCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtVerification
            //
            this.txtVerification.AcceptsReturn = true;
            this.txtVerification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtVerification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVerification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVerification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtVerification.Multiline = true;
            this.txtVerification.Name = "txtVerification";
            this.txtVerification.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVerification.TabIndex = 0;
            //
            // lblPreventionCap
            //
            this.lblPreventionCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPreventionCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblPreventionCap.Name = "lblPreventionCap";
            this.lblPreventionCap.Text = "재발 방지 (다른 라인 · 다른 고객사에서도 안 생기게 할 일)";
            this.lblPreventionCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtPrevention
            //
            this.txtPrevention.AcceptsReturn = true;
            this.txtPrevention.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtPrevention.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrevention.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPrevention.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtPrevention.Multiline = true;
            this.txtPrevention.Name = "txtPrevention";
            this.txtPrevention.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrevention.TabIndex = 1;
            //
            // lblCustomerNoteCap
            //
            this.lblCustomerNoteCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerNoteCap.ForeColor = System.Drawing.Color.RosyBrown;
            this.lblCustomerNoteCap.Name = "lblCustomerNoteCap";
            this.lblCustomerNoteCap.Text = "고객 전달 사항 (주의할 점 · 요청 사항 · 재방문 사유)";
            this.lblCustomerNoteCap.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            //
            // txtCustomerNote
            //
            this.txtCustomerNote.AcceptsReturn = true;
            this.txtCustomerNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCustomerNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomerNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCustomerNote.Multiline = true;
            this.txtCustomerNote.Name = "txtCustomerNote";
            this.txtCustomerNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomerNote.TabIndex = 2;
            //
            // flpRevisit
            //
            this.flpRevisit.Controls.Add(this.chkRevisit);
            this.flpRevisit.Controls.Add(this.dateRevisit);
            this.flpRevisit.Controls.Add(this.lblRevisitHint);
            this.flpRevisit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRevisit.Name = "flpRevisit";
            this.flpRevisit.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flpRevisit.TabIndex = 3;
            //
            // chkRevisit
            //
            this.chkRevisit.AutoSize = true;
            this.chkRevisit.Margin = new System.Windows.Forms.Padding(0, 4, 8, 0);
            this.chkRevisit.Name = "chkRevisit";
            this.chkRevisit.TabIndex = 0;
            this.chkRevisit.Text = "재방문 필요 — 예정일";
            //
            // dateRevisit
            //
            this.dateRevisit.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.dateRevisit.Name = "dateRevisit";
            this.dateRevisit.Size = new System.Drawing.Size(150, 25);
            this.dateRevisit.TabIndex = 1;
            //
            // lblRevisitHint
            //
            this.lblRevisitHint.AutoSize = true;
            this.lblRevisitHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblRevisitHint.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.lblRevisitHint.Name = "lblRevisitHint";
            this.lblRevisitHint.TabIndex = 2;
            this.lblRevisitHint.Text = "완료 처리하면 재방문·모니터링 예정 업무가 자동으로 만들어집니다.";
            //
            // pnlTimeline
            //
            this.pnlTimeline.Controls.Add(this.gridTimeline);
            this.pnlTimeline.Controls.Add(this.pnlTimelineEditor);
            this.pnlTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTimeline.Name = "pnlTimeline";
            this.pnlTimeline.TabIndex = 4;
            this.pnlTimeline.Visible = false;
            //
            // gridTimeline
            //
            this.gridTimeline.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTlStart,
            this.colTlEnd,
            this.colTlKind,
            this.colTlHours,
            this.colTlText});
            this.gridTimeline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTimeline.Name = "gridTimeline";
            this.gridTimeline.TabIndex = 1;
            this.gridTimeline.SelectionChanged += new System.EventHandler(this.gridTimeline_SelectionChanged);
            //
            // colTlStart
            //
            this.colTlStart.HeaderText = "시작";
            this.colTlStart.Name = "colTlStart";
            this.colTlStart.Width = 140;
            //
            // colTlEnd
            //
            this.colTlEnd.HeaderText = "종료";
            this.colTlEnd.Name = "colTlEnd";
            this.colTlEnd.Width = 140;
            //
            // colTlKind
            //
            this.colTlKind.HeaderText = "구분";
            this.colTlKind.Name = "colTlKind";
            //
            // colTlHours
            //
            this.colTlHours.HeaderText = "시간(h)";
            this.colTlHours.Name = "colTlHours";
            this.colTlHours.Width = 70;
            //
            // colTlText
            //
            this.colTlText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTlText.HeaderText = "내용";
            this.colTlText.Name = "colTlText";
            //
            // pnlTimelineEditor
            //
            this.pnlTimelineEditor.Controls.Add(this.lblTlStart);
            this.pnlTimelineEditor.Controls.Add(this.dateTlStart);
            this.pnlTimelineEditor.Controls.Add(this.lblTlEnd);
            this.pnlTimelineEditor.Controls.Add(this.dateTlEnd);
            this.pnlTimelineEditor.Controls.Add(this.lblTlKind);
            this.pnlTimelineEditor.Controls.Add(this.cboTlKind);
            this.pnlTimelineEditor.Controls.Add(this.lblTlText);
            this.pnlTimelineEditor.Controls.Add(this.txtTlText);
            this.pnlTimelineEditor.Controls.Add(this.btnTlStartNow);
            this.pnlTimelineEditor.Controls.Add(this.btnTlEndNow);
            this.pnlTimelineEditor.Controls.Add(this.btnTlAdd);
            this.pnlTimelineEditor.Controls.Add(this.btnTlUpdate);
            this.pnlTimelineEditor.Controls.Add(this.btnTlDelete);
            this.pnlTimelineEditor.Controls.Add(this.lblTlHours);
            this.pnlTimelineEditor.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimelineEditor.Name = "pnlTimelineEditor";
            this.pnlTimelineEditor.Size = new System.Drawing.Size(1148, 100);
            this.pnlTimelineEditor.TabIndex = 0;
            //
            // lblTlStart
            //
            this.lblTlStart.AutoSize = true;
            this.lblTlStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTlStart.Location = new System.Drawing.Point(0, 2);
            this.lblTlStart.Name = "lblTlStart";
            this.lblTlStart.Text = "시작";
            //
            // dateTlStart
            //
            this.dateTlStart.Location = new System.Drawing.Point(0, 24);
            this.dateTlStart.Name = "dateTlStart";
            this.dateTlStart.ShowTime = true;
            this.dateTlStart.Size = new System.Drawing.Size(160, 25);
            this.dateTlStart.TabIndex = 0;
            //
            // lblTlEnd
            //
            this.lblTlEnd.AutoSize = true;
            this.lblTlEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTlEnd.Location = new System.Drawing.Point(170, 2);
            this.lblTlEnd.Name = "lblTlEnd";
            this.lblTlEnd.Text = "종료 (없으면 비움)";
            //
            // dateTlEnd
            //
            this.dateTlEnd.Location = new System.Drawing.Point(170, 24);
            this.dateTlEnd.Name = "dateTlEnd";
            this.dateTlEnd.ShowTime = true;
            this.dateTlEnd.Size = new System.Drawing.Size(160, 25);
            this.dateTlEnd.TabIndex = 1;
            //
            // lblTlKind
            //
            this.lblTlKind.AutoSize = true;
            this.lblTlKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTlKind.Location = new System.Drawing.Point(340, 2);
            this.lblTlKind.Name = "lblTlKind";
            this.lblTlKind.Text = "구분";
            //
            // cboTlKind
            //
            this.cboTlKind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboTlKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTlKind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTlKind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboTlKind.Location = new System.Drawing.Point(340, 24);
            this.cboTlKind.Name = "cboTlKind";
            this.cboTlKind.Size = new System.Drawing.Size(120, 25);
            this.cboTlKind.TabIndex = 2;
            //
            // lblTlText
            //
            this.lblTlText.AutoSize = true;
            this.lblTlText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTlText.Location = new System.Drawing.Point(470, 2);
            this.lblTlText.Name = "lblTlText";
            this.lblTlText.Text = "내용 (누구와 · 무엇을 · 결과)";
            //
            // txtTlText
            //
            this.txtTlText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTlText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtTlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTlText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtTlText.Location = new System.Drawing.Point(470, 24);
            this.txtTlText.Name = "txtTlText";
            this.txtTlText.Size = new System.Drawing.Size(678, 25);
            this.txtTlText.TabIndex = 3;
            //
            // btnTlStartNow
            //
            this.btnTlStartNow.Location = new System.Drawing.Point(0, 60);
            this.btnTlStartNow.Name = "btnTlStartNow";
            this.btnTlStartNow.Size = new System.Drawing.Size(92, 30);
            this.btnTlStartNow.TabIndex = 4;
            this.btnTlStartNow.Text = "시작 = 지금";
            this.btnTlStartNow.Click += new System.EventHandler(this.btnTlStartNow_Click);
            //
            // btnTlEndNow
            //
            this.btnTlEndNow.Location = new System.Drawing.Point(98, 60);
            this.btnTlEndNow.Name = "btnTlEndNow";
            this.btnTlEndNow.Size = new System.Drawing.Size(92, 30);
            this.btnTlEndNow.TabIndex = 5;
            this.btnTlEndNow.Text = "종료 = 지금";
            this.btnTlEndNow.Click += new System.EventHandler(this.btnTlEndNow_Click);
            //
            // btnTlAdd
            //
            this.btnTlAdd.Accent = true;
            this.btnTlAdd.Location = new System.Drawing.Point(206, 60);
            this.btnTlAdd.Name = "btnTlAdd";
            this.btnTlAdd.Size = new System.Drawing.Size(90, 30);
            this.btnTlAdd.TabIndex = 6;
            this.btnTlAdd.Text = "추가";
            this.btnTlAdd.Click += new System.EventHandler(this.btnTlAdd_Click);
            //
            // btnTlUpdate
            //
            this.btnTlUpdate.Location = new System.Drawing.Point(302, 60);
            this.btnTlUpdate.Name = "btnTlUpdate";
            this.btnTlUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnTlUpdate.TabIndex = 7;
            this.btnTlUpdate.Text = "선택 행 수정";
            this.btnTlUpdate.Click += new System.EventHandler(this.btnTlUpdate_Click);
            //
            // btnTlDelete
            //
            this.btnTlDelete.Location = new System.Drawing.Point(408, 60);
            this.btnTlDelete.Name = "btnTlDelete";
            this.btnTlDelete.Size = new System.Drawing.Size(100, 30);
            this.btnTlDelete.TabIndex = 8;
            this.btnTlDelete.Text = "선택 행 삭제";
            this.btnTlDelete.Click += new System.EventHandler(this.btnTlDelete_Click);
            //
            // lblTlHours
            //
            this.lblTlHours.AutoSize = true;
            this.lblTlHours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTlHours.Location = new System.Drawing.Point(524, 66);
            this.lblTlHours.Name = "lblTlHours";
            this.lblTlHours.Text = "합계";
            //
            // pnlChecklist
            //
            this.pnlChecklist.Controls.Add(this.clbChecklist);
            this.pnlChecklist.Controls.Add(this.flpCheckTools);
            this.pnlChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChecklist.Name = "pnlChecklist";
            this.pnlChecklist.TabIndex = 5;
            this.pnlChecklist.Visible = false;
            //
            // clbChecklist
            //
            this.clbChecklist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.clbChecklist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbChecklist.CheckOnClick = true;
            this.clbChecklist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbChecklist.Font = new System.Drawing.Font("맑은 고딕", 10.5F);
            this.clbChecklist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.clbChecklist.IntegralHeight = false;
            this.clbChecklist.Name = "clbChecklist";
            this.clbChecklist.TabIndex = 0;
            //
            // flpCheckTools
            //
            this.flpCheckTools.Controls.Add(this.txtCheckNew);
            this.flpCheckTools.Controls.Add(this.btnCheckAdd);
            this.flpCheckTools.Controls.Add(this.btnCheckRemove);
            this.flpCheckTools.Controls.Add(this.btnCheckTemplate);
            this.flpCheckTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpCheckTools.Name = "flpCheckTools";
            this.flpCheckTools.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.flpCheckTools.Size = new System.Drawing.Size(1148, 48);
            this.flpCheckTools.TabIndex = 1;
            //
            // txtCheckNew
            //
            this.txtCheckNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtCheckNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckNew.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtCheckNew.Margin = new System.Windows.Forms.Padding(0, 4, 8, 0);
            this.txtCheckNew.Name = "txtCheckNew";
            this.txtCheckNew.Size = new System.Drawing.Size(520, 25);
            this.txtCheckNew.TabIndex = 0;
            //
            // btnCheckAdd
            //
            this.btnCheckAdd.Accent = true;
            this.btnCheckAdd.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnCheckAdd.Name = "btnCheckAdd";
            this.btnCheckAdd.Size = new System.Drawing.Size(90, 32);
            this.btnCheckAdd.TabIndex = 1;
            this.btnCheckAdd.Text = "항목 추가";
            this.btnCheckAdd.Click += new System.EventHandler(this.btnCheckAdd_Click);
            //
            // btnCheckRemove
            //
            this.btnCheckRemove.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnCheckRemove.Name = "btnCheckRemove";
            this.btnCheckRemove.Size = new System.Drawing.Size(100, 32);
            this.btnCheckRemove.TabIndex = 2;
            this.btnCheckRemove.Text = "선택 항목 삭제";
            this.btnCheckRemove.Click += new System.EventHandler(this.btnCheckRemove_Click);
            //
            // btnCheckTemplate
            //
            this.btnCheckTemplate.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnCheckTemplate.Name = "btnCheckTemplate";
            this.btnCheckTemplate.Size = new System.Drawing.Size(150, 32);
            this.btnCheckTemplate.TabIndex = 3;
            this.btnCheckTemplate.Text = "유형 템플릿 불러오기";
            this.btnCheckTemplate.Click += new System.EventHandler(this.btnCheckTemplate_Click);
            //
            // pnlAttach
            //
            this.pnlAttach.Controls.Add(this.gridAttach);
            this.pnlAttach.Controls.Add(this.flpAttachTools);
            this.pnlAttach.Controls.Add(this.lblAttachHint);
            this.pnlAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttach.Name = "pnlAttach";
            this.pnlAttach.TabIndex = 6;
            this.pnlAttach.Visible = false;
            //
            // gridAttach
            //
            this.gridAttach.AllowDrop = true;
            this.gridAttach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAtName,
            this.colAtMode,
            this.colAtNote,
            this.colAtPath});
            this.gridAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttach.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridAttach.Name = "gridAttach";
            this.gridAttach.ReadOnly = false;
            this.gridAttach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridAttach.TabIndex = 1;
            this.gridAttach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAttach_CellDoubleClick);
            this.gridAttach.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAttach_CellEndEdit);
            this.gridAttach.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridAttach_DragDrop);
            this.gridAttach.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridAttach_DragEnter);
            //
            // colAtName
            //
            this.colAtName.HeaderText = "이름";
            this.colAtName.Name = "colAtName";
            this.colAtName.ReadOnly = true;
            this.colAtName.Width = 260;
            //
            // colAtMode
            //
            this.colAtMode.HeaderText = "방식";
            this.colAtMode.Name = "colAtMode";
            this.colAtMode.ReadOnly = true;
            this.colAtMode.Width = 70;
            //
            // colAtNote
            //
            this.colAtNote.HeaderText = "메모 (보고서 사진 설명) ✎";
            this.colAtNote.Name = "colAtNote";
            this.colAtNote.Width = 300;
            //
            // colAtPath
            //
            this.colAtPath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAtPath.HeaderText = "경로";
            this.colAtPath.Name = "colAtPath";
            this.colAtPath.ReadOnly = true;
            //
            // flpAttachTools
            //
            this.flpAttachTools.Controls.Add(this.btnAttachCopy);
            this.flpAttachTools.Controls.Add(this.btnAttachLink);
            this.flpAttachTools.Controls.Add(this.btnAttachFolder);
            this.flpAttachTools.Controls.Add(this.btnAttachPaste);
            this.flpAttachTools.Controls.Add(this.btnAttachOpen);
            this.flpAttachTools.Controls.Add(this.btnAttachRemove);
            this.flpAttachTools.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAttachTools.Name = "flpAttachTools";
            this.flpAttachTools.Size = new System.Drawing.Size(1148, 44);
            this.flpAttachTools.TabIndex = 0;
            //
            // btnAttachCopy
            //
            this.btnAttachCopy.Accent = true;
            this.btnAttachCopy.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAttachCopy.Name = "btnAttachCopy";
            this.btnAttachCopy.Size = new System.Drawing.Size(130, 34);
            this.btnAttachCopy.TabIndex = 0;
            this.btnAttachCopy.Text = "파일 복사 첨부";
            this.btnAttachCopy.Click += new System.EventHandler(this.btnAttachCopy_Click);
            //
            // btnAttachLink
            //
            this.btnAttachLink.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAttachLink.Name = "btnAttachLink";
            this.btnAttachLink.Size = new System.Drawing.Size(130, 34);
            this.btnAttachLink.TabIndex = 1;
            this.btnAttachLink.Text = "원본 파일 링크";
            this.btnAttachLink.Click += new System.EventHandler(this.btnAttachLink_Click);
            //
            // btnAttachFolder
            //
            this.btnAttachFolder.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAttachFolder.Name = "btnAttachFolder";
            this.btnAttachFolder.Size = new System.Drawing.Size(120, 34);
            this.btnAttachFolder.TabIndex = 2;
            this.btnAttachFolder.Text = "폴더 링크";
            this.btnAttachFolder.Click += new System.EventHandler(this.btnAttachFolder_Click);
            //
            // btnAttachPaste
            //
            this.btnAttachPaste.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAttachPaste.Name = "btnAttachPaste";
            this.btnAttachPaste.Size = new System.Drawing.Size(190, 34);
            this.btnAttachPaste.TabIndex = 3;
            this.btnAttachPaste.Text = "캡처 이미지 붙여넣기";
            this.btnAttachPaste.Click += new System.EventHandler(this.btnAttachPaste_Click);
            //
            // btnAttachOpen
            //
            this.btnAttachOpen.Margin = new System.Windows.Forms.Padding(24, 0, 8, 0);
            this.btnAttachOpen.Name = "btnAttachOpen";
            this.btnAttachOpen.Size = new System.Drawing.Size(80, 34);
            this.btnAttachOpen.TabIndex = 4;
            this.btnAttachOpen.Text = "열기";
            this.btnAttachOpen.Click += new System.EventHandler(this.btnAttachOpen_Click);
            //
            // btnAttachRemove
            //
            this.btnAttachRemove.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAttachRemove.Name = "btnAttachRemove";
            this.btnAttachRemove.Size = new System.Drawing.Size(110, 34);
            this.btnAttachRemove.TabIndex = 5;
            this.btnAttachRemove.Text = "목록에서 제거";
            this.btnAttachRemove.Click += new System.EventHandler(this.btnAttachRemove_Click);
            //
            // lblAttachHint
            //
            this.lblAttachHint.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAttachHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblAttachHint.Name = "lblAttachHint";
            this.lblAttachHint.Size = new System.Drawing.Size(1148, 28);
            this.lblAttachHint.TabIndex = 2;
            this.lblAttachHint.Text = "파일을 목록으로 끌어다 놓으면 업무 폴더로 복사됩니다. 사진(jpg·png)은 현장 보고서에 자동으로 들어가고, 메모가 사진 설명이 됩니다.";
            this.lblAttachHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlBottom
            //
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.pnlBottom.Controls.Add(this.flpBottomLeft);
            this.pnlBottom.Controls.Add(this.flpBottomRight);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 798);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(16, 12, 16, 10);
            this.pnlBottom.Size = new System.Drawing.Size(1180, 62);
            this.pnlBottom.TabIndex = 3;
            //
            // flpBottomLeft
            //
            this.flpBottomLeft.Controls.Add(this.btnSave);
            this.flpBottomLeft.Controls.Add(this.btnAdvance);
            this.flpBottomLeft.Controls.Add(this.btnStatus);
            this.flpBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBottomLeft.Name = "flpBottomLeft";
            this.flpBottomLeft.TabIndex = 0;
            this.flpBottomLeft.WrapContents = false;
            //
            // btnSave
            //
            this.btnSave.Accent = true;
            this.btnSave.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 38);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저장 (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnAdvance
            //
            this.btnAdvance.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnAdvance.Name = "btnAdvance";
            this.btnAdvance.Size = new System.Drawing.Size(220, 38);
            this.btnAdvance.TabIndex = 1;
            this.btnAdvance.Text = "▶ 다음 단계";
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            //
            // btnStatus
            //
            this.btnStatus.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(130, 38);
            this.btnStatus.TabIndex = 2;
            this.btnStatus.Text = "상태 변경 ▾";
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            //
            // flpBottomRight
            //
            this.flpBottomRight.Controls.Add(this.btnClose);
            this.flpBottomRight.Controls.Add(this.btnFolder);
            this.flpBottomRight.Controls.Add(this.btnNotion);
            this.flpBottomRight.Controls.Add(this.btnReport);
            this.flpBottomRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpBottomRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBottomRight.Name = "flpBottomRight";
            this.flpBottomRight.Size = new System.Drawing.Size(560, 40);
            this.flpBottomRight.TabIndex = 1;
            this.flpBottomRight.WrapContents = false;
            //
            // btnClose
            //
            this.btnClose.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 38);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // btnFolder
            //
            this.btnFolder.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(100, 38);
            this.btnFolder.TabIndex = 2;
            this.btnFolder.Text = "폴더 열기";
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            //
            // btnNotion
            //
            this.btnNotion.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnNotion.Name = "btnNotion";
            this.btnNotion.Size = new System.Drawing.Size(140, 38);
            this.btnNotion.TabIndex = 1;
            this.btnNotion.Text = "Notion MD 복사";
            this.btnNotion.Click += new System.EventHandler(this.btnNotion_Click);
            //
            // btnReport
            //
            this.btnReport.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(140, 38);
            this.btnReport.TabIndex = 0;
            this.btnReport.Text = "현장 조치 보고서";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            //
            // WorkItemForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1180, 860);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlSectionNav);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "WorkItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "업무 카드";
            this.pnlSummary.ResumeLayout(false);
            this.tblSummary.ResumeLayout(false);
            this.tblSummary.PerformLayout();
            this.pnlSectionNav.ResumeLayout(false);
            this.flpSections.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.tblSymptom.ResumeLayout(false);
            this.tblSymptom.PerformLayout();
            this.tblCause.ResumeLayout(false);
            this.tblCause.PerformLayout();
            this.tblAction.ResumeLayout(false);
            this.tblAction.PerformLayout();
            this.tblVerify.ResumeLayout(false);
            this.tblVerify.PerformLayout();
            this.flpRevisit.ResumeLayout(false);
            this.flpRevisit.PerformLayout();
            this.pnlTimeline.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTimeline)).EndInit();
            this.pnlTimelineEditor.ResumeLayout(false);
            this.pnlTimelineEditor.PerformLayout();
            this.pnlChecklist.ResumeLayout(false);
            this.flpCheckTools.ResumeLayout(false);
            this.flpCheckTools.PerformLayout();
            this.pnlAttach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAttach)).EndInit();
            this.flpAttachTools.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.flpBottomLeft.ResumeLayout(false);
            this.flpBottomRight.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.TableLayoutPanel tblSummary;
        private System.Windows.Forms.Label lblIdCap;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblTitleCap;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTypeCap;
        private TSWorkBench.Theme.DarkComboBox cboType;
        private System.Windows.Forms.Label lblStatusCap;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPriorityCap;
        private TSWorkBench.Theme.DarkComboBox cboPriority;
        private System.Windows.Forms.Label lblTagsCap;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Label lblCustomerCap;
        private TSWorkBench.Theme.DarkComboBox cboCustomer;
        private System.Windows.Forms.Label lblSiteCap;
        private TSWorkBench.Theme.DarkComboBox cboSite;
        private System.Windows.Forms.Label lblEquipmentCap;
        private TSWorkBench.Theme.DarkComboBox cboEquipment;
        private System.Windows.Forms.Label lblSystemCap;
        private TSWorkBench.Theme.DarkComboBox cboSystem;
        private System.Windows.Forms.Label lblReceivedCap;
        private TSWorkBench.Theme.DateBox dateReceived;
        private System.Windows.Forms.Label lblDueCap;
        private TSWorkBench.Theme.DateBox dateDue;
        private System.Windows.Forms.Label lblCompletedCap;
        private TSWorkBench.Theme.DateBox dateCompleted;
        private System.Windows.Forms.Label lblRequesterCap;
        private System.Windows.Forms.TextBox txtRequester;
        private System.Windows.Forms.Panel pnlSectionNav;
        private System.Windows.Forms.FlowLayoutPanel flpSections;
        private TSWorkBench.Theme.NavButton secSymptom;
        private TSWorkBench.Theme.NavButton secCause;
        private TSWorkBench.Theme.NavButton secAction;
        private TSWorkBench.Theme.NavButton secVerify;
        private TSWorkBench.Theme.NavButton secTimeline;
        private TSWorkBench.Theme.NavButton secChecklist;
        private TSWorkBench.Theme.NavButton secAttach;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TableLayoutPanel tblSymptom;
        private System.Windows.Forms.Label lblSymptomCap;
        private System.Windows.Forms.TextBox txtSymptom;
        private System.Windows.Forms.Label lblSymptomWhenCap;
        private System.Windows.Forms.TextBox txtSymptomWhen;
        private System.Windows.Forms.Label lblReproductionCap;
        private System.Windows.Forms.TextBox txtReproduction;
        private System.Windows.Forms.Label lblImpactCap;
        private System.Windows.Forms.TextBox txtImpact;
        private System.Windows.Forms.TableLayoutPanel tblCause;
        private System.Windows.Forms.Label lblCauseCap;
        private System.Windows.Forms.TextBox txtCause;
        private System.Windows.Forms.Label lblCauseEvidenceCap;
        private System.Windows.Forms.TextBox txtCauseEvidence;
        private System.Windows.Forms.TableLayoutPanel tblAction;
        private System.Windows.Forms.Label lblActionHwCap;
        private System.Windows.Forms.TextBox txtActionHw;
        private System.Windows.Forms.Label lblActionSwCap;
        private System.Windows.Forms.TextBox txtActionSw;
        private System.Windows.Forms.Label lblChangedFilesCap;
        private System.Windows.Forms.TextBox txtChangedFiles;
        private System.Windows.Forms.TableLayoutPanel tblVerify;
        private System.Windows.Forms.Label lblVerificationCap;
        private System.Windows.Forms.TextBox txtVerification;
        private System.Windows.Forms.Label lblPreventionCap;
        private System.Windows.Forms.TextBox txtPrevention;
        private System.Windows.Forms.Label lblCustomerNoteCap;
        private System.Windows.Forms.TextBox txtCustomerNote;
        private System.Windows.Forms.FlowLayoutPanel flpRevisit;
        private System.Windows.Forms.CheckBox chkRevisit;
        private TSWorkBench.Theme.DateBox dateRevisit;
        private System.Windows.Forms.Label lblRevisitHint;
        private System.Windows.Forms.Panel pnlTimeline;
        private TSWorkBench.Theme.DarkGrid gridTimeline;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTlStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTlEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTlKind;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTlHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTlText;
        private System.Windows.Forms.Panel pnlTimelineEditor;
        private System.Windows.Forms.Label lblTlStart;
        private TSWorkBench.Theme.DateBox dateTlStart;
        private System.Windows.Forms.Label lblTlEnd;
        private TSWorkBench.Theme.DateBox dateTlEnd;
        private System.Windows.Forms.Label lblTlKind;
        private TSWorkBench.Theme.DarkComboBox cboTlKind;
        private System.Windows.Forms.Label lblTlText;
        private System.Windows.Forms.TextBox txtTlText;
        private TSWorkBench.Theme.DarkButton btnTlStartNow;
        private TSWorkBench.Theme.DarkButton btnTlEndNow;
        private TSWorkBench.Theme.DarkButton btnTlAdd;
        private TSWorkBench.Theme.DarkButton btnTlUpdate;
        private TSWorkBench.Theme.DarkButton btnTlDelete;
        private System.Windows.Forms.Label lblTlHours;
        private System.Windows.Forms.Panel pnlChecklist;
        private System.Windows.Forms.CheckedListBox clbChecklist;
        private System.Windows.Forms.FlowLayoutPanel flpCheckTools;
        private System.Windows.Forms.TextBox txtCheckNew;
        private TSWorkBench.Theme.DarkButton btnCheckAdd;
        private TSWorkBench.Theme.DarkButton btnCheckRemove;
        private TSWorkBench.Theme.DarkButton btnCheckTemplate;
        private System.Windows.Forms.Panel pnlAttach;
        private TSWorkBench.Theme.DarkGrid gridAttach;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAtPath;
        private System.Windows.Forms.FlowLayoutPanel flpAttachTools;
        private TSWorkBench.Theme.DarkButton btnAttachCopy;
        private TSWorkBench.Theme.DarkButton btnAttachLink;
        private TSWorkBench.Theme.DarkButton btnAttachFolder;
        private TSWorkBench.Theme.DarkButton btnAttachPaste;
        private TSWorkBench.Theme.DarkButton btnAttachOpen;
        private TSWorkBench.Theme.DarkButton btnAttachRemove;
        private System.Windows.Forms.Label lblAttachHint;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.FlowLayoutPanel flpBottomLeft;
        private TSWorkBench.Theme.DarkButton btnSave;
        private TSWorkBench.Theme.DarkButton btnAdvance;
        private TSWorkBench.Theme.DarkButton btnStatus;
        private System.Windows.Forms.FlowLayoutPanel flpBottomRight;
        private TSWorkBench.Theme.DarkButton btnClose;
        private TSWorkBench.Theme.DarkButton btnFolder;
        private TSWorkBench.Theme.DarkButton btnNotion;
        private TSWorkBench.Theme.DarkButton btnReport;
    }
}
