using System;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>배포본을 어느 설비에 언제 설치했는지 기록한다.</summary>
    public partial class DeployDialog : DarkForm
    {
        private readonly Workspace ws;

        public DeployDialog()
        {
            InitializeComponent();
        }

        /// <param name="release">미리 고를 배포본 (없으면 null)</param>
        /// <param name="fromItem">업무 카드에서 열었으면 그 카드 — 위치와 ID를 채운다 (없으면 null)</param>
        public DeployDialog(Workspace ws, ReleaseRecord release, WorkItem fromItem) : this()
        {
            this.ws = ws;
            foreach (var r in ws.Releases.All.OrderBy(r => r.Program).ThenByDescending(r => r.ReleasedAt))
            {
                cboRelease.Items.Add(new Choice<ReleaseRecord>(r, r.Key + "  (" + r.ReleasedAt.ToString("yyyy-MM-dd") + ")"));
                if (ReferenceEquals(r, release))
                {
                    cboRelease.SelectedIndex = cboRelease.Items.Count - 1;
                }
            }

            if (cboRelease.SelectedIndex < 0 && cboRelease.Items.Count > 0)
            {
                cboRelease.SelectedIndex = 0;
            }

            UiHelpers.FillNames(cboCustomer, UiHelpers.CustomerNames(ws), fromItem?.Customer);
            UiHelpers.FillNames(cboSite, UiHelpers.SiteNames(ws), fromItem?.Site);
            UiHelpers.FillNames(cboEquipment, UiHelpers.EquipmentNames(ws), fromItem?.Equipment);
            txtWorkItem.Text = fromItem?.Id ?? "";
            dateDeployedAt.Value = DateTime.Now;
        }

        public ReleaseRecord Release { get; private set; }

        public Deployment Saved { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var choice = cboRelease.SelectedItem as Choice<ReleaseRecord>;
            if (choice == null)
            {
                MessageBox.Show(this, "먼저 배포 이력 화면에서 배포본을 등록하세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboEquipment.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "설치한 설비를 입력하세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboEquipment.Focus();
                return;
            }

            var deployment = new Deployment
            {
                Customer = cboCustomer.Text.Trim(),
                Site = cboSite.Text.Trim(),
                Equipment = cboEquipment.Text.Trim(),
                DeployedAt = dateDeployedAt.Value ?? DateTime.Now,
                WorkItemId = txtWorkItem.Text.Trim(),
                Note = txtNote.Text.Trim()
            };

            var release = choice.Value;
            release.Deployments.Add(deployment);
            if (deployment.WorkItemId.Length > 0 && !release.WorkItemIds.Contains(deployment.WorkItemId))
            {
                release.WorkItemIds.Add(deployment.WorkItemId);
            }

            try
            {
                ws.Releases.Save(release);
            }
            catch (Exception ex)
            {
                release.Deployments.Remove(deployment);
                ItemActions.ShowError(this, "설치 기록 저장", ex);
                return;
            }

            Release = release;
            Saved = deployment;
            DialogResult = DialogResult.OK;
        }
    }
}
