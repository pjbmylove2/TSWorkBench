using System;
using System.Collections.Generic;
using System.Linq;

namespace TSWorkBench.Models
{
    /// <summary>열거형 값을 화면·보고서에 쓰는 한글 이름으로 바꾼다.</summary>
    public static class Labels
    {
        private static readonly Dictionary<Enum, string> Names = new Dictionary<Enum, string>
        {
            { WorkType.FieldVisit, "현장 출동" },
            { WorkType.RemoteAnalysis, "원격·사무실 분석" },
            { WorkType.ProgramChange, "프로그램 수정" },
            { WorkType.HardwareFix, "HW 조치" },
            { WorkType.PreventiveCheck, "정기·예방 점검" },
            { WorkType.Improvement, "개선 과제" },
            { WorkType.Inquiry, "문의 응대" },
            { WorkType.FollowUp, "후속 확인" },
            { WorkType.Other, "기타" },

            { WorkStatus.Received, "접수" },
            { WorkStatus.Analyzing, "분석" },
            { WorkStatus.InProgress, "조치 중" },
            { WorkStatus.Verifying, "검증(모니터링)" },
            { WorkStatus.Done, "완료" },
            { WorkStatus.OnHold, "보류" },
            { WorkStatus.Canceled, "취소" },

            { Priority.Urgent, "긴급" },
            { Priority.High, "높음" },
            { Priority.Normal, "보통" },
            { Priority.Low, "낮음" },

            { TimelineKind.Contact, "연락 수신" },
            { TimelineKind.Call, "통화·메일" },
            { TimelineKind.Travel, "이동" },
            { TimelineKind.OnSite, "현장 작업" },
            { TimelineKind.Remote, "원격 작업" },
            { TimelineKind.Analysis, "사무실 분석" },
            { TimelineKind.Meeting, "회의" },
            { TimelineKind.Note, "메모" },
            { TimelineKind.StatusChange, "상태 변경" }
        };

        public static string Of(Enum value)
        {
            string name;
            return Names.TryGetValue(value, out name) ? name : value.ToString();
        }

        public static List<Choice<T>> Choices<T>() where T : struct, Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Select(v => new Choice<T>(v, Of(v))).ToList();
        }
    }

    /// <summary>콤보박스 항목: 값과 표시 이름.</summary>
    public sealed class Choice<T>
    {
        public Choice(T value, string text)
        {
            Value = value;
            Text = text;
        }

        public T Value { get; }
        public string Text { get; }

        public override string ToString()
        {
            return Text;
        }
    }
}
