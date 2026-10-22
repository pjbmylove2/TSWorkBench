using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TSWorkBench.Models
{
    /// <summary>업무 카드 1건. 현장 출동·분석·수정·점검 등 모든 TS 업무가 같은 구조를 쓴다.</summary>
    public sealed class WorkItem
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public WorkType Type { get; set; } = WorkType.FieldVisit;
        public WorkStatus Status { get; set; } = WorkStatus.Received;
        public Priority Priority { get; set; } = Priority.Normal;

        // 어디의 무엇인가: 고객사 > 사이트/라인 > 설비 > 대상 시스템
        public string Customer { get; set; } = "";
        public string Site { get; set; } = "";
        public string Equipment { get; set; } = "";
        public string TargetSystem { get; set; } = "";
        public string Tags { get; set; } = "";
        public string Requester { get; set; } = "";

        public DateTime ReceivedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }

        // 현상
        public string Symptom { get; set; } = "";
        public string SymptomWhen { get; set; } = "";
        public string Reproduction { get; set; } = "";
        public string Impact { get; set; } = "";

        // 원인
        public string Cause { get; set; } = "";
        public string CauseEvidence { get; set; } = "";

        // 조치
        public string ActionHardware { get; set; } = "";
        public string ActionSoftware { get; set; } = "";
        public string ChangedFiles { get; set; } = "";

        // 검증·재발방지
        public string Verification { get; set; } = "";
        public string Prevention { get; set; } = "";
        public string CustomerNote { get; set; } = "";
        public bool NeedsRevisit { get; set; }
        public DateTime? RevisitDate { get; set; }

        public string ParentId { get; set; } = "";
        public string ImportedFrom { get; set; } = "";

        /// <summary>접수 일시를 고쳐 ID를 다시 받았을 때의 예전 ID. 그 번호는 다시 쓰지 않는다.</summary>
        public List<string> PreviousIds { get; set; } = new List<string>();

        public List<TimelineEntry> Timeline { get; set; } = new List<TimelineEntry>();
        public List<ChecklistItem> Checklist { get; set; } = new List<ChecklistItem>();
        public List<AttachmentRef> Attachments { get; set; } = new List<AttachmentRef>();

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [JsonIgnore]
        public bool IsActive => Status != WorkStatus.Done && Status != WorkStatus.Canceled;

        public bool IsOverdue(DateTime today)
        {
            return IsActive && DueDate.HasValue && DueDate.Value.Date < today.Date;
        }

        /// <summary>완료까지 걸린 일수. 완료 전이면 null.</summary>
        [JsonIgnore]
        public double? LeadDays => CompletedAt.HasValue ? (CompletedAt.Value - ReceivedAt).TotalDays : (double?)null;

        [JsonIgnore]
        public string Location
        {
            get
            {
                var parts = new[] { Customer, Site, Equipment }.Where(s => !string.IsNullOrWhiteSpace(s));
                return string.Join(" / ", parts);
            }
        }

        /// <summary>검색용으로 모든 글자 필드를 이어 붙인다.</summary>
        public string SearchText()
        {
            return string.Join("\n", Id, Title, Customer, Site, Equipment, TargetSystem, Tags, Requester,
                Symptom, SymptomWhen, Reproduction, Impact, Cause, CauseEvidence,
                ActionHardware, ActionSoftware, ChangedFiles, Verification, Prevention, CustomerNote,
                string.Join("\n", Timeline.Select(t => t.Text)));
        }
    }

    public sealed class TimelineEntry
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public TimelineKind Kind { get; set; } = TimelineKind.Note;
        public string Text { get; set; } = "";

        [JsonIgnore]
        public double Hours => End.HasValue && End.Value > Start ? (End.Value - Start).TotalHours : 0;
    }

    public sealed class ChecklistItem
    {
        public string Text { get; set; } = "";
        public bool Done { get; set; }
    }

    public sealed class AttachmentRef
    {
        public string Name { get; set; } = "";

        /// <summary>Copied이면 업무 폴더 기준 상대 경로(files\...), 아니면 원본 절대 경로.</summary>
        public string Path { get; set; } = "";
        public bool Copied { get; set; }
        public string Note { get; set; } = "";
    }
}
