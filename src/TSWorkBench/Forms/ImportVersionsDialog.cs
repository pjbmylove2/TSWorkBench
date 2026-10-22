using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// <summary>과거 버전 가져오기: 날짜별 zip·폴더를 차례로 Git 기록(커밋 + 버전 이름표)으로 만든다.</summary>
    public partial class ImportVersionsDialog : DarkForm
    {
        private readonly Workspace ws;
        private readonly ProgramInfo program;

        public ImportVersionsDialog()
        {
            InitializeComponent();
        }

        public ImportVersionsDialog(Workspace ws, ProgramInfo program) : this()
        {
            this.ws = ws;
            this.program = program;
            Text = "과거 버전 가져오기 — " + program.Name;
            var git = new GitRunner(program.CodeFolder, ws.Settings.UserName);
            var latest = git.IsRepo && git.HasCommits ? VersionUtil.Latest(git.Tags().Select(t => t.Tag)) : null;
            lblState.Text = "지금 최신 " + (latest == null ? "없음 (첫 줄이 기준본이 됩니다)" : "v" + latest) + "\r\n코드 폴더: " + program.CodeFolder;
        }

        private void Log(string text)
        {
            txtLog.AppendText(text + Environment.NewLine);
        }

        private void btnAddZip_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Multiselect = true, Filter = "zip 파일 (*.zip)|*.zip", Title = "버전별 zip 파일 (여러 개 선택 가능)" })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    AddSources(dialog.FileNames);
                }
            }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            var folder = FolderPicker.Pick(this, "버전 폴더 하나 (예: OCR_20231213)", null);
            if (folder != null)
            {
                AddSources(new[] { folder });
            }
        }

        /// <summary>이름에서 날짜를 읽고 날짜 순으로 정렬해 버전을 차례로 제안한다.</summary>
        private void AddSources(IEnumerable<string> paths)
        {
            var rows = ReadRows();
            foreach (var path in paths.Where(p => rows.All(r => !string.Equals(r.SourcePath, p, StringComparison.OrdinalIgnoreCase))))
            {
                DateTime date;
                if (!ImportScanner.TryDateFromName(Path.GetFileName(path), out date))
                {
                    date = File.Exists(path) ? File.GetLastWriteTime(path) : Directory.GetLastWriteTime(path);
                }

                rows.Add(new ImportVersion
                {
                    SourcePath = path,
                    Date = date.Date.AddHours(12),
                    Note = date.ToString("yyyyMMdd") + " 현장적용본"
                });
            }

            var service = new ProgramService(ws);
            var planned = new List<string>();
            foreach (var row in rows.OrderBy(r => r.Date))
            {
                row.Version = service.SuggestImportVersion(program, planned);
                planned.Add(row.Version);
            }

            ShowRows(rows.OrderBy(r => r.Date));
        }

        private void ShowRows(IEnumerable<ImportVersion> rows)
        {
            grid.Rows.Clear();
            foreach (var r in rows)
            {
                grid.Rows.Add(r.SourcePath, r.Date.ToString("yyyy-MM-dd"), r.Version, r.WorkItemId, r.Note);
            }
        }

        private List<ImportVersion> ReadRows()
        {
            grid.EndEdit();
            var rows = new List<ImportVersion>();
            foreach (DataGridViewRow row in grid.Rows)
            {
                DateTime date;
                DateTime.TryParse(Convert.ToString(row.Cells[colDate.Index].Value), CultureInfo.GetCultureInfo("ko-KR"), DateTimeStyles.None, out date);
                rows.Add(new ImportVersion
                {
                    SourcePath = Convert.ToString(row.Cells[colSource.Index].Value) ?? "",
                    Date = date == default(DateTime) ? DateTime.Today : date.Date.AddHours(12),
                    Version = Convert.ToString(row.Cells[colVersion.Index].Value)?.Trim() ?? "",
                    WorkItemId = Convert.ToString(row.Cells[colWorkItem.Index].Value)?.Trim().ToUpperInvariant() ?? "",
                    Note = Convert.ToString(row.Cells[colNote.Index].Value)?.Trim() ?? ""
                });
            }

            return rows;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                grid.Rows.Remove(grid.CurrentRow);
            }
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            var rows = ReadRows();
            if (rows.Count == 0)
            {
                return;
            }

            var bad = rows.FirstOrDefault(r => !VersionUtil.IsValid(r.Version));
            if (bad != null)
            {
                MessageBox.Show(this, "버전을 1.1.0 같은 형식으로 입력하세요: " + bad.Version, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(this, rows.Count + "개 버전을 날짜 순서대로 코드 폴더에 덮어쓰며 기록합니다.\n\n" + program.CodeFolder
                                      + "\n\n코드 폴더를 VS2022로 열어 두었다면 닫고 진행하세요. 계속할까요?",
                    Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            btnOk.Enabled = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                var progress = new Progress<string>(Log);
                var service = new ProgramService(ws);
                await Task.Run(() => service.ImportVersions(program, rows, progress));
                MessageBox.Show(this, rows.Count + "개 버전을 가져왔습니다. 이제 VS2022로 코드 폴더를 열면 기록이 보입니다.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Log("✖ " + ex.Message);
                ItemActions.ShowError(this, "과거 버전 가져오기", ex);
                btnOk.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
