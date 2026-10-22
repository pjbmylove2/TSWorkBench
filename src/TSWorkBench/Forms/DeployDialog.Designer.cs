namespace TSWorkBench.Forms
{
    partial class DeployDialog
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
            this.lblRelease = new System.Windows.Forms.Label();
            this.cboRelease = new TSWorkBench.Theme.DarkComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomer = new TSWorkBench.Theme.DarkComboBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.cboSite = new TSWorkBench.Theme.DarkComboBox();
            this.lblEquipment = new System.Windows.Forms.Label();
            this.cboEquipment = new TSWorkBench.Theme.DarkComboBox();
            this.lblDeployedAt = new System.Windows.Forms.Label();
            this.dateDeployedAt = new TSWorkBench.Theme.DateBox();
            this.lblWorkItem = new System.Windows.Forms.Label();
            this.txtWorkItem = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.flpButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new TSWorkBench.Theme.DarkButton();
            this.btnOk = new TSWorkBench.Theme.DarkButton();
            this.tbl.SuspendLayout();
            this.flpButtons.SuspendLayout();
            this.SuspendLayout();
            //
            // tbl
            //
            this.tbl.ColumnCount = 2;
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tbl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Controls.Add(this.lblRelease, 0, 0);
            this.tbl.Controls.Add(this.cboRelease, 1, 0);
            this.tbl.Controls.Add(this.lblCustomer, 0, 1);
            this.tbl.Controls.Add(this.cboCustomer, 1, 1);
            this.tbl.Controls.Add(this.lblSite, 0, 2);
            this.tbl.Controls.Add(this.cboSite, 1, 2);
            this.tbl.Controls.Add(this.lblEquipment, 0, 3);
            this.tbl.Controls.Add(this.cboEquipment, 1, 3);
            this.tbl.Controls.Add(this.lblDeployedAt, 0, 4);
            this.tbl.Controls.Add(this.dateDeployedAt, 1, 4);
            this.tbl.Controls.Add(this.lblWorkItem, 0, 5);
            this.tbl.Controls.Add(this.txtWorkItem, 1, 5);
            this.tbl.Controls.Add(this.lblNote, 0, 6);
            this.tbl.Controls.Add(this.txtNote, 1, 6);
            this.tbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl.Location = new System.Drawing.Point(20, 16);
            this.tbl.Name = "tbl";
            this.tbl.RowCount = 7;
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tbl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl.Size = new System.Drawing.Size(600, 344);
            this.tbl.TabIndex = 0;
            //
            // lblRelease
            //
            this.lblRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRelease.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblRelease.Name = "lblRelease";
            this.lblRelease.Text = "배포본 *";
            this.lblRelease.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboRelease
            //
            this.cboRelease.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRelease.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cboRelease.Name = "cboRelease";
            this.cboRelease.TabIndex = 0;
            //
            // lblCustomer
            //
            this.lblCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Text = "고객사";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboCustomer
            //
            this.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboCustomer.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.TabIndex = 1;
            //
            // lblSite
            //
            this.lblSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSite.Name = "lblSite";
            this.lblSite.Text = "사이트/라인";
            this.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboSite
            //
            this.cboSite.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSite.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSite.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cboSite.Name = "cboSite";
            this.cboSite.TabIndex = 2;
            //
            // lblEquipment
            //
            this.lblEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEquipment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblEquipment.Name = "lblEquipment";
            this.lblEquipment.Text = "설비";
            this.lblEquipment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cboEquipment
            //
            this.cboEquipment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEquipment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboEquipment.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.cboEquipment.Name = "cboEquipment";
            this.cboEquipment.TabIndex = 3;
            //
            // lblDeployedAt
            //
            this.lblDeployedAt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeployedAt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblDeployedAt.Name = "lblDeployedAt";
            this.lblDeployedAt.Text = "설치 일시";
            this.lblDeployedAt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // dateDeployedAt
            //
            this.dateDeployedAt.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.dateDeployedAt.Name = "dateDeployedAt";
            this.dateDeployedAt.ShowTime = true;
            this.dateDeployedAt.Size = new System.Drawing.Size(190, 25);
            this.dateDeployedAt.TabIndex = 4;
            //
            // lblWorkItem
            //
            this.lblWorkItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWorkItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblWorkItem.Name = "lblWorkItem";
            this.lblWorkItem.Text = "관련 업무 ID";
            this.lblWorkItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtWorkItem
            //
            this.txtWorkItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtWorkItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorkItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtWorkItem.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtWorkItem.Name = "txtWorkItem";
            this.txtWorkItem.TabIndex = 5;
            //
            // lblNote
            //
            this.lblNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNote.Name = "lblNote";
            this.lblNote.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.lblNote.Text = "메모";
            //
            // txtNote
            //
            this.txtNote.AcceptsReturn = true;
            this.txtNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(58)))));
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 7, 3, 3);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNote.TabIndex = 6;
            //
            // flpButtons
            //
            this.flpButtons.Controls.Add(this.btnCancel);
            this.flpButtons.Controls.Add(this.btnOk);
            this.flpButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpButtons.Name = "flpButtons";
            this.flpButtons.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flpButtons.Size = new System.Drawing.Size(600, 58);
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
            this.btnOk.Size = new System.Drawing.Size(160, 38);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "설치 기록 저장";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // DeployDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(640, 430);
            this.Controls.Add(this.tbl);
            this.Controls.Add(this.flpButtons);
            this.Font = new System.Drawing.Font("맑은 고딕", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeployDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 16, 20, 12);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "설비에 설치 기록";
            this.tbl.ResumeLayout(false);
            this.tbl.PerformLayout();
            this.flpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl;
        private System.Windows.Forms.Label lblRelease;
        private TSWorkBench.Theme.DarkComboBox cboRelease;
        private System.Windows.Forms.Label lblCustomer;
        private TSWorkBench.Theme.DarkComboBox cboCustomer;
        private System.Windows.Forms.Label lblSite;
        private TSWorkBench.Theme.DarkComboBox cboSite;
        private System.Windows.Forms.Label lblEquipment;
        private TSWorkBench.Theme.DarkComboBox cboEquipment;
        private System.Windows.Forms.Label lblDeployedAt;
        private TSWorkBench.Theme.DateBox dateDeployedAt;
        private System.Windows.Forms.Label lblWorkItem;
        private System.Windows.Forms.TextBox txtWorkItem;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.FlowLayoutPanel flpButtons;
        private TSWorkBench.Theme.DarkButton btnCancel;
        private TSWorkBench.Theme.DarkButton btnOk;
    }
}
