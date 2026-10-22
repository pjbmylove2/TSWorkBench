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

        /// <summary>자동 백업 폴더. 비우면 데이터 폴더\Backups. 데이터와 다른 디스크(공유 폴더)를 권장.</summary>
        public string BackupFolder { get; set; } = "";

        /// <summary>남길 백업 zip 개수 (하루 1개). 0이면 지우지 않는다.</summary>
        public int BackupKeepCount { get; set; } = 30;

        /// <summary>배포본 보관소 (예: \\NAS\Releases). 프로그램\v버전\ 폴더가 여기에 만들어진다.</summary>
        public string ReleaseStore { get; set; } = "";

        /// <summary>프로그램 코드 작업 폴더들의 상위 폴더 (예: D:\박종부\00.Source). 프로그램 등록 때 기본값.</summary>
        public string SourceRoot { get; set; } = "";

        /// <summary>NAS 코드 백업 저장소 폴더. 비우면 배포본 보관소 옆의 Git 폴더 (…\TSWork\Git).</summary>
        public string GitStore { get; set; } = "";
    }
}
