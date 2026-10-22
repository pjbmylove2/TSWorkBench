using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Forms;
using TSWorkBench.Services;
using TSWorkBench.Storage;
using TSWorkBench.Theme;

namespace TSWorkBench.Pages
{
    /// <summary>
    /// 도움말. 실행 파일 옆 Help\의 문서(저장소 docs\와 같은 파일)를 목차·검색과 함께 보여 준다.
    /// 기능을 고치면 docs\의 문서를 고치면 되고, 빌드할 때 Help\로 복사된다.
    /// </summary>
    public partial class HelpPage : PageBase
    {
        private List<HelpDocument> docs = new List<HelpDocument>();
        private HelpDocument shown;
        private string pendingAnchor;
        private bool filling;
        private Font boldFont;

        public HelpPage()
        {
            InitializeComponent();
        }

        /// <summary>실행 파일 옆 Help\ (화면 검사처럼 다른 프로세스에서 띄울 때만 바꾼다).</summary>
        public static string HelpFolder { get; internal set; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Help");

        public override string PageTitle => "도움말";

        public override string PageSubtitle => "화면별 사용법 · 백업과 다른 PC로 옮기기 · 프로그램 배포 · 업무 관리 방법";

        public override void Attach(IAppHost host)
        {
            base.Attach(host);
            colTopic.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // 같은 목차를 다시 눌러도 그 자리로 다시 간다 (본문을 스크롤한 뒤).
            gridToc.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    gridToc_SelectionChanged(s, e);
                }
            };
            Disposed += (s, e) => boldFont?.Dispose();
        }

        public override void RefreshData()
        {
            if (docs.Count == 0)
            {
                Reload();
            }
        }

        private void Reload()
        {
            try
            {
                docs = HelpDocument.LoadFolder(HelpFolder);
            }
            catch (Exception ex)
            {
                docs = new List<HelpDocument>();
                ErrorLog.Write("도움말 읽기", ex);
            }

            FillToc();
            if (docs.Count == 0)
            {
                browser.DocumentText = "<html><body style=\"background:#212121;color:#ececec;font-family:'Malgun Gothic';padding:24px\">"
                                       + "도움말 문서를 찾지 못했습니다.<br>" + System.Net.WebUtility.HtmlEncode(HelpFolder)
                                       + "<br><br>프로그램 폴더를 복사할 때 <b>Help</b> 폴더도 함께 복사하세요.</body></html>";
            }
            else if (shown == null)
            {
                Show(docs[0], null);
            }
        }

        /// <summary>F1: 사용설명서에서 제목이 prefix로 시작하는 곳(예: "3.7")을 연다. 없으면 사용설명서 처음.</summary>
        public void ShowTopic(string prefix)
        {
            RefreshData();
            var doc = docs.FirstOrDefault(d => d.FileName == HelpDocument.Order[0]) ?? docs.FirstOrDefault();
            if (doc == null)
            {
                return;
            }

            txtSearch.Text = "";
            Show(doc, string.IsNullOrEmpty(prefix) ? null : doc.Find(prefix));
        }

        // ── 목차 · 검색 ──────────────────────────────────────

        private void FillToc()
        {
            filling = true;
            try
            {
                gridToc.Rows.Clear();
                var terms = txtSearch.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (terms.Length == 0)
                {
                    foreach (var doc in docs)
                    {
                        AddRow("■ " + doc.Title, doc, null, true);
                        foreach (var s in doc.Sections.Where(s => s.Level == 2 || s.Level == 3))
                        {
                            AddRow((s.Level == 3 ? "        " : "   ") + s.Title, doc, s, false);
                        }
                    }

                    lblCount.Text = "  문서 " + docs.Count + "개";
                }
                else
                {
                    var hits = 0;
                    foreach (var doc in docs)
                    {
                        foreach (var s in doc.Sections.Where(s => terms.All(t => (s.Title + " " + s.Text).IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0)))
                        {
                            AddRow(s.Title + "   — " + doc.Title, doc, s, false);
                            hits++;
                        }
                    }

                    lblCount.Text = "  찾은 곳 " + hits + "개";
                }

                SelectShown();
            }
            finally
            {
                filling = false;
            }
        }

        private void AddRow(string text, HelpDocument doc, HelpSection section, bool isDoc)
        {
            var row = gridToc.Rows[gridToc.Rows.Add(text)];
            row.Tag = Tuple.Create(doc, section);
            if (isDoc)
            {
                row.DefaultCellStyle.ForeColor = DarkTheme.Accent;
                // 글꼴은 FontManager가 나눔고딕으로 바꾼 뒤에 만든다.
                boldFont = boldFont ?? new Font(gridToc.Font, FontStyle.Bold);
                row.DefaultCellStyle.Font = boldFont;
            }
            else if (section != null && section.Level == 3)
            {
                row.DefaultCellStyle.ForeColor = DarkTheme.Muted;
            }
        }

        private void SelectShown()
        {
            gridToc.ClearSelection();
            foreach (DataGridViewRow row in gridToc.Rows)
            {
                var tag = (Tuple<HelpDocument, HelpSection>)row.Tag;
                if (ReferenceEquals(tag.Item1, shown) && tag.Item2 == null)
                {
                    gridToc.CurrentCell = row.Cells[0];
                    return;
                }
            }
        }

        private void gridToc_SelectionChanged(object sender, EventArgs e)
        {
            if (filling)
            {
                return;
            }

            var tag = gridToc.SelectedTag<Tuple<HelpDocument, HelpSection>>();
            if (tag != null)
            {
                Show(tag.Item1, tag.Item2);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchTimer.Stop();
            searchTimer.Start();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            searchTimer.Stop();
            FillToc();
        }

        // ── 본문 ─────────────────────────────────────────────

        private void Show(HelpDocument doc, HelpSection section)
        {
            if (!ReferenceEquals(doc, shown) || browser.Document == null)
            {
                shown = doc;
                pendingAnchor = section?.Id;
                browser.DocumentText = doc.ToPage(HelpFolder);
                return;
            }

            ScrollTo(section?.Id);
        }

        private void ScrollTo(string id)
        {
            var document = browser.Document;
            if (document == null)
            {
                return;
            }

            var element = string.IsNullOrEmpty(id) ? null : document.GetElementById(id);
            if (element != null)
            {
                element.ScrollIntoView(true);
            }
            else
            {
                document.Window?.ScrollTo(0, 0);
            }
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var id = pendingAnchor;
            pendingAnchor = null;
            ScrollTo(id);
        }

        /// <summary>문서 안 링크: 다른 .md는 이 화면에서, 웹 주소는 브라우저로 연다.</summary>
        private void browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            var url = e.Url;
            if (url == null || url.ToString().StartsWith("about:", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            e.Cancel = true;
            if (url.IsFile && url.LocalPath.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                var doc = docs.FirstOrDefault(d => string.Equals(d.FileName, Path.GetFileName(url.LocalPath), StringComparison.OrdinalIgnoreCase));
                if (doc != null)
                {
                    BeginInvoke((Action)(() =>
                    {
                        txtSearch.Text = "";
                        Show(doc, null);
                        FillToc();
                    }));
                }

                return;
            }

            if (url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps || url.IsFile)
            {
                try
                {
                    Process.Start(new ProcessStartInfo(url.IsFile ? url.LocalPath : url.ToString()) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    ItemActions.ShowError(this, "열기", ex);
                }
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            ItemActions.OpenPath(HelpFolder);
        }
    }
}
