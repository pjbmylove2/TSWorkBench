using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using TSWorkBench.Models;

namespace TSWorkBench.Services
{
    /// <summary>업무대장 xlsx: 1번 시트는 업무 목록, 2번 시트는 기간 통계.</summary>
    public static class ExcelExporter
    {
        private static readonly string[] Headers =
        {
            "ID", "접수일", "기한", "완료일", "처리일수", "상태", "우선순위", "유형", "고객사", "사이트/라인", "설비", "대상 시스템",
            "제목", "현상", "원인", "HW 조치", "SW 조치", "변경 내역", "검증 결과", "재발 방지", "작업시간(h)", "태그", "원본 업무"
        };

        public static void Export(string path, IReadOnlyCollection<WorkItem> items, PeriodStats stats, string title)
        {
            using (var book = new XLWorkbook())
            {
                WriteList(book.Worksheets.Add("업무대장"), items);
                WriteStats(book.Worksheets.Add("통계"), stats, title);
                book.SaveAs(path);
            }
        }

        private static void WriteList(IXLWorksheet sheet, IReadOnlyCollection<WorkItem> items)
        {
            for (var c = 0; c < Headers.Length; c++)
            {
                sheet.Cell(1, c + 1).Value = Headers[c];
            }

            var row = 2;
            foreach (var i in items.OrderBy(x => x.ReceivedAt))
            {
                object[] values =
                {
                    i.Id, i.ReceivedAt.Date, (object)i.DueDate ?? "", (object)i.CompletedAt?.Date ?? "",
                    i.LeadDays.HasValue ? (object)Math.Round(i.LeadDays.Value, 1) : "",
                    Labels.Of(i.Status), Labels.Of(i.Priority), Labels.Of(i.Type),
                    i.Customer, i.Site, i.Equipment, i.TargetSystem, i.Title, i.Symptom, i.Cause,
                    i.ActionHardware, i.ActionSoftware, i.ChangedFiles, i.Verification, i.Prevention,
                    Math.Round(i.Timeline.Sum(t => t.Hours), 1), i.Tags, i.ParentId
                };
                for (var c = 0; c < values.Length; c++)
                {
                    sheet.Cell(row, c + 1).Value = values[c];
                }

                var statusCell = sheet.Cell(row, 6);
                statusCell.Style.Fill.BackgroundColor = XLColor.FromHtml(StatusHex(i.Status));
                statusCell.Style.Font.FontColor = XLColor.White;
                row++;
            }

            var header = sheet.Range(1, 1, 1, Headers.Length);
            header.Style.Font.Bold = true;
            header.Style.Font.FontColor = XLColor.White;
            header.Style.Fill.BackgroundColor = XLColor.FromHtml("#404040");

            sheet.Range(1, 1, Math.Max(row - 1, 1), Headers.Length).SetAutoFilter();
            sheet.SheetView.FreezeRows(1);
            sheet.Columns(2, 4).Style.DateFormat.Format = "yyyy-mm-dd";
            sheet.Columns().AdjustToContents(8.0, 40.0);
            sheet.Range(2, 13, Math.Max(row - 1, 2), 20).Style.Alignment.WrapText = true;
        }

        private static void WriteStats(IXLWorksheet sheet, PeriodStats s, string title)
        {
            sheet.Cell(1, 1).Value = title;
            sheet.Cell(1, 1).Style.Font.Bold = true;
            sheet.Cell(1, 1).Style.Font.FontSize = 14;

            var rows = new List<object[]>
            {
                new object[] { "기간", s.From.ToString("yyyy-MM-dd") + " ~ " + s.To.AddDays(-1).ToString("yyyy-MM-dd") },
                new object[] { "접수", s.Received },
                new object[] { "완료", s.Done },
                new object[] { "현재 진행 중", s.ActiveNow },
                new object[] { "기한 지남", s.OverdueNow },
                new object[] { "평균 처리일수", Math.Round(s.AvgLeadDays, 1) },
                new object[] { "현장 작업(h)", Math.Round(s.OnSiteHours, 1) },
                new object[] { "이동(h)", Math.Round(s.TravelHours, 1) },
                new object[] { "원격·분석(h)", Math.Round(s.RemoteHours, 1) }
            };

            var r = 3;
            foreach (var pair in rows)
            {
                sheet.Cell(r, 1).Value = pair[0];
                sheet.Cell(r, 2).Value = pair[1];
                r++;
            }

            r = WriteGroup(sheet, r + 1, "유형별", s.ByType);
            r = WriteGroup(sheet, r + 1, "고객사 Top", s.ByCustomer);
            r = WriteGroup(sheet, r + 1, "설비 Top", s.ByEquipment);
            WriteGroup(sheet, r + 1, "대상 시스템 Top", s.BySystem);
            sheet.Column(1).Width = 20;
            sheet.Column(2).Width = 30;
        }

        private static int WriteGroup(IXLWorksheet sheet, int row, string title, List<KeyValuePair<string, int>> pairs)
        {
            sheet.Cell(row, 1).Value = title;
            sheet.Cell(row, 1).Style.Font.Bold = true;
            row++;
            foreach (var p in pairs)
            {
                sheet.Cell(row, 1).Value = p.Key;
                sheet.Cell(row, 2).Value = p.Value;
                row++;
            }

            return row;
        }

        public static string StatusHex(WorkStatus status)
        {
            switch (status)
            {
                case WorkStatus.Received: return "#3498DB";
                case WorkStatus.Analyzing: return "#9B59B6";
                case WorkStatus.InProgress: return "#E67E22";
                case WorkStatus.Verifying: return "#C9A227";
                case WorkStatus.Done: return "#27AE60";
                case WorkStatus.OnHold: return "#7F8C8D";
                default: return "#696969";
            }
        }
    }
}
