namespace TSWorkBench.Models
{
    /// <summary>데이터 폴더의 settings.json. 회사를 옮기면 이 값만 바꾸면 된다.</summary>
    public sealed class AppSettings
    {
        public string UserName { get; set; } = "";
        public string Department { get; set; } = "TS팀";
        public string Company { get; set; } = "";

        /// <summary>업무 ID 앞머리. TS-2026-10-0001</summary>
        public string IdPrefix { get; set; } = "TS";

        /// <summary>현장·HW·프로그램 수정 업무를 완료하면 이 일수 뒤에 모니터링 후속 업무를 만든다. 0이면 만들지 않는다.</summary>
        public int FollowUpDays { get; set; } = 7;
    }
}
