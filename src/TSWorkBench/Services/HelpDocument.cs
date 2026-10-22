using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace TSWorkBench.Services
{
    /// <summary>도움말 문서의 제목 하나 (목차·검색·F1 이동용).</summary>
    public sealed class HelpSection
    {
        public string Id { get; set; } = "";
        public int Level { get; set; }
        public string Title { get; set; } = "";

        /// <summary>이 제목 아래 본문 (검색용 일반 글자).</summary>
        public string Text { get; set; } = "";
    }

    /// <summary>
    /// 도움말 = 실행 파일 옆 Help\*.md (저장소의 docs\와 같은 파일). Markdown을 화면용 HTML로 바꾼다.
    /// 문서에 쓰는 문법만 지원한다: 제목, 문단, 목록(중첩·체크박스), 표, 코드 블록, 인용, 가로줄, 굵게, `코드`, 링크, 그림.
    /// </summary>
    public sealed class HelpDocument
    {
        /// <summary>목록에 보일 순서. 여기 없는 .md는 뒤에 붙는다.</summary>
        public static readonly string[] Order = { "사용설명서.md", "백업_이전_가이드.md", "배포관리_가이드.md", "TS업무관리_가이드.md" };

        private static readonly Regex Heading = new Regex(@"^(#{1,6})\s+(.*?)\s*#*\s*$");
        private static readonly Regex ListItem = new Regex(@"^(\s*)([-*]|\d+\.)\s+(.*)$");
        private static readonly Regex TableSeparator = new Regex(@"^\s*\|?\s*:?-{3,}:?\s*(\|\s*:?-{3,}:?\s*)*\|?\s*$");

        public string FileName { get; private set; } = "";
        public string Title { get; private set; } = "";
        public string BodyHtml { get; private set; } = "";
        public List<HelpSection> Sections { get; } = new List<HelpSection>();

        public static HelpDocument Load(string path)
        {
            var doc = Parse(File.ReadAllText(path, Encoding.UTF8));
            doc.FileName = Path.GetFileName(path);
            if (doc.Title.Length == 0)
            {
                doc.Title = Path.GetFileNameWithoutExtension(path);
            }

            return doc;
        }

        /// <summary>폴더의 문서를 정해 둔 순서로 읽는다. 폴더가 없으면 빈 목록.</summary>
        public static List<HelpDocument> LoadFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return new List<HelpDocument>();
            }

            return Directory.GetFiles(folder, "*.md")
                .OrderBy(f =>
                {
                    var i = Array.IndexOf(Order, Path.GetFileName(f));
                    return i < 0 ? int.MaxValue : i;
                })
                .ThenBy(f => f, StringComparer.OrdinalIgnoreCase)
                .Select(Load)
                .ToList();
        }

        public static HelpDocument Parse(string markdown)
        {
            var doc = new HelpDocument();
            var lines = markdown.Replace("\r\n", "\n").Split('\n');
            doc.BodyHtml = Blocks(lines, doc);
            var h1 = doc.Sections.FirstOrDefault(s => s.Level == 1);
            doc.Title = h1?.Title ?? "";
            return doc;
        }

        /// <summary>제목 번호가 이것인 첫 섹션 (예: "3.7" → "3.7 프로그램 · 배포", "3.1"은 "3.10"과 구분).</summary>
        public HelpSection Find(string number)
        {
            return Sections.FirstOrDefault(s => s.Title == number || s.Title.StartsWith(number + " ", StringComparison.OrdinalIgnoreCase)
                                                                   || s.Title.StartsWith(number + ".", StringComparison.OrdinalIgnoreCase) && !char.IsDigit(s.Title.ElementAtOrDefault(number.Length + 1)));
        }

        /// <summary>doc이 null이면 섹션을 만들지 않는다 (인용 안쪽).</summary>
        private static string Blocks(IList<string> lines, HelpDocument doc)
        {
            var html = new StringBuilder();
            var paragraph = new List<string>();
            HelpSection section = null;
            var sectionText = new StringBuilder();

            Action flush = () =>
            {
                if (paragraph.Count > 0)
                {
                    html.Append("<p>").Append(Inline(string.Join(" ", paragraph))).Append("</p>\n");
                    paragraph.Clear();
                }
            };

            var i = 0;
            while (i < lines.Count)
            {
                var line = lines[i];
                var trimmed = line.Trim();
                if (section != null)
                {
                    sectionText.Append(trimmed).Append(' ');
                }

                if (trimmed.StartsWith("```"))
                {
                    flush();
                    var code = new List<string>();
                    i++;
                    while (i < lines.Count && !lines[i].Trim().StartsWith("```"))
                    {
                        code.Add(lines[i]);
                        sectionText.Append(lines[i].Trim()).Append(' ');
                        i++;
                    }

                    html.Append("<pre><code>").Append(WebUtility.HtmlEncode(string.Join("\n", code))).Append("</code></pre>\n");
                    i++;
                    continue;
                }

                var heading = Heading.Match(line);
                if (heading.Success)
                {
                    flush();
                    var level = heading.Groups[1].Value.Length;
                    var title = heading.Groups[2].Value;
                    var id = "";
                    if (doc != null)
                    {
                        if (section != null)
                        {
                            section.Text = sectionText.ToString();
                        }

                        id = "s" + (doc.Sections.Count + 1);
                        section = new HelpSection { Id = id, Level = level, Title = Plain(title) };
                        sectionText.Clear();
                        doc.Sections.Add(section);
                    }

                    html.AppendFormat("<h{0}{1}>{2}</h{0}>\n", level, id.Length > 0 ? " id=\"" + id + "\"" : "", Inline(title));
                    i++;
                    continue;
                }

                if (trimmed.Length == 0)
                {
                    flush();
                    i++;
                    continue;
                }

                if (Regex.IsMatch(trimmed, @"^(-{3,}|\*{3,})$"))
                {
                    flush();
                    html.Append("<hr>\n");
                    i++;
                    continue;
                }

                if (trimmed.StartsWith("|") && i + 1 < lines.Count && TableSeparator.IsMatch(lines[i + 1]))
                {
                    flush();
                    i = Table(lines, i, html, sectionText);
                    continue;
                }

                if (trimmed.StartsWith(">"))
                {
                    flush();
                    var quote = new List<string>();
                    while (i < lines.Count && lines[i].Trim().StartsWith(">"))
                    {
                        var q = lines[i].Trim().Substring(1);
                        quote.Add(q.StartsWith(" ") ? q.Substring(1) : q);
                        if (quote.Count > 1)
                        {
                            // 첫 줄은 위에서 이미 넣었다.
                            sectionText.Append(q.Trim()).Append(' ');
                        }

                        i++;
                    }

                    html.Append("<blockquote>").Append(Blocks(quote, null)).Append("</blockquote>\n");
                    continue;
                }

                if (ListItem.IsMatch(line))
                {
                    flush();
                    i = List(lines, i, html, sectionText);
                    continue;
                }

                paragraph.Add(trimmed);
                i++;
            }

            flush();
            if (section != null)
            {
                section.Text = sectionText.ToString();
            }

            return html.ToString();
        }

        private static int Table(IList<string> lines, int i, StringBuilder html, StringBuilder text)
        {
            html.Append("<table>\n<tr>");
            foreach (var cell in Cells(lines[i]))
            {
                html.Append("<th>").Append(Inline(cell)).Append("</th>");
            }

            html.Append("</tr>\n");
            i += 2;
            while (i < lines.Count && lines[i].Trim().StartsWith("|"))
            {
                text.Append(lines[i].Trim()).Append(' ');
                html.Append("<tr>");
                foreach (var cell in Cells(lines[i]))
                {
                    html.Append("<td>").Append(Inline(cell)).Append("</td>");
                }

                html.Append("</tr>\n");
                i++;
            }

            html.Append("</table>\n");
            return i;
        }

        private static IEnumerable<string> Cells(string line)
        {
            var t = line.Trim();
            if (t.StartsWith("|"))
            {
                t = t.Substring(1);
            }

            if (t.EndsWith("|"))
            {
                t = t.Substring(0, t.Length - 1);
            }

            // `코드` 안의 | 는 나누지 않는다.
            var cells = new List<string>();
            var sb = new StringBuilder();
            var inCode = false;
            foreach (var c in t)
            {
                if (c == '`')
                {
                    inCode = !inCode;
                }

                if (c == '|' && !inCode)
                {
                    cells.Add(sb.ToString().Trim());
                    sb.Clear();
                    continue;
                }

                sb.Append(c);
            }

            cells.Add(sb.ToString().Trim());
            return cells;
        }

        /// <summary>들여쓰기로 중첩된 목록. 목록 줄 사이의 들여쓴 이어지는 줄은 같은 항목에 붙인다.</summary>
        private static int List(IList<string> lines, int i, StringBuilder html, StringBuilder text)
        {
            var stack = new Stack<Tuple<int, string>>();
            while (i < lines.Count)
            {
                var m = ListItem.Match(lines[i]);
                if (!m.Success)
                {
                    var t = lines[i].Trim();
                    if (t.Length > 0 && stack.Count > 0 && lines[i].StartsWith(" ") && !t.StartsWith("|") && !t.StartsWith("```"))
                    {
                        html.Append("<br>").Append(Inline(t));
                        text.Append(t).Append(' ');
                        i++;
                        continue;
                    }

                    break;
                }

                var indent = m.Groups[1].Value.Replace("\t", "    ").Length;
                var tag = char.IsDigit(m.Groups[2].Value[0]) ? "ol" : "ul";
                var content = m.Groups[3].Value;
                text.Append(content).Append(' ');

                while (stack.Count > 0 && stack.Peek().Item1 > indent)
                {
                    html.Append("</li></").Append(stack.Pop().Item2).Append(">");
                }

                if (stack.Count == 0 || indent > stack.Peek().Item1)
                {
                    html.Append("<").Append(tag).Append(">");
                    stack.Push(Tuple.Create(indent, tag));
                }
                else
                {
                    html.Append("</li>");
                }

                html.Append("<li>").Append(CheckBox(content));
                i++;
            }

            while (stack.Count > 0)
            {
                html.Append("</li></").Append(stack.Pop().Item2).Append(">");
            }

            html.Append('\n');
            return i;
        }

        private static string CheckBox(string content)
        {
            if (content.StartsWith("[ ] "))
            {
                return "☐ " + Inline(content.Substring(4));
            }

            if (content.StartsWith("[x] ", StringComparison.OrdinalIgnoreCase))
            {
                return "☑ " + Inline(content.Substring(4));
            }

            return Inline(content);
        }

        /// <summary>`코드`, 그림, 링크, **굵게**. `코드` 안은 그대로 둔다.</summary>
        public static string Inline(string text)
        {
            var codes = new List<string>();
            var s = Regex.Replace(text, "`([^`]+)`", m =>
            {
                codes.Add("<code>" + WebUtility.HtmlEncode(m.Groups[1].Value) + "</code>");
                return "\u0001" + (codes.Count - 1) + "\u0002";
            });

            s = WebUtility.HtmlEncode(s);
            s = Regex.Replace(s, @"!\[([^\]]*)\]\(([^)]+)\)", m =>
                "<img src=\"" + EncodePath(WebUtility.HtmlDecode(m.Groups[2].Value)) + "\" alt=\"" + m.Groups[1].Value + "\">");
            s = Regex.Replace(s, @"\[([^\]]+)\]\(([^)]+)\)", m =>
                "<a href=\"" + EncodePath(WebUtility.HtmlDecode(m.Groups[2].Value)) + "\">" + m.Groups[1].Value + "</a>");
            s = Regex.Replace(s, @"\*\*(.+?)\*\*", "<strong>$1</strong>");
            return Regex.Replace(s, "\u0001(\\d+)\u0002", m => codes[int.Parse(m.Groups[1].Value)]);
        }

        /// <summary>상대 경로의 한글·공백을 URL 형식으로 (http·#는 그대로).</summary>
        private static string EncodePath(string path)
        {
            if (path.StartsWith("#") || Regex.IsMatch(path, "^[a-zA-Z][a-zA-Z0-9+.-]*:"))
            {
                return WebUtility.HtmlEncode(path);
            }

            return string.Join("/", path.Split('/').Select(Uri.EscapeDataString));
        }

        /// <summary>제목 표시용: Markdown 기호를 뺀 글자.</summary>
        private static string Plain(string text)
        {
            var s = Regex.Replace(text, @"!?\[([^\]]*)\]\([^)]*\)", "$1");
            return s.Replace("**", "").Replace("`", "").Trim();
        }

        /// <summary>
        /// WebBrowser에 넣을 전체 HTML. baseFolder는 문서·그림(images\)이 있는 폴더.
        /// 그림은 data: 주소로 넣는다 (DocumentText 페이지에서는 보안 때문에 로컬 그림 파일을 못 읽는다).
        /// </summary>
        public string ToPage(string baseFolder)
        {
            var baseUri = new Uri(baseFolder.TrimEnd('\\') + "\\").AbsoluteUri;
            var body = Regex.Replace(BodyHtml, "<img src=\"([^\"#:]+)\"", m =>
            {
                var file = Path.Combine(baseFolder, Uri.UnescapeDataString(m.Groups[1].Value).Replace('/', '\\'));
                if (!File.Exists(file))
                {
                    return m.Value;
                }

                var mime = file.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ? "image/png"
                    : file.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ? "image/gif" : "image/jpeg";
                return "<img src=\"data:" + mime + ";base64," + Convert.ToBase64String(File.ReadAllBytes(file)) + "\"";
            });
            return "<!DOCTYPE html><html><head><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><meta charset=\"utf-8\">"
                   + "<base href=\"" + baseUri + "\"><style>" + Css + "</style></head><body>" + body + "</body></html>";
        }

        private const string Css =
            "html{scrollbar-base-color:#404040;scrollbar-face-color:#555;scrollbar-track-color:#2a2a2a;scrollbar-arrow-color:#aaa;scrollbar-shadow-color:#2a2a2a;scrollbar-highlight-color:#2a2a2a;scrollbar-3dlight-color:#2a2a2a;scrollbar-darkshadow-color:#2a2a2a}"
            + "body{background:#212121;color:#ececec;font-family:'NanumGothic','나눔고딕','Malgun Gothic','맑은 고딕',sans-serif;font-size:15px;line-height:1.65;margin:18px 28px 60px 24px}"
            + "h1{font-size:26px;color:#fff;border-bottom:2px solid #bc8f8f;padding-bottom:6px;margin-top:4px}"
            + "h2{font-size:21px;color:#fff;border-bottom:1px solid #404040;padding-bottom:4px;margin-top:34px}"
            + "h3{font-size:17px;color:#e8c3c3;margin-top:24px}h4{font-size:15px;color:#e8c3c3}"
            + "a{color:#7fb8e6}strong{color:#fff}"
            + "code{background:#38383a;color:#f0d9a8;padding:1px 5px;font-family:Consolas,'D2Coding',monospace;font-size:13.5px}"
            + "pre{background:#2b2b2d;border:1px solid #404040;padding:10px 14px;overflow:auto}pre code{background:none;padding:0;color:#e6e6e6}"
            + "table{border-collapse:collapse;margin:10px 0}th,td{border:1px solid #4a4a4a;padding:6px 10px;vertical-align:top}th{background:#333;color:#fff}tr:nth-child(even) td{background:#2a2a2c}"
            + "blockquote{border-left:4px solid #bc8f8f;background:#2a2a2c;margin:12px 0;padding:6px 14px;color:#dcdcdc}blockquote p{margin:4px 0}"
            + "img{max-width:100%;border:1px solid #404040;margin:6px 0}hr{border:0;border-top:1px solid #404040;margin:24px 0}"
            + "li{margin:3px 0}.hit{background:#6b5a1e}";
    }
}
