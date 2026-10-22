using System;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>연락을 받은 즉시 최소 정보로 업무 카드를 만든다.</summary>
    public partial class QuickAddForm : DarkForm
    {
        private readonly Workspace ws;

        public QuickAddForm()
        {
            InitializeComponent();
        }

        public QuickAddForm(Workspace ws) : this()
        {
            this.ws = ws;
            UiHelpers.FillNames(cboCustomer, UiHelpers.CustomerNames(ws), "");
            UiHelpers.FillNames(cboEquipment, UiHelpers.EquipmentNames(ws), "");
            UiHelpers.FillChoices(cboType, WorkType.FieldVisit);
            UiHelpers.FillChoices(cboPriority, Priority.Normal);
        }

        /// <summary>저장된 업무. OK일 때만 값이 있다.</summary>
        public WorkItem CreatedItem { get; private set; }

        /// <summary>"접수 후 상세 입력"을 눌렀는지.</summary>
        public bool OpenDetail { get; private set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Commit(false);
        }

        private void btnSaveOpen_Click(object sender, EventArgs e)
        {
            Commit(true);
        }

        private void Commit(bool openDetail)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show(this, "제목을 입력하세요. (예: 2라인 OCR 오판정 증가)", "빠른 접수", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Focus();
                return;
            }

            var item = ws.NewItem(UiHelpers.ChoiceValue(cboType, WorkType.FieldVisit), DateTime.Now);
            item.Title = txtTitle.Text.Trim();
            item.Customer = cboCustomer.Text.Trim();
            item.Equipment = cboEquipment.Text.Trim();
            item.Priority = UiHelpers.ChoiceValue(cboPriority, Priority.Normal);
            item.DueDate = dateDue.Value;
            item.Symptom = txtSymptom.Text.Trim();

            try
            {
                ws.Save(item);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "저장", ex);
                return;
            }

            CreatedItem = item;
            OpenDetail = openDetail;
            DialogResult = DialogResult.OK;
        }
    }
}
