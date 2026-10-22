using System;
using System.Collections.Generic;
using System.Linq;
using TSWorkBench.Models;

namespace TSWorkBench.Services
{
    public sealed class PeriodStats
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Received { get; set; }
        public int Done { get; set; }
        public int ActiveNow { get; set; }
        public int OverdueNow { get; set; }
        public double AvgLeadDays { get; set; }
        public double OnSiteHours { get; set; }
        public double TravelHours { get; set; }
        public double RemoteHours { get; set; }
        public List<KeyValuePair<string, int>> ByType { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> ByCustomer { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> ByEquipment { get; set; } = new List<KeyValuePair<string, int>>();
        public List<KeyValuePair<string, int>> BySystem { get; set; } = new List<KeyValuePair<string, int>>();
    }

    /// <summary>기간 통계. 기간은 [from, to) — to는 포함하지 않는다.</summary>
    public static class StatsService
    {
        public const int TopCount = 5;

        public static bool InRange(DateTime value, DateTime from, DateTime to)
        {
            return value >= from && value < to;
        }

        /// <summary>기간 안에 접수됐거나 완료된 업무.</summary>
        public static IEnumerable<WorkItem> Touched(IEnumerable<WorkItem> items, DateTime from, DateTime to)
        {
            return items.Where(i => InRange(i.ReceivedAt, from, to)
                                    || (i.CompletedAt.HasValue && InRange(i.CompletedAt.Value, from, to)));
        }

        public static PeriodStats Compute(IReadOnlyCollection<WorkItem> items, DateTime from, DateTime to, DateTime today)
        {
            var touched = Touched(items, from, to).ToList();
            var done = items.Where(i => i.Status == WorkStatus.Done && i.CompletedAt.HasValue && InRange(i.CompletedAt.Value, from, to)).ToList();
            var entries = items.SelectMany(i => i.Timeline).Where(t => InRange(t.Start, from, to)).ToList();

            return new PeriodStats
            {
                From = from,
                To = to,
                Received = items.Count(i => InRange(i.ReceivedAt, from, to)),
                Done = done.Count,
                ActiveNow = items.Count(i => i.IsActive && i.ReceivedAt < to),
                OverdueNow = items.Count(i => i.IsOverdue(today) && i.ReceivedAt < to),
                AvgLeadDays = done.Count == 0 ? 0 : done.Average(i => i.LeadDays ?? 0),
                OnSiteHours = entries.Where(t => t.Kind == TimelineKind.OnSite).Sum(t => t.Hours),
                TravelHours = entries.Where(t => t.Kind == TimelineKind.Travel).Sum(t => t.Hours),
                RemoteHours = entries.Where(t => t.Kind == TimelineKind.Remote || t.Kind == TimelineKind.Analysis).Sum(t => t.Hours),
                ByType = Top(touched.Select(i => Labels.Of(i.Type)), int.MaxValue),
                ByCustomer = Top(touched.Select(i => i.Customer), TopCount),
                ByEquipment = Top(touched.Select(i => i.Equipment), TopCount),
                BySystem = Top(touched.Select(i => i.TargetSystem), TopCount)
            };
        }

        private static List<KeyValuePair<string, int>> Top(IEnumerable<string> values, int count)
        {
            return values.Where(v => !string.IsNullOrWhiteSpace(v))
                .GroupBy(v => v.Trim())
                .Select(g => new KeyValuePair<string, int>(g.Key, g.Count()))
                .OrderByDescending(p => p.Value).ThenBy(p => p.Key)
                .Take(count)
                .ToList();
        }
    }
}
