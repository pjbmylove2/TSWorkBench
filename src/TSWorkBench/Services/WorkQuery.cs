using System;
using System.Collections.Generic;
using System.Linq;
using TSWorkBench.Models;

namespace TSWorkBench.Services
{
    /// <summary>목록·지식베이스 검색 조건.</summary>
    public sealed class WorkQuery
    {
        public string Text { get; set; } = "";
        public bool ActiveOnly { get; set; }
        public bool OverdueOnly { get; set; }
        public bool DoneOnly { get; set; }

        /// <summary>진행 중이고 오늘부터 N일 안에 기한인 업무.</summary>
        public int? DueWithinDays { get; set; }

        /// <summary>진행 중인 후속 확인 업무 또는 검증(모니터링) 단계 업무.</summary>
        public bool FollowUpOnly { get; set; }
        public WorkStatus? Status { get; set; }
        public WorkType? Type { get; set; }
        public string Customer { get; set; } = "";
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        /// <summary>띄어쓰기로 나눈 단어가 모두 들어 있어야 한다 (대소문자 무시).</summary>
        public static bool MatchesText(WorkItem item, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            var haystack = item.SearchText();
            return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .All(word => haystack.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public IEnumerable<WorkItem> Apply(IEnumerable<WorkItem> items, DateTime today)
        {
            return items.Where(i =>
                (!ActiveOnly || i.IsActive)
                && (!OverdueOnly || i.IsOverdue(today))
                && (!DoneOnly || i.Status == WorkStatus.Done)
                && (!DueWithinDays.HasValue || (i.IsActive && i.DueDate.HasValue && i.DueDate.Value.Date >= today.Date && i.DueDate.Value.Date <= today.Date.AddDays(DueWithinDays.Value)))
                && (!FollowUpOnly || (i.IsActive && (i.Type == WorkType.FollowUp || i.Status == WorkStatus.Verifying)))
                && (!Status.HasValue || i.Status == Status.Value)
                && (!Type.HasValue || i.Type == Type.Value)
                && (string.IsNullOrEmpty(Customer) || i.Customer == Customer)
                && InPeriod(i)
                && MatchesText(i, Text));
        }

        /// <summary>기간을 정했으면 그 안에 접수됐거나 완료된 업무만. To 날짜는 그날 끝까지 포함.</summary>
        private bool InPeriod(WorkItem item)
        {
            if (!From.HasValue && !To.HasValue)
            {
                return true;
            }

            var from = From.HasValue ? From.Value.Date : DateTime.MinValue;
            var to = To.HasValue ? To.Value.Date.AddDays(1) : DateTime.MaxValue;
            return StatsService.InRange(item.ReceivedAt, from, to)
                   || (item.CompletedAt.HasValue && StatsService.InRange(item.CompletedAt.Value, from, to));
        }

        /// <summary>진행 중이면 기한(없으면 맨 뒤)·우선순위 순, 나머지는 최근 순.</summary>
        public static IEnumerable<WorkItem> SortForWork(IEnumerable<WorkItem> items)
        {
            return items
                .OrderBy(i => i.IsActive ? 0 : 1)
                .ThenBy(i => i.IsActive ? (i.DueDate ?? DateTime.MaxValue) : DateTime.MaxValue)
                .ThenBy(i => i.Priority)
                .ThenByDescending(i => i.CompletedAt ?? i.ReceivedAt);
        }
    }
}
