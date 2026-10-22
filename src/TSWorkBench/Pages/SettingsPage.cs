using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Models;
using TSWorkBench.Storage;

namespace TSWorkBench.Pages
{
    /// <summary>사용자 정보, 데이터 폴더, 기준 정보(고객사·설비 …), 유형별 체크리스트 템플릿.</summary>
    public partial class SettingsPage : PageBase
    {
        private int shownMasterKind = -1;
        private Choice<WorkType> shownChecklistType;

        public SettingsPage()
        {
            InitializeComponent();
        }

        public override string HelpTopic => "3.9";

        public override string PageTitle => "설정 · 기준 정보";

        public override string PageSubtitle => "다른 회사로 옮길 때는 데이터 폴더를 새로 만들고 여기서 회사·기준 정보만 바꾸면 됩니다";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            foreach (var choice in Labels.Choices<WorkType>())
            {
                cboChecklistType.Items.Add(choice);
            }
        }

        public override void RefreshData()
        {
            var s = Ws.Settings;
            txtDataFolder.Text = Ws.Root;
            txtUser.Text = s.UserName;
            txtDepartment.Text = s.Department;
            txtCompany.Text = s.Company;
            txtPrefix.Text = s.IdPrefix;
            numFollowUp.Value = Math.Max(numFollowUp.Minimum, Math.Min(numFollowUp.Maximum, s.FollowUpDays));
            txtReleaseStore.Text = s.ReleaseStore;
            txtBackupFolder.Text = s.BackupFolder;
            numBackupKeep.Value = Math.Max(numBackupKeep.Minimum, Math.Min(numBackupKeep.Maximum, s.BackupKeepCount));

            shownMasterKind = -1;
            shownChecklistType = null;
            if (cboMasterKind.SelectedIndex == 0)
            {
                ShowMasters();
            }
            else
            {
                cboMasterKind.SelectedIndex = 0;
            }

            if (cboChecklistType.SelectedIndex == 0)
            {
                ShowChecklist();
            }
            else
            {
                cboChecklistType.SelectedIndex = 0;
            }
        }

        private List<MasterEntry> MasterList(int kind)
        {
            switch (kind)
            {
                case 0: return Ws.Masters.Customers;
                case 1: return Ws.Masters.Sites;
                case 2: return Ws.Masters.Equipments;
                default: return Ws.Masters.Systems;
            }
        }

        /// <summary>그리드에서 고친 내용을 메모리의 기준 정보 목록에 되돌려 놓는다.</summary>
        private void KeepMasterEdits()
        {
            if (shownMasterKind < 0)
            {
                return;
            }

            gridMasters.EndEdit();
            var list = MasterList(shownMasterKind);
            list.Clear();
            foreach (DataGridViewRow row in gridMasters.Rows)
            {
                var name = Convert.ToString(row.Cells[colMasterName.Index].Value)?.Trim();
                if (!row.IsNewRow && !string.IsNullOrEmpty(name))
                {
                    list.Add(new MasterEntry { Name = name, Keywords = Convert.ToString(row.Cells[colMasterKeywords.Index].Value)?.Trim() ?? "" });
                }
            }
        }

        private void ShowMasters()
        {
            gridMasters.Rows.Clear();
            shownMasterKind = cboMasterKind.SelectedIndex;
            foreach (var entry in MasterList(shownMasterKind))
            {
                gridMasters.Rows.Add(entry.Name, entry.Keywords);
            }
        }

        private void KeepChecklistEdits()
        {
            if (shownChecklistType == null)
            {
                return;
            }

            Ws.Masters.Checklists[shownChecklistType.Value] = txtChecklist.Lines
                .Select(l => l.Trim()).Where(l => l.Length > 0).ToList();
        }

        private void ShowChecklist()
        {
            shownChecklistType = cboChecklistType.SelectedItem as Choice<WorkType>;
            txtChecklist.Text = shownChecklistType == null ? "" : string.Join("\r\n", Ws.Masters.ChecklistFor(shownChecklistType.Value));
        }

        private void cboMasterKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeepMasterEdits();
            ShowMasters();
        }

        private void cboChecklistType_SelectedIndexChanged(object sender, EventArgs e)
        {
            KeepChecklistEdits();
            ShowChecklist();
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var prefix = txtPrefix.Text.Trim();
            if (prefix.Length == 0 || prefix.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0 || prefix.Contains("-"))
            {
                MessageBox.Show(this, "ID 앞머리는 비울 수 없고 '-'나 파일 이름에 못 쓰는 글자를 넣을 수 없습니다.", "설정", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var s = Ws.Settings;
            s.UserName = txtUser.Text.Trim();
            s.Department = txtDepartment.Text.Trim();
            s.Company = txtCompany.Text.Trim();
            s.IdPrefix = prefix;
            s.FollowUpDays = (int)numFollowUp.Value;
            s.ReleaseStore = txtReleaseStore.Text.Trim();
            s.BackupFolder = txtBackupFolder.Text.Trim();
            s.BackupKeepCount = (int)numBackupKeep.Value;
            SaveAll(Ws.SaveSettings, "기본 정보를 저장했습니다.");
        }

        private void btnSaveMasters_Click(object sender, EventArgs e)
        {
            KeepMasterEdits();
            SaveAll(Ws.SaveMasters, "기준 정보를 저장했습니다.");
        }

        private void btnSaveChecklist_Click(object sender, EventArgs e)
        {
            KeepChecklistEdits();
            SaveAll(Ws.SaveMasters, "체크리스트 템플릿을 저장했습니다. 새로 만드는 업무부터 적용됩니다.");
        }

        private void SaveAll(Action save, string message)
        {
            try
            {
                save();
                Host.RefreshCurrentPage();
                MessageBox.Show(this, message, "설정", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "저장", ex);
            }
        }

        private void btnChangeFolder_Click(object sender, EventArgs e)
        {
            var folder = Program.AskDataFolder(this, Ws.Root);
            if (folder == null || string.Equals(folder, Ws.Root, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            try
            {
                Host.ReloadWorkspace(folder);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "데이터 폴더 열기", ex);
            }
        }

        private void btnOpenData_Click(object sender, EventArgs e)
        {
            ItemActions.OpenPath(Ws.Root);
        }

        private void btnReleaseStore_Click(object sender, EventArgs e)
        {
            PickFolder(txtReleaseStore, "배포본 보관소 (공유 폴더 권장)");
        }

        private void btnBackupFolder_Click(object sender, EventArgs e)
        {
            PickFolder(txtBackupFolder, "자동 백업 폴더 (데이터와 다른 디스크·공유 폴더 권장)");
        }

        private void PickFolder(TextBox target, string description)
        {
            var folder = FolderPicker.Pick(this, description, target.Text);
            if (folder != null)
            {
                target.Text = folder;
            }
        }

        private void btnBackupNow_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var path = BackupService.RunNow(Ws, DateTime.Now);
                MessageBox.Show(this, "백업했습니다.\n" + path, "백업", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "백업", ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnOpenTemplates_Click(object sender, EventArgs e)
        {
            ItemActions.OpenPath(Ws.TemplatesDir);
        }
    }
}
