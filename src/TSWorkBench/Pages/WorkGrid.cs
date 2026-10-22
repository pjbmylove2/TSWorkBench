using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Theme;

namespace TSWorkBench.Pages
{
    /// <summary>
    /// 업무 목록 그리드 채우기. 각 열의 DataPropertyName(Id, Status, DueDate …)을 보고 값을 넣으므로
    /// 디자이너에서 열 순서·너비를 바꿔도 코드는 그대로 둔다.
    /// </summary>
    public static class WorkGrid
    {
        public static void Fill(DataGridView grid, IEnumerable<WorkItem> items)
        {
            var selectedId = (grid.CurrentRow?.Tag as WorkItem)?.Id;
            var today = DateTime.Today;
            var columns = grid.Columns.Cast<DataGridViewColumn>().OrderBy(c => c.Index).ToList();

            grid.SuspendLayout();
            grid.Rows.Clear();
            foreach (var item in items)
            {
                var row = grid.Rows[grid.Rows.Add(columns.Select(c => ValueFor(item, c.DataPropertyName)).ToArray())];
                row.Tag = item;
                foreach (var c in columns)
                {
                    var color = ColorFor(item, c.DataPropertyName, today);
                    if (color.HasValue)
                    {
                        row.Cells[c.Index].Style.ForeColor = color.Value;
                        row.Cells[c.Index].Style.SelectionForeColor = color.Value;
                    }
                }

                if (item.Id == selectedId)
                {
                    grid.CurrentCell = row.Cells[columns.First(c => c.Visible).Index];
                }
            }

            grid.ResumeLayout();
        }

        public static object ValueFor(WorkItem item, string key)
        {
            switch (key)
            {
                case "Id": return item.Id;
                case "Title": return item.Title;
                case "Type": return Labels.Of(item.Type);
                case "Status": return Labels.Of(item.Status);
                case "Priority": return Labels.Of(item.Priority);
                case "Customer": return item.Customer;
                case "Site": return item.Site;
                case "Equipment": return item.Equipment;
                case "TargetSystem": return item.TargetSystem;
                case "Location": return item.Location;
                case "ReceivedAt": return ReportGenerator.Day(item.ReceivedAt);
                case "DueDate": return ReportGenerator.Day(item.DueDate);
                case "CompletedAt": return ReportGenerator.Day(item.CompletedAt);
                case "Tags": return item.Tags;
                default: return "";
            }
        }

        private static System.Drawing.Color? ColorFor(WorkItem item, string key, DateTime today)
        {
            switch (key)
            {
                case "Status": return DarkTheme.StatusColor(item.Status);
                case "Priority": return DarkTheme.PriorityColor(item.Priority);
                case "DueDate":
                    if (item.IsOverdue(today))
                    {
                        return DarkTheme.Danger;
                    }

                    return item.IsActive && item.DueDate.HasValue && item.DueDate.Value.Date <= today.AddDays(2) ? DarkTheme.Warning : (System.Drawing.Color?)null;
                default: return null;
            }
        }
    }
}
