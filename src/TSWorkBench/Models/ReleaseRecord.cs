using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TSWorkBench.Models
{
    /// <summary>
    /// 배포본 1개 (프로그램 + 버전). 보관소의 패키지 폴더와 설비별 설치 이력을 함께 기록한다.
    /// 데이터 폴더\Releases\{Program}\{Version}.json
    /// </summary>
    public sealed class ReleaseRecord
    {
        public string Program { get; set; } = "";
        public string Version { get; set; } = "";

        /// <summary>Git 태그 (예: v2.4.2)</summary>
        public string Tag { get; set; } = "";

        /// <summary>Git 커밋 해시 앞 7자리 등</summary>
        public string Commit { get; set; } = "";

        public DateTime ReleasedAt { get; set; }

        /// <summary>보관소의 배포본 폴더 (\\NAS\Releases\OmniSight\v2.4.2)</summary>
        public string PackagePath { get; set; } = "";

        /// <summary>변경 내역 (RELEASE_NOTES.md 내용)</summary>
        public string Notes { get; set; } = "";

        /// <summary>이 배포로 해결한 업무 ID</summary>
        public List<string> WorkItemIds { get; set; } = new List<string>();

        public List<Deployment> Deployments { get; set; } = new List<Deployment>();

        [JsonIgnore]
        public string Key => Program + " v" + Version;
    }

    /// <summary>배포본을 설비에 설치한 기록 1건.</summary>
    public sealed class Deployment
    {
        public string Customer { get; set; } = "";
        public string Site { get; set; } = "";
        public string Equipment { get; set; } = "";
        public DateTime DeployedAt { get; set; }
        public string WorkItemId { get; set; } = "";
        public string Note { get; set; } = "";

        /// <summary>설치 후 이전 버전으로 되돌렸으면 true. 설비별 현재 버전 계산에서 빠진다.</summary>
        public bool RolledBack { get; set; }

        [JsonIgnore]
        public string Location
        {
            get { return string.Join(" / ", new[] { Customer, Site, Equipment }); }
        }
    }

    /// <summary>설비별 현재 버전 표의 한 줄.</summary>
    public sealed class InstalledVersion
    {
        public string Customer { get; set; } = "";
        public string Site { get; set; } = "";
        public string Equipment { get; set; } = "";
        public string Program { get; set; } = "";
        public string Version { get; set; } = "";
        public DateTime DeployedAt { get; set; }
        public string WorkItemId { get; set; } = "";
    }
}
