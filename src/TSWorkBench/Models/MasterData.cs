using System;
using System.Collections.Generic;
using System.Linq;

namespace TSWorkBench.Models
{
    /// <summary>기준 정보 1줄. Keywords는 가져오기 때 폴더·파일 이름에서 찾을 별칭(쉼표 구분).</summary>
    public sealed class MasterEntry
    {
        public string Name { get; set; } = "";
        public string Keywords { get; set; } = "";

        public IEnumerable<string> Terms()
        {
            yield return Name;
            foreach (var k in Keywords.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var term = k.Trim();
                if (term.Length > 0)
                {
                    yield return term;
                }
            }
        }
    }

    /// <summary>고객사·사이트·설비·대상 시스템 목록과 유형별 체크리스트 템플릿 (masters.json).</summary>
    public sealed class MasterData
    {
        public List<MasterEntry> Customers { get; set; } = new List<MasterEntry>();
        public List<MasterEntry> Sites { get; set; } = new List<MasterEntry>();
        public List<MasterEntry> Equipments { get; set; } = new List<MasterEntry>();
        public List<MasterEntry> Systems { get; set; } = new List<MasterEntry>();
        public Dictionary<WorkType, List<string>> Checklists { get; set; } = new Dictionary<WorkType, List<string>>();

        public List<string> ChecklistFor(WorkType type)
        {
            List<string> list;
            return Checklists.TryGetValue(type, out list) ? list : new List<string>();
        }

        public static MasterData CreateDefault()
        {
            var data = new MasterData();
            foreach (var name in new[] { "OCR 검사", "비전 검사", "PLC 통신", "카메라", "조명", "PC·OS", "네트워크" })
            {
                data.Systems.Add(new MasterEntry { Name = name });
            }

            data.Checklists[WorkType.FieldVisit] = new List<string>
            {
                "출동 전: 고객 담당자·출입 절차 확인",
                "출동 전: 노트북·충전기·LAN/시리얼 케이블·USB 준비",
                "출동 전: 현재 버전 프로그램·설정 백업본 준비",
                "출동 전: 예비 부품(케이블·조명·카메라 등) 확인",
                "도착 후: 조치 전 현상 사진·로그·화면 캡처 확보",
                "조치 전: 현재 프로그램·설정 백업",
                "조치 후: 고객 입회 하에 정상 동작 확인",
                "퇴실 전: 원복 방법·연락처 공유"
            };
            data.Checklists[WorkType.RemoteAnalysis] = new List<string>
            {
                "로그·이미지·설정 파일 수집",
                "발생 시각·빈도·범위 확인",
                "재현 조건 정리 (사무실 재현 여부)",
                "원인 가설과 근거 기록",
                "고객에게 중간 회신"
            };
            data.Checklists[WorkType.ProgramChange] = new List<string>
            {
                "변경 전 소스·설정 백업 (커밋/태그)",
                "변경 범위·영향 검토",
                "사무실 테스트 (재현 데이터로 확인)",
                "버전 번호 갱신",
                "배포 파일·롤백 파일 준비",
                "현장 적용 후 동작 확인",
                "변경 이력 기록 (파일·버전·설정 전→후)"
            };
            data.Checklists[WorkType.HardwareFix] = new List<string>
            {
                "교체 부품 모델·S/N 기록",
                "교체 전 설정값 기록",
                "교체 후 초점·조명·캘리브레이션 확인",
                "시험 생산으로 판정 결과 확인",
                "불량 부품 회수·RMA 처리"
            };
            data.Checklists[WorkType.PreventiveCheck] = new List<string>
            {
                "디스크 용량·로그 정리",
                "카메라 렌즈·조명 청소",
                "시간 동기화·백업 상태 확인",
                "이벤트 로그·오류 이력 확인",
                "점검 결과 고객 공유"
            };
            data.Checklists[WorkType.Improvement] = new List<string>
            {
                "문제 정의와 목표 수치",
                "대안 비교",
                "적용 계획·일정 합의",
                "적용 후 효과 측정"
            };
            data.Checklists[WorkType.Inquiry] = new List<string>
            {
                "질문 내용 정리",
                "답변·근거 자료 전달",
                "지식베이스(FAQ) 등록 여부 판단"
            };
            data.Checklists[WorkType.FollowUp] = new List<string>
            {
                "재발 여부 확인 (고객 문의·로그)",
                "판정 지표 확인",
                "종료 또는 재오픈 판단"
            };
            return data;
        }

        public static IEnumerable<string> Names(IEnumerable<MasterEntry> entries)
        {
            return entries.Select(e => e.Name).Where(n => !string.IsNullOrWhiteSpace(n));
        }
    }
}
