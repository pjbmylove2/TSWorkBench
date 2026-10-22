using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>
    /// ① 프로그램 등록. 코드 폴더만 고르면 Git 설정·기준 버전·NAS 백업을 대신 한다.
    /// 이미 등록된 프로그램을 넘기면 폴더·백업 위치만 고치는 화면이 된다.
    /// </summary>
    public partial class ProgramSetupDialog : DarkForm
    {
        private readonly Workspace ws;
        private readonly ProgramInfo editing;

        public ProgramSetupDialog()
        {
            InitializeComponent();
        }

        public ProgramSetupDialog(Workspace ws, ProgramInfo editing) : this()
        {
            this.ws = ws;
            this.editing = editing;
            dateBase.Value = DateTime.Today;
            if (editing != null)
            {
                Text = "프로그램 설정 고치기 — " + editing.Name;
                txtName.Text = editing.Name;
                txtName.ReadOnly = true;
                txtCode.Text = editing.CodeFolder;
                txtBuild.Text = editing.BuildFolder;
                txtManual.Text = editing.ManualFolder;
                txtRemote.Text = editing.GitRemote;
                flpBase.Enabled = false;
                gridSites.Enabled = false;
                btnOk.Text = "저장";
                lblHint.Text = "폴더 위치가 바뀌었거나 NAS 백업 위치를 바꿀 때 고칩니다. 버전 기록은 그대로 남습니다.";
            }
        }

        private void Log(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            if (editing != null || name.Length == 0)
            {
                return;
            }

            if (txtCode.Text.Trim().Length == 0 && ws.Settings.SourceRoot.Length > 0)
            {
                txtCode.Text = Path.Combine(ws.Settings.SourceRoot, name);
                FillFromCodeFolder();
            }

            if (txtRemote.Text.Trim().Length == 0 && ws.GitStore.Length > 0)
            {
                txtRemote.Text = Path.Combine(ws.GitStore, name + ".git");
            }
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            FillFromCodeFolder();
        }

        /// <summary>코드 폴더를 고르면 빌드 결과·매뉴얼 폴더를 찾아 채우고, Git 상태를 알려 준다.</summary>
        private void FillFromCodeFolder()
        {
            var code = txtCode.Text.Trim();
            if (!Directory.Exists(code))
            {
                return;
            }

            if (txtBuild.Text.Trim().Length == 0)
            {
                txtBuild.Text = FindBuildFolder(code) ?? "";
            }

            if (txtManual.Text.Trim().Length == 0 && Directory.Exists(Path.Combine(code, "docs")))
            {
                txtManual.Text = Path.Combine(code, "docs");
            }

            if (editing == null)
            {
                var git = new GitRunner(code, ws.Settings.UserName);
                if (git.IsRepo && git.HasCommits)
                {
                    var tags = git.Tags().Where(t => VersionUtil.IsValid(t.Tag)).Select(t => t.Tag).ToList();
                    Log("이미 Git 저장소입니다. 버전 이름표 " + tags.Count + "개" + (tags.Count > 0 ? " (" + string.Join(", ", tags) + ")" : "")
                        + "를 그대로 불러옵니다. 기준 버전 칸은 이름표가 하나도 없을 때만 씁니다.");
                }
                else
                {
                    Log("Git 저장소가 아닙니다. 지금 코드를 기준 버전으로 기록합니다.");
                }
            }
        }

        /// <summary>bin\Release 중 exe가 있고 가장 최근에 빌드된 폴더.</summary>
        public static string FindBuildFolder(string code)
        {
            try
            {
                return Directory.GetDirectories(code, "Release", SearchOption.AllDirectories)
                    .Where(d => string.Equals(Path.GetFileName(Path.GetDirectoryName(d)), "bin", StringComparison.OrdinalIgnoreCase))
                    .Where(d => Directory.GetFiles(d, "*.exe").Any())
                    .OrderByDescending(Directory.GetLastWriteTime)
                    .FirstOrDefault();
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            Pick(txtCode, "코드 폴더 (.sln이 있는 폴더)");
            FillFromCodeFolder();
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            Pick(txtBuild, "Release 빌드 결과 폴더 (예: 프로젝트\\bin\\Release)");
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            Pick(txtManual, "매뉴얼 폴더 (예: docs)");
        }

        private void btnRemote_Click(object sender, EventArgs e)
        {
            var folder = FolderPicker.Pick(this, "NAS 코드 백업 폴더 (그 안에 프로그램이름.git이 만들어집니다)", ws.GitStore);
            if (folder != null)
            {
                txtRemote.Text = Path.Combine(folder, txtName.Text.Trim().Length > 0 ? txtName.Text.Trim() + ".git" : "프로그램.git");
            }
        }

        private void Pick(TextBox target, string title)
        {
            var folder = FolderPicker.Pick(this, title, target.Text.Trim().Length > 0 ? target.Text : txtCode.Text);
            if (folder != null)
            {
                target.Text = folder;
            }
        }

        private List<Deployment> ReadSites()
        {
            var sites = new List<Deployment>();
            foreach (DataGridViewRow row in gridSites.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                var d = new Deployment
                {
                    Customer = Convert.ToString(row.Cells[colCustomer.Index].Value)?.Trim() ?? "",
                    Site = Convert.ToString(row.Cells[colSite.Index].Value)?.Trim() ?? "",
                    Equipment = Convert.ToString(row.Cells[colEquipment.Index].Value)?.Trim() ?? "",
                    Note = "기준본 사용 중"
                };
                if (d.Customer.Length + d.Site.Length + d.Equipment.Length > 0)
                {
                    sites.Add(d);
                }
            }

            return sites;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            gridSites.EndEdit();
            var program = new ProgramInfo
            {
                Name = txtName.Text.Trim(),
                CodeFolder = txtCode.Text.Trim(),
                BuildFolder = txtBuild.Text.Trim(),
                ManualFolder = txtManual.Text.Trim(),
                GitRemote = txtRemote.Text.Trim()
            };

            if (editing != null)
            {
                SaveEdit(program);
                return;
            }

            var sites = ReadSites();
            var baseVersion = txtBaseVersion.Text.Trim();
            var baseDate = dateBase.Value ?? DateTime.Today;
            btnOk.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var progress = new Progress<string>(Log);
                var service = new ProgramService(ws);
                var current = await Task.Run(() => service.Register(program, baseVersion, baseDate, sites, progress));
                ws.Settings.SourceRoot = Path.GetDirectoryName(program.CodeFolder.TrimEnd('\\')) ?? ws.Settings.SourceRoot;
                ws.SaveSettings();
                MessageBox.Show(this, current == null
                        ? program.Name + "을(를) 빈 코드 폴더로 등록했습니다.\n\n다음: '과거 버전 가져오기'에서 버전별 zip·폴더를 모두 넣으세요."
                        : program.Name + " 등록을 마쳤습니다. 현재 버전 v" + current
                          + "\n\n이제 VS2022에서 코드를 고치고 커밋한 뒤, '② 새 버전 배포'를 누르면 됩니다.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log("✖ " + ex.Message);
                ItemActions.ShowError(this, "프로그램 등록", ex);
                btnOk.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void SaveEdit(ProgramInfo program)
        {
            editing.CodeFolder = program.CodeFolder;
            editing.BuildFolder = program.BuildFolder;
            editing.ManualFolder = program.ManualFolder;
            editing.GitRemote = program.GitRemote;
            try
            {
                ws.SavePrograms();
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "저장", ex);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}
