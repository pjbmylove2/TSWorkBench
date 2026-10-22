using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;

namespace TSWorkBench.Pages
{
    /// <summary>정리되지 않은 과거 보고서·메일·폴더를 훑어 완료 업무로 한꺼번에 등록한다.</summary>
    public partial class ImportPage : PageBase
    {
        private readonly List<Choice<WorkType>> types = Labels.Choices<WorkType>();

        public ImportPage()
        {
            InitializeComponent();
            colType.Items.AddRange(types.Select(t => (object)t.Text).ToArray());
            colType.DefaultCellStyle.BackColor = Theme.DarkTheme.GridRow;
        }

        public override string HelpTopic => "3.8";

        public override string PageTitle => "과거 자료 가져오기";

        public override string PageSubtitle => "흩어진 보고서·메일·폴더를 업무 카드로 만듭니다. 원본은 옮기거나 지우지 않습니다 (같은 경로는 다시 등록되지 않음)";

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folder = FolderPicker.Pick(this, "과거 업무 자료가 들어 있는 최상위 폴더", txtFolder.Text);
            if (folder != null)
            {
                txtFolder.Text = folder;
            }
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            var root = txtFolder.Text.Trim();
            if (!Directory.Exists(root))
            {
                MessageBox.Show(this, "폴더를 찾을 수 없습니다.", "가져오기", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var depth = (int)numDepth.Value;
            var masters = Ws.Masters;
            var existing = Ws.Items.All.ToList();
            btnScan.Enabled = false;
            lblSummary.Text = "스캔 중…";
            try
            {
                var candidates = await Task.Run(() => ImportScanner.Scan(root, depth, masters, existing));
                ShowCandidates(candidates);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "스캔", ex);
                lblSummary.Text = "스캔 실패";
            }
            finally
            {
                btnScan.Enabled = true;
            }
        }

        private void ShowCandidates(List<ImportCandidate> candidates)
        {
            grid.Rows.Clear();
            foreach (var c in candidates)
            {
                var index = grid.Rows.Add(c.Selected, ReportGenerator.Day(c.Date), c.DateSource, c.Title, Labels.Of(c.Type),
                    c.Customer, c.Equipment, c.TargetSystem, c.FileCount, c.SourcePath);
                var row = grid.Rows[index];
                row.Tag = c;
                if (c.AlreadyImported)
                {
                    row.DefaultCellStyle.ForeColor = Theme.DarkTheme.Muted;
                    row.Cells[colPath.Index].ToolTipText = "이미 등록된 경로입니다.";
                }
            }

            UpdateSummary();
        }

        private void UpdateSummary()
        {
            var rows = grid.Rows.Cast<DataGridViewRow>().ToList();
            lblSummary.Text = "후보 " + rows.Count + "건 · 선택 " + rows.Count(IsSelected) + "건 · 이미 등록 "
                              + rows.Count(r => ((ImportCandidate)r.Tag).AlreadyImported) + "건";
        }

        private bool IsSelected(DataGridViewRow row)
        {
            return Convert.ToBoolean(row.Cells[colSelect.Index].Value);
        }

        private void SetAll(bool selected)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                row.Cells[colSelect.Index].Value = selected && !((ImportCandidate)row.Tag).AlreadyImported;
            }

            UpdateSummary();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SetAll(true);
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            SetAll(false);
        }

        private void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // 체크박스는 칸을 벗어나기 전에도 바로 반영한다.
            if (grid.IsCurrentCellDirty && grid.CurrentCell is DataGridViewCheckBoxCell)
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == colSelect.Index)
            {
                UpdateSummary();
            }
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            grid.EndEdit();
            var rows = grid.Rows.Cast<DataGridViewRow>().Where(IsSelected).ToList();
            if (rows.Count == 0)
            {
                return;
            }

            if (MessageBox.Show(this, rows.Count + "건을 완료 업무로 등록할까요?" + (chkCopyFiles.Checked ? "\n원본 파일을 업무 폴더로 복사합니다 (용량 주의)." : ""),
                    "가져오기", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            var errors = new List<string>();
            var done = 0;
            Cursor = Cursors.WaitCursor;
            try
            {
                foreach (var row in rows)
                {
                    var c = (ImportCandidate)row.Tag;
                    try
                    {
                        ReadBack(row, c);
                        var item = ImportScanner.ToWorkItem(c, DateTime.Now);
                        Ws.Save(item);
                        if (chkCopyFiles.Checked)
                        {
                            CopyOriginals(item, c);
                        }

                        row.Cells[colSelect.Index].Value = false;
                        c.AlreadyImported = true;
                        row.DefaultCellStyle.ForeColor = Theme.DarkTheme.Muted;
                        done++;
                    }
                    catch (Exception ex)
                    {
                        errors.Add(c.SourcePath + " : " + ex.Message);
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            UpdateSummary();
            MessageBox.Show(this, done + "건을 등록했습니다." + (errors.Count > 0 ? "\n\n실패 " + errors.Count + "건:\n" + string.Join("\n", errors.Take(10)) : "")
                                  + "\n\n지식베이스에서 찾을 수 있도록, 중요한 건은 업무 카드를 열어 현상·원인·조치를 채워 두세요.",
                "가져오기", MessageBoxButtons.OK, errors.Count > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        /// <summary>표에서 고친 값을 후보에 반영한다.</summary>
        private void ReadBack(DataGridViewRow row, ImportCandidate c)
        {
            DateTime date;
            if (DateTime.TryParse(Convert.ToString(row.Cells[colDate.Index].Value), CultureInfo.GetCultureInfo("ko-KR"), DateTimeStyles.None, out date))
            {
                c.Date = date.TimeOfDay == TimeSpan.Zero ? date.AddHours(9) : date;
            }

            c.Title = Convert.ToString(row.Cells[colTitle.Index].Value)?.Trim() ?? c.Title;
            c.Customer = Convert.ToString(row.Cells[colCustomer.Index].Value)?.Trim() ?? "";
            c.Equipment = Convert.ToString(row.Cells[colEquipment.Index].Value)?.Trim() ?? "";
            c.TargetSystem = Convert.ToString(row.Cells[colSystem.Index].Value)?.Trim() ?? "";
            var typeText = Convert.ToString(row.Cells[colType.Index].Value);
            var type = types.FirstOrDefault(t => t.Text == typeText);
            if (type != null)
            {
                c.Type = type.Value;
            }
        }

        private void CopyOriginals(WorkItem item, ImportCandidate c)
        {
            var files = c.IsFolder ? ImportScanner.SafeFiles(c.SourcePath) : new[] { c.SourcePath };
            foreach (var file in files)
            {
                var relative = Ws.Items.CopyIntoItem(item, file);
                item.Attachments.Add(new AttachmentRef { Name = Path.GetFileName(relative), Path = relative, Copied = true });
            }

            Ws.Save(item);
        }
    }
}
