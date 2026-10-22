using System;
using Newtonsoft.Json;

namespace TSWorkBench.Models
{
    /// <summary>
    /// 버전을 관리하는 프로그램 1개 (예: OCR). 코드는 프로그램마다 Git 저장소 하나에 있고,
    /// 사이트별 차이는 같은 코드의 버전 차이로만 관리한다. 데이터 폴더의 programs.json에 저장.
    /// </summary>
    public sealed class ProgramInfo
    {
        public string Name { get; set; } = "";

        /// <summary>코드 작업 폴더 (.sln이 있는 곳, VS2022로 여는 곳). 예: D:\박종부\00.Source\OCR</summary>
        public string CodeFolder { get; set; } = "";

        /// <summary>Release 빌드 결과 폴더 (bin\Release). 새 버전 배포 때 zip으로 보관.</summary>
        public string BuildFolder { get; set; } = "";

        /// <summary>매뉴얼 폴더 (docs). 비워도 된다.</summary>
        public string ManualFolder { get; set; } = "";

        /// <summary>NAS의 코드 백업 저장소. 예: \\NAS\TSWork\Git\OCR.git. 비우면 NAS 백업 안 함.</summary>
        public string GitRemote { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public bool HasRemote => !string.IsNullOrWhiteSpace(GitRemote);
    }
}
