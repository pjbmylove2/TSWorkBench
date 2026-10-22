namespace TSWorkBench.Forms
{
    partial class QuickAddForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new TSWorkBench.Theme.DarkComboBox();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.cboEquipment = new TSWorkBench.Theme.DarkComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new TSWorkBench.Theme.DarkComboBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.cboPriority = new TSWorkBench.Theme.DarkComboBox();
            this.lblDue = new System.Windows.Forms.Label();
            this.dateDue = new TSWorkBench.Theme.DateBox();
            this.lblSymptom = new System.Windows.Forms.Label();
            this.txtSymptom = new System.Windows.Forms.TextBox();
            this.pnlButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new TSWorkBench.Theme.DarkButton();
            this.btnSaveOpen = new TSWorkBench.Theme.DarkButton();
            this.btnSave = new TSWorkBench.Theme.DarkButton();
            this.lblHint = new System.Windows.Forms.Label();
            this.tbl.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tbl
            //
            this.tbl.ColumnCount = 2;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Controls.Add(this.lblTitle, 0, 0);
            this.tbl.Controls.Add(this.txtTitle, 1, 0);
            this.tbl.Controls.Add(this.lblCustomer, 0, 1);
            this.tbl.Controls.Add(this.cboCustomer, 1, 1);
            this.tbl.Controls.Add(this.lblEquipment, 0, 2);
            this.tbl.Controls.Add(this.cboEquipment, 1, 2);
            this.tbl.Controls.Add(this.lblType, 0, 3);
            this.tbl.Controls.Add(this.cboType, 1, 3);
            this.tbl.Controls.Add(this.lblPriority, 0, 4);
            this.tbl.Controls.Add(this.cboPriority, 1, 4);
            this.tbl.Controls.Add(this.lblDue, 0, 5);
            this.tbl.Controls.Add(this.dateDue, 1, 5);
            this.tbl.Controls.Add(this.lblSymptom, 0, 6);
            this.tbl.Controls.Add(this.txtSymptom, 1, 6);
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Location = new System.Drawing.Point(20, 52);
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 7;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Size = new System.Drawing.Size(560, 336);
            this.tbl.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "제목 *";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTitle
            //
            this.txtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.TabIndex = 1;
            //
            // lblCustomer
            //
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "고객사";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboCustomer
            //
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.TabIndex = 3;
            //
            // lblEquipment
            //
            this.lblEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEquipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.TabIndex = 4;
            this.lblEquipment.Text = "설비";
            this.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboEquipment
            //
            this.cboEquipment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEquipment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEquipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEquipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboEquipment.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cboEquipment.Name = "cboEquipment";
            this.cboEquipment.TabIndex = 5;
            //
            // lblType
            //
            this.lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblType.Name = "lblType";
            this.lblType.TabIndex = 6;
            this.lblType.Text = "유형";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboType
            //
            this.cboType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cboType.Name = "cboType";
            this.cboType.TabIndex = 7;
            //
            // lblPriority
            //
            this.lblPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.TabIndex = 8;
            this.lblPriority.Text = "우선순위";
            this.lblPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboPriority
            //
            this.cboPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.cboPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPriority.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.cboPriority.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cboPriority.Name = "cboPriority";
            this.cboPriority.TabIndex = 9;
            //
            // lblDue
            //
            this.lblDue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDue.Name = "lblDue";
            this.lblDue.TabIndex = 10;
            this.lblDue.Text = "기한";
            this.lblDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dateDue
            //
            this.dateDue.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dateDue.Name = "dateDue";
            this.dateDue.Size = new System.Drawing.Size(160, 25);
            this.dateDue.TabIndex = 11;
            //
            // lblSymptom
            //
            this.lblSymptom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSymptom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSymptom.Name = "lblSymptom";
            this.lblSymptom.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblSymptom.TabIndex = 12;
            this.lblSymptom.Text = "현상\r\n(들은 그대로)";
            //
            // txtSymptom
            //
            this.txtSymptom.AcceptsReturn = true;
            this.txtSymptom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtSymptom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSymptom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSymptom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtSymptom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.txtSymptom.Multiline = true;
            this.txtSymptom.Name = "txtSymptom";
            this.txtSymptom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSymptom.TabIndex = 13;
            //
            // pnlButtons
            //
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSaveOpen);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlButtons.Location = new System.Drawing.Point(20, 388);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlButtons.Size = new System.Drawing.Size(560, 56);
            this.pnlButtons.TabIndex = 1;
            //
            // btnCancel
            //
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 36);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "취소";
            //
            // btnSaveOpen
            //
            this.btnSaveOpen.Name = "btnSaveOpen";
            this.btnSaveOpen.Size = new System.Drawing.Size(170, 36);
            this.btnSaveOpen.TabIndex = 1;
            this.btnSaveOpen.Text = "접수 후 상세 입력";
            this.btnSaveOpen.Click += new System.EventHandler(this.btnSaveOpen_Click);
            //
            // btnSave
            //
            this.btnSave.Accent = true;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "접수";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // lblHint
            //
            this.lblHint.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHint.Location = new System.Drawing.Point(20, 16);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(560, 36);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "전화·메일을 받자마자 30초 안에 기록합니다. 원인·조치는 나중에 업무 카드에서 채웁니다.";
            //
            // QuickAddForm
            //
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.tbl);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.lblHint);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickAddForm";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "빠른 접수";
            this.tbl.ResumeLayout(false);
            this.tbl.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblCustomer;
        private TSWorkBench.Theme.DarkComboBox cboCustomer;
        private System.Windows.Forms.Label lblEquipment;
        private TSWorkBench.Theme.DarkComboBox cboEquipment;
        private System.Windows.Forms.Label lblType;
        private TSWorkBench.Theme.DarkComboBox cboType;
        private System.Windows.Forms.Label lblPriority;
        private TSWorkBench.Theme.DarkComboBox cboPriority;
        private System.Windows.Forms.Label lblDue;
        private TSWorkBench.Theme.DateBox dateDue;
        private System.Windows.Forms.Label lblSymptom;
        private System.Windows.Forms.TextBox txtSymptom;
        private System.Windows.Forms.FlowLayoutPanel pnlButtons;
        private TSWorkBench.Theme.DarkButton btnCancel;
        private TSWorkBench.Theme.DarkButton btnSaveOpen;
        private TSWorkBench.Theme.DarkButton btnSave;
        private System.Windows.Forms.Label lblHint;
    }
}
