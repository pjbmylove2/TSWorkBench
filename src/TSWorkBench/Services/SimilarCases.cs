using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TSWorkBench.Models;

namespace TSWorkBench.Services
{
    /// <summary>
    /// 지금 업무와 비슷한 과거 업무를 점수로 고른다.
    /// 같은 설비 +3, 같은 대상 시스템 +2, 같은 고객사 +1, 겹치는 태그 하나당 +2,
    /// 제목·현상의 단어가 상대 제목·현상·원인에 들어 있으면 하나당 +1 (최대 5).
    /// </summary>
    public static class SimilarCases
    {
        public const int MinScore = 3;
        private const int MaxWordScore = 5;
        private static readonly Regex Word = new Regex(@"[\p{L}\p{N}]{2,}", RegexOptions.Compiled);

        public static List<WorkItem> Find(WorkItem target, IEnumerable<WorkItem> all, int max = 20)
        {
            var words = Word.Matches(target.Title + " " + target.Symptom).Cast<Match>()
                .Select(m => m.Value).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
            var tags = SplitTags(target.Tags);

            return all
                .Where(i => !string.Equals(i.Id, target.Id, StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(target.Id))
                .Where(i => !ReferenceEquals(i, target))
                .Select(i => new { Item = i, Score = Score(target, words, tags, i) })
                .Where(x => x.Score >= MinScore)
                .OrderByDescending(x => x.Score)
                .ThenByDescending(x => x.Item.Status == WorkStatus.Done)
                .ThenByDescending(x => x.Item.CompletedAt ?? x.Item.ReceivedAt)
                .Take(max)
                .Select(x => x.Item)
                .ToList();
        }

        public static int Score(WorkItem target, List<string> words, HashSet<string> tags, WorkItem other)
        {
            var score = 0;
            if (Same(target.Equipment, other.Equipment))
            {
                score += 3;
            }

            if (Same(target.TargetSystem, other.TargetSystem))
            {
                score += 2;
            }

            if (Same(target.Customer, other.Customer))
            {
                score += 1;
            }

            score += 2 * SplitTags(other.Tags).Count(tags.Contains);

            var text = other.Title + "\n" + other.Symptom + "\n" + other.Cause;
            score += Math.Min(MaxWordScore, words.Count(w => text.IndexOf(w, StringComparison.OrdinalIgnoreCase) >= 0));
            return score;
        }

        private static bool Same(string a, string b)
        {
            return !string.IsNullOrWhiteSpace(a) && string.Equals(a.Trim(), (b ?? "").Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private static HashSet<string> SplitTags(string tags)
        {
            return new HashSet<string>((tags ?? "").Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.Trim()).Where(t => t.Length > 0), StringComparer.OrdinalIgnoreCase);
        }
    }
}
