using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TSWorkBench.Models;

namespace TSWorkBench.Storage
{
    /// <summary>배포 기록 저장소. 배포본 1개 = Releases\{Program}\{Version}.json</summary>
    public sealed class ReleaseRepository
    {
        private readonly string dir;
        private readonly List<ReleaseRecord> releases = new List<ReleaseRecord>();

        public ReleaseRepository(string dir)
        {
            this.dir = dir;
        }

        public IReadOnlyList<ReleaseRecord> All => releases;

        public List<string> LoadErrors { get; } = new List<string>();

        public void LoadAll()
        {
            releases.Clear();
            LoadErrors.Clear();
            if (!Directory.Exists(dir))
            {
                return;
            }

            foreach (var file in Directory.EnumerateFiles(dir, "*.json", SearchOption.AllDirectories))
            {
                try
                {
                    var r = JsonFile.Read<ReleaseRecord>(file);
                    if (r != null && r.Program.Length > 0 && r.Version.Length > 0)
                    {
                        releases.Add(r);
                    }
                }
                catch (Exception ex)
                {
                    LoadErrors.Add(file + " : " + ex.Message);
                }
            }
        }

        public ReleaseRecord Find(string program, string version)
        {
            return releases.FirstOrDefault(r => Same(r.Program, program) && Same(r.Version, version));
        }

        public void Save(ReleaseRecord release)
        {
            if (string.IsNullOrWhiteSpace(release.Program) || string.IsNullOrWhiteSpace(release.Version))
            {
                throw new ArgumentException("프로그램과 버전을 입력하세요.");
            }

            JsonFile.WriteAtomic(PathOf(release), release);
            var index = releases.FindIndex(r => Same(r.Program, release.Program) && Same(r.Version, release.Version));
            if (index >= 0)
            {
                releases[index] = release;
            }
            else
            {
                releases.Add(release);
            }
        }

        /// <summary>
        /// 설비별로 프로그램마다 마지막으로 설치한(되돌리지 않은) 버전.
        /// "지금 그 설비에 무슨 버전이 깔려 있나"에 답한다.
        /// </summary>
        public static List<InstalledVersion> CurrentVersions(IEnumerable<ReleaseRecord> releases)
        {
            return releases
                .SelectMany(r => r.Deployments.Where(d => !d.RolledBack).Select(d => new InstalledVersion
                {
                    Customer = d.Customer,
                    Site = d.Site,
                    Equipment = d.Equipment,
                    Program = r.Program,
                    Version = r.Version,
                    DeployedAt = d.DeployedAt,
                    WorkItemId = d.WorkItemId
                }))
                .GroupBy(v => (v.Customer + "|" + v.Site + "|" + v.Equipment + "|" + v.Program).ToUpperInvariant())
                .Select(g => g.OrderByDescending(v => v.DeployedAt).First())
                .OrderBy(v => v.Customer).ThenBy(v => v.Site).ThenBy(v => v.Equipment).ThenBy(v => v.Program)
                .ToList();
        }

        private string PathOf(ReleaseRecord r)
        {
            return Path.Combine(dir, SafeName(r.Program), SafeName(r.Version) + ".json");
        }

        public static string SafeName(string name)
        {
            var invalid = Path.GetInvalidFileNameChars();
            return new string(name.Trim().Select(c => invalid.Contains(c) ? '_' : c).ToArray());
        }

        private static bool Same(string a, string b)
        {
            return string.Equals(a?.Trim(), b?.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
