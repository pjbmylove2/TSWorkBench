using System;
using System.Collections.Generic;
using TSWorkBench.Models;

namespace TSWorkBench.Services
{
    /// <summary>
    /// 상태 흐름: 접수 → 분석 → 조치 중 → 검증(모니터링) → 완료 (+ 보류·취소).
    /// 정해진 길로만 상태를 바꾸고, 바꿀 때마다 타임라인에 남긴다.
    /// </summary>
    public static class WorkflowRules
    {
        private static readonly Dictionary<WorkStatus, WorkStatus[]> Allowed = new Dictionary<WorkStatus, WorkStatus[]>
        {
            { WorkStatus.Received, new[] { WorkStatus.Analyzing, WorkStatus.InProgress, WorkStatus.Done, WorkStatus.OnHold, WorkStatus.Canceled } },
            { WorkStatus.Analyzing, new[] { WorkStatus.InProgress, WorkStatus.Verifying, WorkStatus.Done, WorkStatus.OnHold, WorkStatus.Canceled } },
            { WorkStatus.InProgress, new[] { WorkStatus.Analyzing, WorkStatus.Verifying, WorkStatus.Done, WorkStatus.OnHold, WorkStatus.Canceled } },
            { WorkStatus.Verifying, new[] { WorkStatus.InProgress, WorkStatus.Done, WorkStatus.OnHold } },
            { WorkStatus.OnHold, new[] { WorkStatus.Received, WorkStatus.Analyzing, WorkStatus.InProgress, WorkStatus.Canceled } },
            { WorkStatus.Done, new[] { WorkStatus.InProgress } },
            { WorkStatus.Canceled, new[] { WorkStatus.Received } }
        };

        /// <summary>현상·원인·조치를 먼저 남기도록, 이 유형은 원인·조치가 없어도 완료할 수 있다.</summary>
        private static readonly HashSet<WorkType> LightTypes = new HashSet<WorkType>
        {
            WorkType.Inquiry, WorkType.PreventiveCheck, WorkType.FollowUp
        };

        private static readonly HashSet<WorkType> FollowUpTypes = new HashSet<WorkType>
        {
            WorkType.FieldVisit, WorkType.HardwareFix, WorkType.ProgramChange
        };

        public static IReadOnlyList<WorkStatus> AllowedFrom(WorkStatus status)
        {
            return Allowed[status];
        }

        public static bool CanChange(WorkStatus from, WorkStatus to)
        {
            return Array.IndexOf(Allowed[from], to) >= 0;
        }

        /// <summary>기본 흐름의 다음 단계. 끝이면 null.</summary>
        public static WorkStatus? NextInFlow(WorkStatus status)
        {
            switch (status)
            {
                case WorkStatus.Received: return WorkStatus.Analyzing;
                case WorkStatus.Analyzing: return WorkStatus.InProgress;
                case WorkStatus.InProgress: return WorkStatus.Verifying;
                case WorkStatus.Verifying: return WorkStatus.Done;
                case WorkStatus.OnHold: return WorkStatus.InProgress;
                default: return null;
            }
        }

        public static void ChangeStatus(WorkItem item, WorkStatus to, DateTime now)
        {
            var from = item.Status;
            if (!CanChange(from, to))
            {
                throw new InvalidOperationException(Labels.Of(from) + " → " + Labels.Of(to) + " 변경은 허용되지 않습니다.");
            }

            item.Status = to;
            if (to == WorkStatus.Done)
            {
                item.CompletedAt = now;
            }
            else if (from == WorkStatus.Done)
            {
                item.CompletedAt = null;
            }

            item.Timeline.Add(new TimelineEntry
            {
                Start = now,
                Kind = TimelineKind.StatusChange,
                Text = "상태: " + Labels.Of(from) + " → " + Labels.Of(to)
            });
        }

        /// <summary>완료 전에 비어 있으면 안 되는 항목 이름.</summary>
        public static List<string> MissingForDone(WorkItem item)
        {
            var missing = new List<string>();
            if (string.IsNullOrWhiteSpace(item.Symptom))
            {
                missing.Add("현상");
            }

            if (!LightTypes.Contains(item.Type))
            {
                if (string.IsNullOrWhiteSpace(item.Cause))
                {
                    missing.Add("원인");
                }

                if (string.IsNullOrWhiteSpace(item.ActionHardware) && string.IsNullOrWhiteSpace(item.ActionSoftware))
                {
                    missing.Add("조치");
                }

                if (string.IsNullOrWhiteSpace(item.Verification))
                {
                    missing.Add("검증 결과");
                }
            }

            return missing;
        }

        /// <summary>완료된 업무에서 이어질 예정 업무(모니터링·재방문). ID는 저장할 때 붙는다.</summary>
        public static List<WorkItem> CreateFollowUps(WorkItem done, AppSettings settings, DateTime now)
        {
            var result = new List<WorkItem>();
            if (settings.FollowUpDays > 0 && FollowUpTypes.Contains(done.Type))
            {
                result.Add(Derive(done, now, WorkType.FollowUp, "[모니터링] ", Priority.Normal,
                    now.Date.AddDays(settings.FollowUpDays),
                    done.Id + " 조치 후 " + settings.FollowUpDays + "일간 재발 여부 확인"));
            }

            if (done.NeedsRevisit)
            {
                result.Add(Derive(done, now, WorkType.FieldVisit, "[재방문] ", Priority.High,
                    done.RevisitDate ?? now.Date.AddDays(1),
                    done.Id + " 재방문 필요. 사유: " + (string.IsNullOrWhiteSpace(done.CustomerNote) ? "(검증·재발방지 참고)" : done.CustomerNote)));
            }

            return result;
        }

        private static WorkItem Derive(WorkItem done, DateTime now, WorkType type, string titlePrefix, Priority priority, DateTime due, string symptom)
        {
            var item = new WorkItem
            {
                Title = titlePrefix + done.Title,
                Type = type,
                Priority = priority,
                Customer = done.Customer,
                Site = done.Site,
                Equipment = done.Equipment,
                TargetSystem = done.TargetSystem,
                Tags = done.Tags,
                Requester = done.Requester,
                ReceivedAt = now,
                DueDate = due,
                Symptom = symptom,
                ParentId = done.Id
            };
            item.Timeline.Add(new TimelineEntry { Start = now, Kind = TimelineKind.Note, Text = done.Id + " 완료 시 자동 생성" });
            return item;
        }
    }
}
