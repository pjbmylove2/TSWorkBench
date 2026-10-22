using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Forms
{
    /// <summary>
    /// 업무 카드 1건 편집. 원본은 건드리지 않고 복사본을 고치다가 저장할 때만 저장소에 반영한다.
    /// </summary>
    public partial class WorkItemForm : DarkForm
    {
        private readonly Workspace ws;
        private readonly WorkItem item;
        private readonly Dictionary<NavButton, Control> sections = new Dictionary<NavButton, Control>();
        private string savedSnapshot;
        private bool loading;

        public WorkItemForm()
        {
            InitializeComponent();
        }

        public WorkItemForm(Workspace ws, WorkItem source) : this()
        {
            this.ws = ws;
            item = JsonFile.Clone(source);

            sections[secSymptom] = tblSymptom;
            sections[secCause] = tblCause;
            sections[secAction] = tblAction;
            sections[secVerify] = tblVerify;
            sections[secTimeline] = pnlTimeline;
            sections[secChecklist] = pnlChecklist;
            sections[secAttach] = pnlAttach;
            foreach (var pair in sections)
            {
                var section = pair.Value;
                pair.Key.CheckedChanged += (s, e) => section.Visible = ((NavButton)s).Checked;
            }

            UiHelpers.FillChoices(cboTlKind, TimelineKind.OnSite);
            LoadFromItem();
            savedSnapshot = Snapshot();
            secSymptom.Checked = true;
        }

        private bool IsNew => string.IsNullOrEmpty(item.Id);

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (IsNew)
            {
                txtTitle.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                TrySave();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.Cancel || Snapshot() == savedSnapshot)
            {
                return;
            }

            var answer = MessageBox.Show(this, "저장하지 않은 내용이 있습니다. 저장할까요?", "업무 카드",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (answer == DialogResult.Cancel || (answer == DialogResult.Yes && !TrySave()))
            {
                e.Cancel = true;
            }
        }

        // ── 화면 ↔ 데이터 ─────────────────────────────────────

        private void LoadFromItem()
        {
            loading = true;
            Text = IsNew ? "새 업무 카드" : item.Id + "  " + item.Title;
            lblId.Text = IsNew ? "(저장 시 부여)" : item.Id;
            txtTitle.Text = item.Title;
            UiHelpers.FillChoices(cboType, item.Type);
            UiHelpers.FillChoices(cboPriority, item.Priority);
            txtTags.Text = item.Tags;
            UiHelpers.FillNames(cboCustomer, UiHelpers.CustomerNames(ws), item.Customer);
            UiHelpers.FillNames(cboSite, UiHelpers.SiteNames(ws), item.Site);
            UiHelpers.FillNames(cboEquipment, UiHelpers.EquipmentNames(ws), item.Equipment);
            UiHelpers.FillNames(cboSystem, UiHelpers.SystemNames(ws), item.TargetSystem);
            dateReceived.Value = item.ReceivedAt;
            dateDue.Value = item.DueDate;
            txtRequester.Text = item.Requester;

            txtSymptom.Text = Crlf(item.Symptom);
            txtSymptomWhen.Text = item.SymptomWhen;
            txtReproduction.Text = Crlf(item.Reproduction);
            txtImpact.Text = Crlf(item.Impact);
            txtCause.Text = Crlf(item.Cause);
            txtCauseEvidence.Text = Crlf(item.CauseEvidence);
            txtActionHw.Text = Crlf(item.ActionHardware);
            txtActionSw.Text = Crlf(item.ActionSoftware);
            txtChangedFiles.Text = Crlf(item.ChangedFiles);
            txtVerification.Text = Crlf(item.Verification);
            txtPrevention.Text = Crlf(item.Prevention);
            txtCustomerNote.Text = Crlf(item.CustomerNote);
            chkRevisit.Checked = item.NeedsRevisit;
            dateRevisit.Value = item.RevisitDate;

            clbChecklist.Items.Clear();
            foreach (var c in item.Checklist)
            {
                clbChecklist.Items.Add(c.Text, c.Done);
            }

            ShowStatus();
            FillTimeline();
            FillAttachments();
            loading = false;
        }

        /// <summary>TextBox는 \r\n이어야 줄이 바뀐다. JSON을 손으로 고치면 \n만 들어올 수 있다.</summary>
        private static string Crlf(string text)
        {
            return (text ?? "").Replace("\r\n", "\n").Replace("\n", "\r\n");
        }

        /// <summary>화면 입력을 item에 옮긴다. 타임라인·첨부는 이미 item에 직접 반영돼 있다.</summary>
        private void ApplyToItem()
        {
            item.Title = txtTitle.Text.Trim();
            item.Type = UiHelpers.ChoiceValue(cboType, item.Type);
            item.Priority = UiHelpers.ChoiceValue(cboPriority, item.Priority);
            item.Tags = txtTags.Text.Trim();
            item.Customer = cboCustomer.Text.Trim();
            item.Site = cboSite.Text.Trim();
            item.Equipment = cboEquipment.Text.Trim();
            item.TargetSystem = cboSystem.Text.Trim();
            item.ReceivedAt = dateReceived.Value ?? item.ReceivedAt;
            item.DueDate = dateDue.Value;
            if (item.Status == WorkStatus.Done)
            {
                // 완료 일시는 완료 상태에서만 고칠 수 있고, 비우면 원래 값을 유지한다.
                item.CompletedAt = dateCompleted.Value ?? item.CompletedAt;
            }

            item.Requester = txtRequester.Text.Trim();

            item.Symptom = txtSymptom.Text;
            item.SymptomWhen = txtSymptomWhen.Text;
            item.Reproduction = txtReproduction.Text;
            item.Impact = txtImpact.Text;
            item.Cause = txtCause.Text;
            item.CauseEvidence = txtCauseEvidence.Text;
            item.ActionHardware = txtActionHw.Text;
            item.ActionSoftware = txtActionSw.Text;
            item.ChangedFiles = txtChangedFiles.Text;
            item.Verification = txtVerification.Text;
            item.Prevention = txtPrevention.Text;
            item.CustomerNote = txtCustomerNote.Text;
            item.NeedsRevisit = chkRevisit.Checked;
            item.RevisitDate = dateRevisit.Value;

            item.Checklist = clbChecklist.Items.Cast<object>()
                .Select((text, i) => new ChecklistItem { Text = text.ToString(), Done = clbChecklist.GetItemChecked(i) })
                .ToList();
        }

        private string Snapshot()
        {
            if (ws == null)
            {
                return "";
            }

            ApplyToItem();
            return JsonFile.Serialize(item);
        }

        private bool TrySave()
        {
            ApplyToItem();
            if (string.IsNullOrWhiteSpace(item.Title))
            {
                MessageBox.Show(this, "제목을 입력하세요.", "저장", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Focus();
                return false;
            }

            try
            {
                ws.Save(item);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "저장", ex);
                return false;
            }

            savedSnapshot = JsonFile.Serialize(item);
            Text = item.Id + "  " + item.Title;
            lblId.Text = item.Id;
            return true;
        }

        /// <summary>폴더가 필요한 작업(첨부·보고서) 전에 새 카드면 먼저 저장한다.</summary>
        private bool EnsureSaved()
        {
            return (!IsNew && Snapshot() == savedSnapshot) || TrySave();
        }

        // ── 상태 ─────────────────────────────────────────────

        private void ShowStatus()
        {
            lblStatus.Text = Labels.Of(item.Status);
            lblStatus.ForeColor = DarkTheme.StatusColor(item.Status);
            dateCompleted.Value = item.CompletedAt;
            dateCompleted.Enabled = item.Status == WorkStatus.Done;
            var next = WorkflowRules.NextInFlow(item.Status);
            btnAdvance.Enabled = next.HasValue;
            btnAdvance.Text = next.HasValue ? "▶ 다음 단계: " + Labels.Of(next.Value) : "▶ 다음 단계 없음";
        }

        private void ChangeStatus(WorkStatus to)
        {
            ApplyToItem();
            if (to == WorkStatus.Done)
            {
                var missing = WorkflowRules.MissingForDone(item);
                if (missing.Count > 0 && MessageBox.Show(this,
                        "다음 항목이 비어 있습니다: " + string.Join(", ", missing) + "\n\n나중에 찾아볼 수 있도록 채우는 것을 권장합니다. 그래도 완료할까요?",
                        "완료 처리", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return;
                }
            }

            WorkflowRules.ChangeStatus(item, to, DateTime.Now);
            ShowStatus();
            FillTimeline();
            if (!TrySave())
            {
                return;
            }

            if (to == WorkStatus.Done)
            {
                OfferFollowUps();
            }
        }

        private void OfferFollowUps()
        {
            var followUps = WorkflowRules.CreateFollowUps(item, ws.Settings, DateTime.Now);
            if (followUps.Count == 0)
            {
                return;
            }

            var list = string.Join("\n", followUps.Select(f => "· " + f.Title + "  (기한 " + ReportGenerator.Day(f.DueDate) + ")"));
            if (MessageBox.Show(this, "이어서 할 예정 업무를 만들까요?\n\n" + list, "후속 업무", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            foreach (var followUp in followUps)
            {
                ws.FillChecklist(followUp);
                ws.Save(followUp);
            }
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            var next = WorkflowRules.NextInFlow(item.Status);
            if (next.HasValue)
            {
                ChangeStatus(next.Value);
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            var menu = DarkMenuRenderer.CreateMenu();
            foreach (var to in WorkflowRules.AllowedFrom(item.Status))
            {
                var target = to;
                menu.Items.Add(Labels.Of(target), null, (s, a) => ChangeStatus(target));
            }

            menu.Closed += (s, a) => BeginInvoke(new Action(menu.Dispose));
            menu.Show(btnStatus, 0, btnStatus.Height);
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 체크리스트가 비어 있을 때만 새 유형의 템플릿으로 채운다.
            if (loading || clbChecklist.Items.Count > 0)
            {
                return;
            }

            foreach (var text in ws.Masters.ChecklistFor(UiHelpers.ChoiceValue(cboType, item.Type)))
            {
                clbChecklist.Items.Add(text, false);
            }
        }

        // ── 하단 버튼 ────────────────────────────────────────

        private void btnSave_Click(object sender, EventArgs e)
        {
            TrySave();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!EnsureSaved())
            {
                return;
            }

            try
            {
                ItemActions.FieldReport(ws, item);
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "보고서 생성", ex);
            }
        }

        private void btnNotion_Click(object sender, EventArgs e)
        {
            if (EnsureSaved())
            {
                ItemActions.CopyMarkdown(ws, item);
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (EnsureSaved())
            {
                ItemActions.OpenFolder(ws, item);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ── 작업 이력 ────────────────────────────────────────

        private void FillTimeline()
        {
            gridTimeline.Rows.Clear();
            foreach (var t in item.Timeline.OrderBy(t => t.Start))
            {
                var index = gridTimeline.Rows.Add(ReportGenerator.Minute(t.Start), ReportGenerator.Minute(t.End), Labels.Of(t.Kind),
                    t.Hours > 0 ? ReportGenerator.Hours(t.Hours) : "", t.Text);
                gridTimeline.Rows[index].Tag = t;
            }

            var onSite = item.Timeline.Where(t => t.Kind == TimelineKind.OnSite).Sum(t => t.Hours);
            var travel = item.Timeline.Where(t => t.Kind == TimelineKind.Travel).Sum(t => t.Hours);
            var remote = item.Timeline.Where(t => t.Kind == TimelineKind.Remote || t.Kind == TimelineKind.Analysis).Sum(t => t.Hours);
            lblTlHours.Text = "합계 " + ReportGenerator.Hours(item.Timeline.Sum(t => t.Hours)) + "h  (현장 " + ReportGenerator.Hours(onSite)
                              + " · 이동 " + ReportGenerator.Hours(travel) + " · 원격/분석 " + ReportGenerator.Hours(remote) + ")";
        }

        private TimelineEntry ReadTimelineEditor()
        {
            if (!dateTlStart.Value.HasValue)
            {
                MessageBox.Show(this, "시작 시각을 입력하세요. ('시작 = 지금' 버튼)", "작업 이력", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            return new TimelineEntry
            {
                Start = dateTlStart.Value.Value,
                End = dateTlEnd.Value,
                Kind = UiHelpers.ChoiceValue(cboTlKind, TimelineKind.Note),
                Text = txtTlText.Text.Trim()
            };
        }

        private void gridTimeline_SelectionChanged(object sender, EventArgs e)
        {
            var t = gridTimeline.SelectedTag<TimelineEntry>();
            if (t == null)
            {
                return;
            }

            dateTlStart.Value = t.Start;
            dateTlEnd.Value = t.End;
            UiHelpers.FillChoices(cboTlKind, t.Kind);
            txtTlText.Text = t.Text;
        }

        private void btnTlStartNow_Click(object sender, EventArgs e)
        {
            dateTlStart.Value = DateTime.Now;
            dateTlEnd.Value = null;
        }

        private void btnTlEndNow_Click(object sender, EventArgs e)
        {
            dateTlEnd.Value = DateTime.Now;
        }

        private void btnTlAdd_Click(object sender, EventArgs e)
        {
            var entry = ReadTimelineEditor();
            if (entry == null)
            {
                return;
            }

            item.Timeline.Add(entry);
            txtTlText.Clear();
            FillTimeline();
        }

        private void btnTlUpdate_Click(object sender, EventArgs e)
        {
            var target = gridTimeline.SelectedTag<TimelineEntry>();
            var entry = ReadTimelineEditor();
            if (target == null || entry == null)
            {
                return;
            }

            target.Start = entry.Start;
            target.End = entry.End;
            target.Kind = entry.Kind;
            target.Text = entry.Text;
            FillTimeline();
        }

        private void btnTlDelete_Click(object sender, EventArgs e)
        {
            var target = gridTimeline.SelectedTag<TimelineEntry>();
            if (target != null)
            {
                item.Timeline.Remove(target);
                FillTimeline();
            }
        }

        // ── 체크리스트 ───────────────────────────────────────

        private void btnCheckAdd_Click(object sender, EventArgs e)
        {
            var text = txtCheckNew.Text.Trim();
            if (text.Length > 0)
            {
                clbChecklist.Items.Add(text, false);
                txtCheckNew.Clear();
            }
        }

        private void btnCheckRemove_Click(object sender, EventArgs e)
        {
            if (clbChecklist.SelectedIndex >= 0)
            {
                clbChecklist.Items.RemoveAt(clbChecklist.SelectedIndex);
            }
        }

        private void btnCheckTemplate_Click(object sender, EventArgs e)
        {
            var existing = new HashSet<string>(clbChecklist.Items.Cast<object>().Select(o => o.ToString()));
            foreach (var text in ws.Masters.ChecklistFor(UiHelpers.ChoiceValue(cboType, item.Type)).Where(t => !existing.Contains(t)))
            {
                clbChecklist.Items.Add(text, false);
            }
        }

        // ── 첨부 ─────────────────────────────────────────────

        private void FillAttachments()
        {
            gridAttach.Rows.Clear();
            foreach (var a in item.Attachments)
            {
                var index = gridAttach.Rows.Add(a.Name, a.Copied ? "복사본" : "링크", a.Note, a.Path);
                gridAttach.Rows[index].Tag = a;
            }
        }

        private void AddCopies(IEnumerable<string> paths)
        {
            if (!EnsureSaved())
            {
                return;
            }

            try
            {
                foreach (var path in paths)
                {
                    if (Directory.Exists(path))
                    {
                        item.Attachments.Add(new AttachmentRef { Name = Path.GetFileName(path), Path = path, Note = "폴더" });
                        continue;
                    }

                    var relative = ws.Items.CopyIntoItem(item, path);
                    item.Attachments.Add(new AttachmentRef { Name = Path.GetFileName(relative), Path = relative, Copied = true });
                }
            }
            catch (Exception ex)
            {
                ItemActions.ShowError(this, "첨부 복사", ex);
            }

            FillAttachments();
            TrySave();
        }

        private void btnAttachCopy_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Multiselect = true, Title = "업무 폴더로 복사할 파일 (사진·로그·보고서)" })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    AddCopies(dialog.FileNames);
                }
            }
        }

        private void btnAttachLink_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Multiselect = true, Title = "원본 위치만 기록할 파일 (큰 파일·공유 폴더)" })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                foreach (var path in dialog.FileNames)
                {
                    item.Attachments.Add(new AttachmentRef { Name = Path.GetFileName(path), Path = path });
                }

                FillAttachments();
            }
        }

        private void btnAttachFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog { Description = "원본 위치만 기록할 폴더" })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                item.Attachments.Add(new AttachmentRef { Name = Path.GetFileName(dialog.SelectedPath), Path = dialog.SelectedPath, Note = "폴더" });
                FillAttachments();
            }
        }

        private void btnAttachPaste_Click(object sender, EventArgs e)
        {
            if (!Clipboard.ContainsImage())
            {
                MessageBox.Show(this, "클립보드에 이미지가 없습니다.\nWin+Shift+S로 화면을 캡처한 뒤 다시 누르세요.", "붙여넣기", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!EnsureSaved())
            {
                return;
            }

            var filesDir = Path.Combine(ws.Items.FolderOf(item), "files");
            Directory.CreateDirectory(filesDir);
            var target = WorkRepository.UniquePath(filesDir, "캡처_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png");
            using (var image = Clipboard.GetImage())
            {
                image.Save(target, ImageFormat.Png);
            }

            item.Attachments.Add(new AttachmentRef { Name = Path.GetFileName(target), Path = Path.Combine("files", Path.GetFileName(target)), Copied = true });
            FillAttachments();
            TrySave();
        }

        private void btnAttachOpen_Click(object sender, EventArgs e)
        {
            var a = gridAttach.SelectedTag<AttachmentRef>();
            if (a != null)
            {
                ItemActions.OpenPath(ws.Items.ResolvePath(item, a));
            }
        }

        private void gridAttach_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != colAtNote.Index)
            {
                btnAttachOpen_Click(sender, e);
            }
        }

        private void btnAttachRemove_Click(object sender, EventArgs e)
        {
            var a = gridAttach.SelectedTag<AttachmentRef>();
            if (a == null)
            {
                return;
            }

            var message = a.Copied
                ? "목록에서 제거합니다. 복사본 파일은 업무 폴더 files\\에 남아 있습니다."
                : "목록에서 제거합니다. 원본 파일은 그대로 있습니다.";
            if (MessageBox.Show(this, a.Name + "\n\n" + message, "첨부 제거", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                item.Attachments.Remove(a);
                FillAttachments();
            }
        }

        private void gridAttach_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var a = gridAttach.Rows[e.RowIndex].Tag as AttachmentRef;
            if (a != null && e.ColumnIndex == colAtNote.Index)
            {
                a.Note = Convert.ToString(gridAttach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) ?? "";
            }
        }

        private void gridAttach_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void gridAttach_DragDrop(object sender, DragEventArgs e)
        {
            var paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (paths != null)
            {
                AddCopies(paths);
            }
        }
    }
}
