using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TSWorkBench.Models;
using TSWorkBench.Storage;

namespace TSWorkBench.Services
{
    /// <summary>
    /// 업무 카드와 기간 데이터로 문서를 만든다. 모양은 데이터 폴더 Templates\의 파일이 정하므로
    /// 회사·고객 양식이 달라지면 템플릿만 고치면 된다.
    /// </summary>
    public sealed class ReportGenerator
    {
        public const string FieldReportTemplate = "field-report.html";
        public const string ItemMarkdownTemplate = "item-notion.md";
        public const string PeriodMarkdownTemplate = "period-report.md";
        public const string PeriodHtmlTemplate = "period-report.html";

        private static readonly string[] ImageExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
        private readonly Workspace ws;

        public ReportGenerator(Workspace ws)
        {
            this.ws = ws;
        }

        public static string Day(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : "";
        }

        public static string Minute(DateTime? value)
        {
            return value.HasValue ? value.Value.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture) : "";
        }

        public static string Hours(double hours)
        {
            return hours.ToString("0.#", CultureInfo.InvariantCulture);
        }

        /// <summary>현장 조치 보고서를 업무 폴더에 저장하고 경로를 돌려준다. 사진은 files\를 상대 경로로 참조한다.</summary>
        public string SaveFieldReport(WorkItem item)
        {
            var html = TemplateEngine.Render(ws.ReadTemplate(FieldReportTemplate), ItemFields(item, new HtmlFormat()));
            var path = Path.Combine(ws.Items.FolderOf(item), "보고서_" + item.Id + ".html");
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllText(path, html, Encoding.UTF8);
            return path;
        }

        public string ItemMarkdown(WorkItem item)
        {
            return TemplateEngine.Render(ws.ReadTemplate(ItemMarkdownTemplate), ItemFields(item, new MarkdownFormat()));
        }

        public string PeriodMarkdown(string title, DateTime from, DateTime to, DateTime today)
        {
            return TemplateEngine.Render(ws.ReadTemplate(PeriodMarkdownTemplate), PeriodFields(title, from, to, today, new MarkdownFormat()));
        }

        public string PeriodHtml(string title, DateTime from, DateTime to, DateTime today)
        {
            return TemplateEngine.Render(ws.ReadTemplate(PeriodHtmlTemplate), PeriodFields(title, from, to, today, new HtmlFormat()));
        }

        /// <summary>기간 보고를 Reports\에 MD·HTML 두 파일로 저장한다.</summary>
        public string[] SavePeriodReport(string title, DateTime from, DateTime to, DateTime today)
        {
            Directory.CreateDirectory(ws.ReportsDir);
            var stem = title.Replace(" ", "") + "_" + Day(from) + "_" + Day(to.AddDays(-1));
            var md = Path.Combine(ws.ReportsDir, stem + ".md");
            var html = Path.Combine(ws.ReportsDir, stem + ".html");
            File.WriteAllText(md, PeriodMarkdown(title, from, to, today), new UTF8Encoding(false));
            File.WriteAllText(html, PeriodHtml(title, from, to, today), Encoding.UTF8);
            return new[] { md, html };
        }

        internal Dictionary<string, string> ItemFields(WorkItem item, IFormat f)
        {
            var values = new Dictionary<string, string>
            {
                { "Id", f.Text(item.Id) },
                { "Title", f.Text(item.Title) },
                { "Type", f.Text(Labels.Of(item.Type)) },
                { "Status", f.Text(Labels.Of(item.Status)) },
                { "Priority", f.Text(Labels.Of(item.Priority)) },
                { "Customer", f.Block(item.Customer) },
                { "Site", f.Block(item.Site) },
                { "Equipment", f.Block(item.Equipment) },
                { "TargetSystem", f.Block(item.TargetSystem) },
                { "Location", f.Block(item.Location) },
                { "Tags", f.Block(item.Tags) },
                { "Requester", f.Block(item.Requester) },
                { "ReceivedAt", f.Text(Minute(item.ReceivedAt)) },
                { "DueDate", f.Block(Day(item.DueDate)) },
                { "CompletedAt", f.Block(Minute(item.CompletedAt)) },
                { "Symptom", f.Block(item.Symptom) },
                { "SymptomWhen", f.Block(item.SymptomWhen) },
                { "Reproduction", f.Block(item.Reproduction) },
                { "Impact", f.Block(item.Impact) },
                { "Cause", f.Block(item.Cause) },
                { "CauseEvidence", f.Block(item.CauseEvidence) },
                { "ActionHardware", f.Block(item.ActionHardware) },
                { "ActionSoftware", f.Block(item.ActionSoftware) },
                { "ChangedFiles", f.Block(item.ChangedFiles) },
                { "Verification", f.Block(item.Verification) },
                { "Prevention", f.Block(item.Prevention) },
                { "CustomerNote", f.Block(item.CustomerNote) },
                { "Revisit", f.Text(item.NeedsRevisit ? "필요 (" + (Day(item.RevisitDate) == "" ? "일정 미정" : Day(item.RevisitDate)) + ")" : "불필요") },
                { "TotalHours", f.Text(Hours(item.Timeline.Sum(t => t.Hours))) },
                { "Timeline", TimelineTable(item, f) },
                { "Checklist", ChecklistBlock(item, f) },
                { "Attachments", AttachmentList(item, f) },
                { "Photos", f is HtmlFormat ? Photos(item) : "" }
            };
            AddCommon(values, f);
            return values;
        }

        internal Dictionary<string, string> PeriodFields(string title, DateTime from, DateTime to, DateTime today, IFormat f)
        {
            var all = ws.Items.All.ToList();
            var stats = StatsService.Compute(all, from, to, today);
            var nextTo = to + (to - from);

            var done = all.Where(i => i.Status == WorkStatus.Done && i.CompletedAt.HasValue && StatsService.InRange(i.CompletedAt.Value, from, to))
                .OrderBy(i => i.CompletedAt).ToList();
            // 지난 기간 보고를 나중에 만들어도 그 기간 뒤에 접수된 업무는 넣지 않는다.
            var active = WorkQuery.SortForWork(all.Where(i => i.IsActive && i.ReceivedAt < to)).ToList();
            var overdue = active.Where(i => i.IsOverdue(today)).ToList();
            var planned = active.Where(i => i.DueDate.HasValue && i.DueDate.Value >= to && i.DueDate.Value < nextTo).ToList();

            var summary = new List<string>
            {
                "접수 " + stats.Received + "건, 완료 " + stats.Done + "건",
                "현재 진행 중 " + stats.ActiveNow + "건 (기한 지남 " + stats.OverdueNow + "건)",
                "평균 처리 기간 " + stats.AvgLeadDays.ToString("0.0", CultureInfo.InvariantCulture) + "일 (기간 내 완료 기준)",
                "현장 작업 " + Hours(stats.OnSiteHours) + "시간 · 이동 " + Hours(stats.TravelHours) + "시간 · 원격/분석 " + Hours(stats.RemoteHours) + "시간"
            };
            if (stats.ByType.Count > 0)
            {
                summary.Add("유형별: " + string.Join(", ", stats.ByType.Select(p => p.Key + " " + p.Value)));
            }

            var values = new Dictionary<string, string>
            {
                { "ReportTitle", f.Text(title) },
                { "Period", f.Text(Day(from) + " ~ " + Day(to.AddDays(-1))) },
                { "NextPeriod", f.Text(Day(to) + " ~ " + Day(nextTo.AddDays(-1))) },
                { "Summary", f.Bullets(summary) },
                { "DoneCount", stats.Done.ToString(CultureInfo.InvariantCulture) },
                { "DoneList", f.Table(new[] { "ID", "완료일", "위치", "제목", "원인", "조치" },
                    done.Select(i => new[] { i.Id, Day(i.CompletedAt), i.Location, i.Title, FirstLine(i.Cause), FirstLine(Join(i.ActionHardware, i.ActionSoftware)) })) },
                { "ActiveCount", active.Count.ToString(CultureInfo.InvariantCulture) },
                { "ActiveList", f.Table(new[] { "ID", "상태", "우선", "기한", "위치", "제목", "다음 할 일/현재 상황" },
                    active.Select(i => new[] { i.Id, Labels.Of(i.Status), Labels.Of(i.Priority), Day(i.DueDate), i.Location, i.Title, FirstLine(CurrentNote(i)) })) },
                { "OverdueList", f.Table(new[] { "ID", "기한", "위치", "제목" },
                    overdue.Select(i => new[] { i.Id, Day(i.DueDate), i.Location, i.Title })) },
                { "PlannedList", f.Table(new[] { "ID", "기한", "유형", "위치", "제목" },
                    planned.Select(i => new[] { i.Id, Day(i.DueDate), Labels.Of(i.Type), i.Location, i.Title })) },
                { "TopIssues", f.Table(new[] { "구분", "상위 항목 (건수)" }, new[]
                    {
                        new[] { "고객사", TopText(stats.ByCustomer) },
                        new[] { "설비", TopText(stats.ByEquipment) },
                        new[] { "대상 시스템", TopText(stats.BySystem) }
                    }) }
            };
            AddCommon(values, f);
            return values;
        }

        private void AddCommon(Dictionary<string, string> values, IFormat f)
        {
            values["Author"] = f.Text(ws.Settings.UserName);
            values["Department"] = f.Text(ws.Settings.Department);
            values["Company"] = f.Text(ws.Settings.Company);
            values["GeneratedAt"] = f.Text(Minute(DateTime.Now));
        }

        private static string TimelineTable(WorkItem item, IFormat f)
        {
            return f.Table(new[] { "시작", "종료", "구분", "시간(h)", "내용" },
                item.Timeline.OrderBy(t => t.Start).Select(t => new[]
                {
                    Minute(t.Start), Minute(t.End), Labels.Of(t.Kind), t.Hours > 0 ? Hours(t.Hours) : "", t.Text
                }));
        }

        private static string ChecklistBlock(WorkItem item, IFormat f)
        {
            return f.Bullets(item.Checklist.Select(c => (c.Done ? "[x] " : "[ ] ") + c.Text));
        }

        private string AttachmentList(WorkItem item, IFormat f)
        {
            return f.Bullets(item.Attachments.Select(a => a.Name + (a.Copied ? "" : " (원본: " + a.Path + ")") + (string.IsNullOrWhiteSpace(a.Note) ? "" : " - " + a.Note)));
        }

        private string Photos(WorkItem item)
        {
            var sb = new StringBuilder();
            foreach (var a in item.Attachments.Where(a => ImageExtensions.Contains(Path.GetExtension(a.Path).ToLowerInvariant())))
            {
                var src = a.Copied ? a.Path.Replace('\\', '/') : new Uri(a.Path).AbsoluteUri;
                sb.Append("<figure><img src=\"").Append(WebUtility.HtmlEncode(src)).Append("\" alt=\"\"><figcaption>")
                  .Append(WebUtility.HtmlEncode(string.IsNullOrWhiteSpace(a.Note) ? a.Name : a.Note))
                  .Append("</figcaption></figure>\n");
            }

            return sb.Length == 0 ? "<p class=\"muted\">첨부 사진 없음</p>" : sb.ToString();
        }

        private static string CurrentNote(WorkItem item)
        {
            var lastNote = item.Timeline.Where(t => t.Kind != TimelineKind.StatusChange && !string.IsNullOrWhiteSpace(t.Text))
                .OrderBy(t => t.Start).LastOrDefault();
            return lastNote != null ? lastNote.Text : item.Symptom;
        }

        private static string TopText(List<KeyValuePair<string, int>> pairs)
        {
            return pairs.Count == 0 ? "-" : string.Join(", ", pairs.Select(p => p.Key + " (" + p.Value + ")"));
        }

        private static string Join(string a, string b)
        {
            return string.Join(" / ", new[] { a, b }.Where(s => !string.IsNullOrWhiteSpace(s)));
        }

        public static string FirstLine(string text, int max = 60)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return "";
            }

            var line = text.Trim().Split('\n')[0].Trim();
            return line.Length > max ? line.Substring(0, max) + "…" : line;
        }

        internal interface IFormat
        {
            /// <summary>한 줄 값.</summary>
            string Text(string value);

            /// <summary>여러 줄일 수 있는 값. 비어 있으면 "-".</summary>
            string Block(string value);

            string Bullets(IEnumerable<string> lines);

            string Table(string[] headers, IEnumerable<string[]> rows);
        }

        internal sealed class MarkdownFormat : IFormat
        {
            public string Text(string value)
            {
                return value ?? "";
            }

            public string Block(string value)
            {
                return string.IsNullOrWhiteSpace(value) ? "-" : value.Replace("\r\n", "\n").Trim();
            }

            public string Bullets(IEnumerable<string> lines)
            {
                var list = lines.ToList();
                return list.Count == 0 ? "- 없음" : string.Join("\n", list.Select(l => "- " + l));
            }

            public string Table(string[] headers, IEnumerable<string[]> rows)
            {
                var list = rows.ToList();
                if (list.Count == 0)
                {
                    return "없음";
                }

                var sb = new StringBuilder();
                sb.Append("| ").Append(string.Join(" | ", headers)).Append(" |\n");
                sb.Append("|").Append(string.Concat(headers.Select(_ => " --- |"))).Append("\n");
                foreach (var row in list)
                {
                    sb.Append("| ").Append(string.Join(" | ", row.Select(Cell))).Append(" |\n");
                }

                return sb.ToString().TrimEnd('\n');
            }

            private static string Cell(string value)
            {
                return (value ?? "").Replace("|", "\\|").Replace("\r\n", "<br>").Replace("\n", "<br>");
            }
        }

        internal sealed class HtmlFormat : IFormat
        {
            public string Text(string value)
            {
                return WebUtility.HtmlEncode(value ?? "");
            }

            public string Block(string value)
            {
                return string.IsNullOrWhiteSpace(value)
                    ? "<span class=\"muted\">-</span>"
                    : WebUtility.HtmlEncode(value.Replace("\r\n", "\n").Trim()).Replace("\n", "<br>");
            }

            public string Bullets(IEnumerable<string> lines)
            {
                var list = lines.ToList();
                return list.Count == 0
                    ? "<p class=\"muted\">없음</p>"
                    : "<ul>" + string.Concat(list.Select(l => "<li>" + Text(l) + "</li>")) + "</ul>";
            }

            public string Table(string[] headers, IEnumerable<string[]> rows)
            {
                var list = rows.ToList();
                if (list.Count == 0)
                {
                    return "<p class=\"muted\">없음</p>";
                }

                var sb = new StringBuilder("<table><thead><tr>");
                foreach (var h in headers)
                {
                    sb.Append("<th>").Append(Text(h)).Append("</th>");
                }

                sb.Append("</tr></thead><tbody>");
                foreach (var row in list)
                {
                    sb.Append("<tr>");
                    foreach (var cell in row)
                    {
                        sb.Append("<td>").Append(Text(cell).Replace("\n", "<br>")).Append("</td>");
                    }

                    sb.Append("</tr>");
                }

                return sb.Append("</tbody></table>").ToString();
            }
        }
    }
}
