using System;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>배포본 등록: 빌드 폴더로 보관소에 패키지를 만들거나, 이미 있는 배포 폴더를 기록만 한다.</summary>
    public partial class ReleaseDialog : DarkForm
    {
        private readonly Workspace ws;

        public ReleaseDialog()
        {
            InitializeComponent();
        }

        public ReleaseDialog(Workspace ws, string program) : this()
        {
            this.ws = ws;
            UiHelpers.FillNames(cboProgram, UiHelpers.ProgramNames(ws), program ?? "");
            var store = ws.Settings.ReleaseStore;
            lblHint.Text = string.IsNullOrWhiteSpace(store)
                ? "배포본 보관소가 지정되지 않았습니다. 설정 › 배포본 보관소에서 공유 폴더(예: \\\\NAS\\Releases)를 먼저 지정하면 패키지를 만들 수 있습니다."
                : "보관소: " + store + "\r\n패키지 = zip(빌드 폴더) + manual(매뉴얼 폴더) + RELEASE_NOTES.md + SHA256SUMS.txt. 같은 버전은 덮어쓰지 않습니다.";
            if (string.IsNullOrWhiteSpace(store))
            {
                rbRegister.Checked = true;
            }

            ApplyMode();
        }

        /// <summary>저장된 배포 기록. OK일 때만 값이 있다.</summary>
        public ReleaseRecord Saved { get; private set; }

        private void ApplyMode()
        {
            var package = rbPackage.Checked;
            pnlBuild.Enabled = package;
            pnlManual.Enabled = package;
            pnlPackage.Enabled = !package;
            btnOk.Text = package ? "패키지 만들기" : "등록";
        }

        private void mode_CheckedChanged(object sender, EventArgs e)
        {
            ApplyMode();
        }

        private void txtVersion_TextChanged(object sender, EventArgs e)
        {
            var version = txtVersion.Text.Trim();
            txtTag.Text = version.Length == 0 ? "" : "v" + version;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            PickFolder(txtBuild, "빌드 결과 폴더 (예: src\\프로그램\\bin\\Release)");
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            PickFolder(txtManual, "매뉴얼 폴더 (예: 저장소의 docs — 이미지 포함)");
        }

        private void btnPackage_Click(object sender, EventArgs e)
        {
            PickFolder(txtPackage, "이미 만들어 둔 배포본 폴더");
        }

        private void PickFolder(TextBox target, string description)
        {
            using (var dialog = new FolderBrowserDialog { Description = description, SelectedPath = target.Text })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    target.Text = dialog.SelectedPath;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            var program = cboProgram.Text.Trim();
            var version = txtVersion.Text.Trim();
            if (program.Length == 0 || version.Length == 0)
            {
                MessageBox.Show(this, "프로그램과 버전을 입력하세요.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ws.Releases.Find(program, version) != null)
            {
                MessageBox.Show(this, program + " v" + version + "은(는) 이미 등록되어 있습니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ReleaseRecord record;
            try
            {
                Cursor = Cursors.WaitCursor;
                if (rbPackage.Checked)
                {
                    record = ReleasePackager.Create(ws.Settings.ReleaseStore, new PackageRequest
                    {
                        Program = program,
                        Version = version,
                        BuildFolder = txtBuild.Text.Trim(),
                        ManualFolder = txtManual.Text.Trim(),
                        Notes = txtNotes.Text
                    }, DateTime.Now);
                }
                else
                {
                    record = new ReleaseRecord
                    {
                        Program = program,
                        Version = version,
                        ReleasedAt = DateTime.Now,
                        PackagePath = txtPackage.Text.Trim(),
                        Notes = txtNotes.Text
                    };
                }

                record.Tag = txtTag.Text.Trim();
                record.Commit = txtCommit.Text.Trim();
                record.WorkItemIds = txtWorkItems.Text.Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToList();
                ws.Releases.Save(record);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "배포본 등록", ex);
                return;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            Saved = record;
            if (rbPackage.Checked && record.Tag.Length > 0)
            {
                var command = ReleasePackager.GitTagCommand(record);
                Clipboard.SetText(command);
                MessageBox.Show(this, "배포본을 만들었습니다.\n" + record.PackagePath
                                      + "\n\n소스 저장소에서 아래 명령으로 태그를 남기세요 (클립보드에 복사됨):\n\n" + command,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
