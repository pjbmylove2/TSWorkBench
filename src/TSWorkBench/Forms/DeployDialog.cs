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
        private readonly Deployment editing;
        private readonly ReleaseRecord owner;

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

        /// <summary>이미 있는 설치 기록을 고친다. 버전을 바꾸면 그 버전의 기록으로 옮긴다.</summary>
        public DeployDialog(Workspace ws, Deployment editing, ReleaseRecord owner) : this(ws, owner, null)
        {
            this.editing = editing;
            this.owner = owner;
            Text = "설치 기록 고치기";
            btnOk.Text = "고친 내용 저장";
            cboCustomer.Text = editing.Customer;
            cboSite.Text = editing.Site;
            cboEquipment.Text = editing.Equipment;
            dateDeployedAt.Value = editing.DeployedAt;
            txtWorkItem.Text = editing.WorkItemId;
            txtNote.Text = editing.Note;
        }

        public ReleaseRecord Release { get; private set; }

        public Deployment Saved { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var choice = cboRelease.SelectedItem as Choice<ReleaseRecord>;
            if (choice == null)
            {
                MessageBox.Show(this, "먼저 프로그램 · 배포 화면에서 ① 프로그램 등록 또는 ② 새 버전 배포로 버전을 만드세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if ((cboCustomer.Text + cboSite.Text + cboEquipment.Text).Trim().Length == 0)
            {
                MessageBox.Show(this, "설치한 곳(고객사·사이트·설비 중 하나 이상)을 입력하세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Note = txtNote.Text.Trim(),
                RolledBack = editing?.RolledBack ?? false
            };

            var release = choice.Value;
            if (editing != null)
            {
                try
                {
                    Replace(release, deployment);
                }
                catch (Exception ex)
                {
                    // 두 버전 파일 중 하나만 저장됐을 수 있으니 파일 내용으로 다시 읽고 닫는다 (부른 화면이 새로 고친다).
                    ws.Releases.LoadAll();
                    ItemActions.ShowError(this, "설치 기록 저장", ex);
                    DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            else
            {
                release.Deployments.Add(deployment);
                AddWorkItemId(release, deployment.WorkItemId);
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
            }

            Release = release;
            Saved = deployment;
            DialogResult = DialogResult.OK;
        }

        private void Replace(ReleaseRecord release, Deployment deployment)
        {
            var index = owner.Deployments.IndexOf(editing);
            if (ReferenceEquals(release, owner) && index >= 0)
            {
                owner.Deployments[index] = deployment;
            }
            else
            {
                owner.Deployments.Remove(editing);
                ws.Releases.Save(owner);
                release.Deployments.Add(deployment);
            }

            AddWorkItemId(release, deployment.WorkItemId);
            ws.Releases.Save(release);
        }

        private static void AddWorkItemId(ReleaseRecord release, string id)
        {
            if (id.Length > 0 && !release.WorkItemIds.Contains(id))
            {
                release.WorkItemIds.Add(id);
            }
        }
    }
}
