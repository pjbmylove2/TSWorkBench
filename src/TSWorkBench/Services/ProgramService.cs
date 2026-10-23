using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using TSWorkBench.Models;
using TSWorkBench.Storage;

namespace TSWorkBench.Services
{
    /// <summary>새 버전 배포 화면에 보여 줄 "지금 상태".</summary>
    public sealed class PendingInfo
    {
        public bool IsRepo { get; set; }
        public string LatestVersion { get; set; }

        /// <summary>마지막 버전 이후에 VS2022에서 커밋한 것 (최신 순).</summary>
        public List<GitCommit> NewCommits { get; set; } = new List<GitCommit>();

        /// <summary>아직 커밋하지 않은 파일. 있으면 배포할 수 없다.</summary>
        public List<string> UncommittedFiles { get; set; } = new List<string>();

        public List<string> WorkItemIds { get; set; } = new List<string>();
        public string SuggestedNotes { get; set; } = "";
        public DateTime? BuildTime { get; set; }

        /// <summary>빌드가 마지막 커밋보다 오래됐으면 true (VS에서 Release 빌드를 다시 해야 함).</summary>
        public bool BuildIsOld { get; set; }
    }

    /// <summary>설치 현황 표 1줄: 어느 위치에 어느 프로그램 몇 버전이 깔려 있나.</summary>
    public sealed class InstallRow
    {
        public string Customer { get; set; } = "";
        public string Site { get; set; } = "";
        public string Equipment { get; set; } = "";
        public string Program { get; set; } = "";
        public string Version { get; set; } = "";
        public string LatestVersion { get; set; } = "";
        public DateTime DeployedAt { get; set; }
        public string WorkItemId { get; set; } = "";
        public ReleaseRecord Release { get; set; }
        public Deployment Deployment { get; set; }

        public bool IsLatest => VersionUtil.Compare(Version, LatestVersion) >= 0;

        public string Location => string.Join(" / ", new[] { Customer, Site, Equipment }.Where(s => !string.IsNullOrWhiteSpace(s)));
    }

    /// <summary>과거 버전 가져오기 1줄: zip 또는 폴더 하나 = 버전 하나.</summary>
    public sealed class ImportVersion
    {
        public string SourcePath { get; set; } = "";
        public DateTime Date { get; set; }
        public string Version { get; set; } = "";
        public string WorkItemId { get; set; } = "";
        public string Note { get; set; } = "";
    }

    public sealed class NewReleaseRequest
    {
        public string Program { get; set; } = "";
        public string Version { get; set; } = "";
        public string Notes { get; set; } = "";
        public List<string> WorkItemIds { get; set; } = new List<string>();

        /// <summary>이번에 설치한 곳 (고객사·사이트·설비만 채움).</summary>
        public List<Deployment> Targets { get; set; } = new List<Deployment>();

        public DateTime DeployedAt { get; set; }

        /// <summary>업무 카드 창에서 열었으면 그 카드 ID — 그 카드는 창이 직접 고친다.</summary>
        public string SkipCardId { get; set; } = "";
    }

    /// <summary>새 버전 배포의 지금 단계 (화면의 '현재 작업' 줄).</summary>
    public sealed class ReleaseProgress
    {
        public const int StepCount = 5;

        public int Step { get; set; }
        public string Title { get; set; } = "";
        public string Detail { get; set; } = "";
        public int Done { get; set; }

        /// <summary>0이면 개수를 모르는 작업 (막대가 흐르기만 한다).</summary>
        public int Total { get; set; }
    }

    /// <summary>
    /// 프로그램 버전 관리의 모든 Git 작업을 버튼 하나로 대신한다.
    /// ① 등록(기준본) ② 새 버전 배포 ③ 과거 버전 가져오기 + 설치 현황, NAS 백업.
    /// 화면과 분리되어 있어 검증 프로그램에서 그대로 시험한다.
    /// </summary>
    public sealed class ProgramService
    {
        private readonly Workspace ws;

        public ProgramService(Workspace ws)
        {
            this.ws = ws;
        }

        public GitRunner Git(ProgramInfo p)
        {
            return new GitRunner(p.CodeFolder, ws.Settings.UserName);
        }

        /// <summary>프로그램의 가장 높은 버전 (배포 기록 기준). 없으면 null.</summary>
        public string LatestVersion(string program)
        {
            return VersionUtil.Latest(ws.Releases.All.Where(r => Same(r.Program, program)).Select(r => r.Version));
        }

        public Regex WorkItemPattern => new Regex(@"\b" + Regex.Escape(ws.Settings.IdPrefix) + @"-\d{4}-(?:\d{2}-)?\d{4}\b", RegexOptions.IgnoreCase);

        public List<string> ParseIds(IEnumerable<string> texts)
        {
            var pattern = WorkItemPattern;
            return texts.SelectMany(t => pattern.Matches(t ?? "").Cast<Match>().Select(m => m.Value.ToUpperInvariant()))
                .Distinct().ToList();
        }

        // ── ① 프로그램 등록 ──────────────────────────────────

        /// <summary>
        /// 코드 폴더를 프로그램으로 등록한다.
        /// · Git이 아니면: 저장소를 만들고 지금 코드를 기준본(baseVersion)으로 커밋·태그, 배포본(소스 zip·빌드 zip) 보관.
        /// · 이미 Git이면: 있는 태그(v1.0.0 …)를 배포 기록으로 불러오고, 태그 없는 마지막 커밋도 다음 버전으로 붙인다.
        /// · sites는 지금 이 프로그램의 최신 버전을 쓰는 곳으로 설치 기록. NAS 백업 위치가 있으면 연결·업로드.
        /// </summary>
        public string Register(ProgramInfo p, string baseVersion, DateTime baseDate, List<Deployment> sites, IProgress<string> log)
        {
            p.Name = (p.Name ?? "").Trim();
            if (p.Name.Length == 0)
            {
                throw new InvalidOperationException("프로그램 이름을 입력하세요.");
            }

            var existing = ws.FindProgram(p.Name);
            if (existing != null && !string.IsNullOrWhiteSpace(existing.CodeFolder))
            {
                throw new InvalidOperationException("이미 등록된 프로그램입니다: " + p.Name);
            }

            // 예전 기준 정보에서 이름만 옮겨 온 프로그램(코드 폴더 없음)은 이번 등록으로 채운다.
            if (existing != null)
            {
                ws.Programs.Remove(existing);
            }

            if (string.IsNullOrWhiteSpace(p.CodeFolder))
            {
                throw new InvalidOperationException("코드 폴더를 지정하세요.");
            }

            // 날짜별 zip만 있는 프로그램: 빈 폴더로 등록하고 '과거 버전 가져오기'로 전부 넣는다.
            Directory.CreateDirectory(p.CodeFolder);
            if (!Directory.EnumerateFileSystemEntries(p.CodeFolder).Any())
            {
                p.CreatedAt = DateTime.Now;
                ws.Programs.Add(p);
                ws.SavePrograms();
                Report(log, "코드 폴더가 비어 있어 프로그램만 등록했습니다.");
                Report(log, "→ '과거 버전 가져오기'에서 버전별 zip·폴더를 모두 넣으세요 (가장 오래된 것이 기준본).");
                return null;
            }

            if (!VersionUtil.IsValid(baseVersion))
            {
                throw new InvalidOperationException("기준 버전은 1.0.0 같은 형식으로 입력하세요.");
            }

            baseVersion = VersionUtil.Normalize(baseVersion);
            var git = Git(p);
            string current;
            if (!git.HasCommits)
            {
                if (!git.IsRepo)
                {
                    Report(log, "Git 저장소 만들기 (.gitignore 포함)");
                    git.Init();
                }

                git.EnsureGitIgnore();
                Report(log, "기준본 커밋: v" + baseVersion + " (" + baseDate.ToString("yyyy-MM-dd") + ")");
                var commit = git.CommitAll("기준본 v" + baseVersion, baseDate);
                git.Tag("v" + baseVersion, p.Name + " " + baseVersion + " 기준본", null, baseDate);
                var record = new ReleaseRecord
                {
                    Program = p.Name,
                    Version = baseVersion,
                    Tag = "v" + baseVersion,
                    Commit = commit.Hash,
                    ReleasedAt = baseDate,
                    Notes = "기준본"
                };
                record.PackagePath = TryPackage(p, git, record, log);
                ws.Releases.Save(record);
                current = baseVersion;
            }
            else
            {
                Report(log, "이미 Git 저장소입니다. 태그를 배포 기록으로 불러옵니다.");
                current = ImportTags(p, git, log, baseVersion);
            }

            if (sites.Count > 0)
            {
                var release = ws.Releases.Find(p.Name, current);
                foreach (var site in sites)
                {
                    site.DeployedAt = baseDate;
                    release.Deployments.Add(site);
                }

                ws.Releases.Save(release);
                Report(log, "설치 위치 " + sites.Count + "곳 기록 → v" + current);
            }

            p.CreatedAt = DateTime.Now;
            ws.Programs.Add(p);
            ws.SavePrograms();
            Backup(p, git, log);
            Report(log, "완료: " + p.Name + " v" + current);
            return current;
        }

        /// <summary>기존 저장소의 태그를 배포 기록으로. 태그가 없거나 마지막 태그 뒤 커밋이 있으면 HEAD에 다음 버전 태그.</summary>
        private string ImportTags(ProgramInfo p, GitRunner git, IProgress<string> log, string baseVersion)
        {
            var tags = git.Tags().Where(t => VersionUtil.IsValid(t.Tag)).ToList();
            var latest = VersionUtil.Latest(tags.Select(t => t.Tag));
            if (latest == null || git.CommitsSince("v" + latest).Count > 0)
            {
                var head = git.Head();
                var version = latest == null ? baseVersion : VersionUtil.Next(latest, VersionStep.Minor);
                Report(log, "태그 없는 마지막 커밋 " + head.Hash + "에 v" + version + " 이름표 붙이기");
                git.Tag("v" + version, p.Name + " " + version, head.Hash, head.Date);
                tags = git.Tags().Where(t => VersionUtil.IsValid(t.Tag)).ToList();
                latest = version;
            }

            foreach (var t in tags)
            {
                var version = VersionUtil.Normalize(t.Tag);
                if (ws.Releases.Find(p.Name, version) != null)
                {
                    continue;
                }

                ws.Releases.Save(new ReleaseRecord
                {
                    Program = p.Name,
                    Version = version,
                    Tag = t.Tag,
                    Commit = t.Hash,
                    ReleasedAt = t.Date,
                    Notes = t.Subject,
                    WorkItemIds = ParseIds(new[] { t.Subject })
                });
                Report(log, "  v" + version + "  " + t.Date.ToString("yyyy-MM-dd") + "  " + t.Subject);
            }

            return latest;
        }

        // ── ② 새 버전 배포 ───────────────────────────────────

        private static readonly string[] SkipBuildDirs = { "obj", ".git", ".vs", "packages", "node_modules", "Debug" };

        /// <summary>
        /// 코드 폴더 안에서 Release 빌드 결과 폴더를 찾는다: exe가 있는 폴더 중 exe가 가장 최근인 곳.
        /// obj·Debug 등은 뺀다. 프로젝트마다 bin\Release, bin\x64\Release, 솔루션의 bin\ 등 위치가 달라서 이름으로 정하지 않는다.
        /// </summary>
        public static string FindBuildFolder(string code)
        {
            if (string.IsNullOrWhiteSpace(code) || !Directory.Exists(code))
            {
                return null;
            }

            string best = null;
            var bestTime = DateTime.MinValue;
            var pending = new Stack<string>();
            pending.Push(code);
            while (pending.Count > 0)
            {
                var dir = pending.Pop();
                try
                {
                    var exes = Directory.GetFiles(dir, "*.exe").Where(f => !f.EndsWith(".vshost.exe", StringComparison.OrdinalIgnoreCase)).ToList();
                    if (exes.Count > 0)
                    {
                        var newest = exes.Max(File.GetLastWriteTime);
                        if (newest > bestTime)
                        {
                            best = dir;
                            bestTime = newest;
                        }
                    }

                    foreach (var sub in Directory.GetDirectories(dir))
                    {
                        if (!SkipBuildDirs.Contains(Path.GetFileName(sub), StringComparer.OrdinalIgnoreCase))
                        {
                            pending.Push(sub);
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (IOException)
                {
                }
            }

            return best;
        }

        /// <summary>빌드 폴더가 비었거나 없어졌으면 다시 찾아 저장한다. 찾으면(또는 이미 있으면) true.</summary>
        public bool EnsureBuildFolder(ProgramInfo p)
        {
            if (!string.IsNullOrWhiteSpace(p.BuildFolder) && Directory.Exists(p.BuildFolder))
            {
                return true;
            }

            var found = FindBuildFolder(p.CodeFolder);
            if (found == null)
            {
                return false;
            }

            p.BuildFolder = found;
            ws.SavePrograms();
            return true;
        }

        public PendingInfo GetPending(ProgramInfo p)
        {
            EnsureBuildFolder(p);
            var info = new PendingInfo { LatestVersion = LatestVersion(p.Name) };
            var git = Git(p);
            info.IsRepo = Directory.Exists(p.CodeFolder) && git.HasCommits;
            if (!info.IsRepo)
            {
                return info;
            }

            info.UncommittedFiles = git.PendingChanges();
            var tag = info.LatestVersion != null && git.TagExists("v" + info.LatestVersion) ? "v" + info.LatestVersion : null;
            info.NewCommits = git.CommitsSince(tag);
            info.WorkItemIds = ParseIds(info.NewCommits.Select(c => c.Subject));
            info.SuggestedNotes = string.Join("\r\n", info.NewCommits.AsEnumerable().Reverse().Select(c => "- " + c.Subject));

            if (Directory.Exists(p.BuildFolder))
            {
                var files = Directory.GetFiles(p.BuildFolder, "*", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    info.BuildTime = files.Max(f => File.GetLastWriteTime(f));
                }
            }

            var lastCommit = info.NewCommits.Count > 0 ? info.NewCommits[0].Date : (DateTime?)null;
            info.BuildIsOld = lastCommit.HasValue && info.BuildTime.HasValue && info.BuildTime.Value < lastCommit.Value;
            return info;
        }

        /// <summary>
        /// 새 버전 배포: HEAD에 태그 → 보관소에 배포본(빌드 zip + 소스 zip + 매뉴얼 + 변경 내역) → 배포 기록·설치 기록
        /// → 관련 업무 카드 '변경 내역'에 자동 기입 → NAS 백업. 업무 카드에 적을 한 줄을 돌려준다.
        /// </summary>
        public string NewRelease(NewReleaseRequest r, IProgress<string> log, out ReleaseRecord record, IProgress<ReleaseProgress> status = null)
        {
            void Step(int step, string title, string detail = "", int done = 0, int total = 0)
            {
                status?.Report(new ReleaseProgress { Step = step, Title = title, Detail = detail, Done = done, Total = total });
            }

            var p = ws.FindProgram(r.Program) ?? throw new InvalidOperationException("등록되지 않은 프로그램입니다: " + r.Program);
            var git = Git(p);
            if (!git.HasCommits)
            {
                throw new InvalidOperationException("코드 폴더가 Git 저장소가 아닙니다. 먼저 '프로그램 등록'을 하세요.");
            }

            var pending = git.PendingChanges();
            if (pending.Count > 0)
            {
                throw new InvalidOperationException("아직 커밋하지 않은 변경이 " + pending.Count + "개 있습니다.\nVS2022의 Git 변경 내용 창에서 먼저 커밋하세요.\n\n" + string.Join("\n", pending.Take(8)));
            }

            if (!VersionUtil.IsValid(r.Version))
            {
                throw new InvalidOperationException("버전은 1.1.0 같은 형식으로 입력하세요.");
            }

            var version = VersionUtil.Normalize(r.Version);
            var latest = LatestVersion(p.Name);
            if (latest != null && VersionUtil.Compare(version, latest) <= 0)
            {
                throw new InvalidOperationException("새 버전(" + version + ")은 지금 최신 버전(" + latest + ")보다 높아야 합니다.");
            }

            var tag = "v" + version;
            if (git.TagExists(tag))
            {
                throw new InvalidOperationException("이미 있는 버전 이름표입니다: " + tag);
            }

            if (string.IsNullOrWhiteSpace(ws.Settings.ReleaseStore))
            {
                throw new InvalidOperationException("설정 › 배포본 보관소를 먼저 지정하세요.");
            }

            if (!EnsureBuildFolder(p))
            {
                Report(log, "⚠ 빌드 결과 폴더를 찾지 못해 소스·매뉴얼만 담습니다. (프로그램 보기 › 설정 고치기에서 지정)");
            }

            var head = git.Head();
            Step(1, "이름표 붙이기", tag);
            Report(log, "이름표 " + tag + " → 커밋 " + head.Hash + " (" + head.Subject + ")");
            git.Tag(tag, p.Name + " " + version + "\n\n" + r.Notes, null, null);

            string package;
            try
            {
                Step(2, "배포본 만들기");
                Report(log, "배포본 만들기 (빌드 zip + 소스 zip + 매뉴얼)…");
                package = ReleasePackager.Create(ws.Settings.ReleaseStore, new PackageRequest
                {
                    Program = p.Name,
                    Version = version,
                    BuildFolder = Directory.Exists(p.BuildFolder) ? p.BuildFolder : "",
                    ManualFolder = p.ManualFolder,
                    Notes = r.Notes,
                    WriteSourceZip = zip => git.Archive(tag, zip),
                    Progress = (what, done, total) => Step(2, "배포본 만들기", what, done, total)
                }, DateTime.Now).PackagePath;
            }
            catch
            {
                git.Run("tag", "-d", tag);
                throw;
            }

            Report(log, "  " + package);
            var firstId = r.WorkItemIds.FirstOrDefault() ?? "";
            record = new ReleaseRecord
            {
                Program = p.Name,
                Version = version,
                Tag = tag,
                Commit = head.Hash,
                ReleasedAt = DateTime.Now,
                PackagePath = package,
                Notes = r.Notes,
                WorkItemIds = r.WorkItemIds.ToList()
            };
            foreach (var t in r.Targets)
            {
                t.DeployedAt = r.DeployedAt;
                t.WorkItemId = firstId;
                record.Deployments.Add(t);
            }

            Step(3, "배포 기록 저장");
            ws.Releases.Save(record);
            Report(log, "배포 기록 저장, 설치 위치 " + r.Targets.Count + "곳");

            Step(4, "업무 카드 기록");

            var line = "배포: " + p.Name + " v" + version + " (커밋 " + head.Hash + ")"
                       + (r.Targets.Count > 0 ? " → " + string.Join(", ", r.Targets.Select(t => t.Equipment.Length > 0 ? t.Equipment : t.Site)) : "")
                       + "  배포본 " + package;
            foreach (var id in r.WorkItemIds.Where(id => !Same(id, r.SkipCardId)))
            {
                var item = ws.Items.Find(id);
                if (item == null)
                {
                    continue;
                }

                AppendLine(item, line, r.DeployedAt, p.Name + " v" + version + " 배포");
                ws.Save(item);
                Report(log, "업무 카드 " + id + " 변경 내역에 기록");
            }

            Step(5, "NAS로 코드 백업", p.HasRemote ? p.GitRemote : "백업 위치 없음 — 건너뜀");
            Backup(p, git, log);
            return line;
        }

        // ── ③ 과거 버전 가져오기 ─────────────────────────────

        /// <summary>
        /// 버전별로 따로 보관해 온 zip·폴더를 날짜 순서대로 코드 폴더에 덮어쓰며 커밋·태그한다.
        /// 덮어쓰기 전에 폴더를 비우므로(.git·.gitignore·.vs 제외) 지워진 파일도 정확히 기록된다.
        /// 커밋 안 한 변경이 있으면 시작하지 않는다 (지워질 수 있으므로).
        /// </summary>
        public void ImportVersions(ProgramInfo p, List<ImportVersion> versions, IProgress<string> log)
        {
            var git = Git(p);
            Directory.CreateDirectory(p.CodeFolder);
            if (git.HasCommits && git.PendingChanges().Count > 0)
            {
                throw new InvalidOperationException("코드 폴더에 아직 커밋하지 않은 변경이 있습니다. VS2022에서 먼저 커밋하세요.");
            }

            if (!git.IsRepo)
            {
                if (Directory.EnumerateFileSystemEntries(p.CodeFolder).Any())
                {
                    throw new InvalidOperationException("코드 폴더가 비어 있지 않은데 Git 저장소가 아닙니다. 빈 폴더를 고르거나 먼저 '프로그램 등록'을 하세요.");
                }

                git.Init();
            }

            foreach (var v in versions.OrderBy(v => v.Date))
            {
                var version = VersionUtil.Normalize(v.Version);
                if (!VersionUtil.IsValid(version) || git.TagExists("v" + version))
                {
                    throw new InvalidOperationException("버전이 잘못됐거나 이미 있습니다: " + v.Version);
                }

                if (!File.Exists(v.SourcePath) && !Directory.Exists(v.SourcePath))
                {
                    throw new FileNotFoundException("원본이 없습니다: " + v.SourcePath);
                }

                Report(log, "v" + version + " ← " + Path.GetFileName(v.SourcePath));
                ClearWorkingTree(p.CodeFolder);
                CopySnapshot(v.SourcePath, p.CodeFolder);
                git.EnsureGitIgnore();

                var note = string.IsNullOrWhiteSpace(v.Note) ? v.Date.ToString("yyyyMMdd") + " 현장적용본" : v.Note.Trim();
                var subject = (string.IsNullOrWhiteSpace(v.WorkItemId) ? "" : v.WorkItemId.Trim() + " ") + note;
                var commit = git.CommitAll(subject + "\n\n원본: " + v.SourcePath, v.Date);
                git.Tag("v" + version, p.Name + " " + version + " (" + note + ")", null, v.Date);

                var ids = ParseIds(new[] { v.WorkItemId });
                var existing = ws.Releases.Find(p.Name, version);
                var record = existing ?? new ReleaseRecord { Program = p.Name, Version = version };
                record.Tag = "v" + version;
                record.Commit = commit.Hash;
                record.ReleasedAt = v.Date;
                record.PackagePath = v.SourcePath;
                record.Notes = note;
                record.WorkItemIds = ids;
                ws.Releases.Save(record);

                foreach (var id in ids)
                {
                    var item = ws.Items.Find(id);
                    if (item != null)
                    {
                        AppendLine(item, "Git: " + p.Name + " v" + version + " (커밋 " + commit.Hash + ")  원본 " + v.SourcePath, v.Date, null);
                        ws.Save(item);
                    }
                }

                Report(log, "  커밋 " + commit.Hash + " · 이름표 v" + version);
            }

            Backup(p, git, log);
        }

        /// <summary>코드 폴더를 비운다. .git(기록)·.gitignore·.vs(VS가 잡고 있을 수 있음)는 남긴다.</summary>
        public static void ClearWorkingTree(string folder)
        {
            foreach (var entry in Directory.GetFileSystemEntries(folder))
            {
                var name = Path.GetFileName(entry);
                if (name == ".git" || name == ".gitignore" || name == ".vs")
                {
                    continue;
                }

                if (Directory.Exists(entry))
                {
                    foreach (var f in Directory.GetFiles(entry, "*", SearchOption.AllDirectories))
                    {
                        File.SetAttributes(f, FileAttributes.Normal);
                    }

                    Directory.Delete(entry, true);
                }
                else
                {
                    File.SetAttributes(entry, FileAttributes.Normal);
                    File.Delete(entry);
                }
            }
        }

        /// <summary>zip이면 풀어서, 폴더면 그대로 복사한다. 겉에 폴더가 한 겹만 있으면 그 안쪽을 쓴다.</summary>
        public static void CopySnapshot(string source, string target)
        {
            if (Directory.Exists(source))
            {
                CopyTree(Unwrap(source), target);
                return;
            }

            var temp = Path.Combine(Path.GetTempPath(), "TSWorkBench_" + Guid.NewGuid().ToString("N"));
            try
            {
                ZipFile.ExtractToDirectory(source, temp);
                CopyTree(Unwrap(temp), target);
            }
            finally
            {
                if (Directory.Exists(temp))
                {
                    Directory.Delete(temp, true);
                }
            }
        }

        private static string Unwrap(string folder)
        {
            while (true)
            {
                var dirs = Directory.GetDirectories(folder).Where(d => Path.GetFileName(d) != ".git").ToArray();
                if (dirs.Length != 1 || Directory.GetFiles(folder).Length > 0)
                {
                    return folder;
                }

                folder = dirs[0];
            }
        }

        private static void CopyTree(string source, string target)
        {
            foreach (var dir in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            {
                var relative = dir.Substring(source.Length).TrimStart('\\', '/');
                if (!IsGitPath(relative))
                {
                    Directory.CreateDirectory(Path.Combine(target, relative));
                }
            }

            foreach (var file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
            {
                var relative = file.Substring(source.Length).TrimStart('\\', '/');
                if (!IsGitPath(relative))
                {
                    var dest = Path.Combine(target, relative);
                    Directory.CreateDirectory(Path.GetDirectoryName(dest));
                    File.Copy(file, dest, true);
                }
            }
        }

        private static bool IsGitPath(string relative)
        {
            return relative == ".git" || relative.StartsWith(".git\\", StringComparison.Ordinal) || relative.StartsWith(".git/", StringComparison.Ordinal);
        }

        /// <summary>가져오기 표에 넣을 다음 버전 제안: 지금 최신 버전에서 부 번호를 하나씩 올린다.</summary>
        public string SuggestImportVersion(ProgramInfo p, IEnumerable<string> alreadyPlanned)
        {
            var git = Git(p);
            var tags = git.IsRepo && git.HasCommits ? git.Tags().Select(t => t.Tag) : Enumerable.Empty<string>();
            var latest = VersionUtil.Latest(tags.Concat(alreadyPlanned).Concat(ws.Releases.All.Where(r => Same(r.Program, p.Name)).Select(r => r.Version)));
            return latest == null ? VersionUtil.BaseVersion : VersionUtil.Next(latest, VersionStep.Minor);
        }

        // ── 설치 현황 · 백업 ─────────────────────────────────

        public List<InstallRow> InstallStatus()
        {
            return ReleaseRepository.CurrentVersions(ws.Releases.All).Select(v => new InstallRow
            {
                Customer = v.Customer,
                Site = v.Site,
                Equipment = v.Equipment,
                Program = v.Program,
                Version = v.Version,
                LatestVersion = LatestVersion(v.Program) ?? v.Version,
                DeployedAt = v.DeployedAt,
                WorkItemId = v.WorkItemId,
                Release = v.Release,
                Deployment = v.Deployment
            }).ToList();
        }

        /// <summary>등록된 프로그램을 전부 NAS로 백업(push). 실패한 프로그램과 이유를 돌려준다.</summary>
        public List<string> PushAll()
        {
            var failures = new List<string>();

            // 새 PC에서 코드 폴더가 아직 없으면 NAS 저장소를 믿을 곳으로만 올려 둔다 → VS2022 '리포지토리 복제'가 된다.
            foreach (var p in ws.Programs.Where(p => p.HasRemote && !Directory.Exists(Path.Combine(p.CodeFolder, ".git")) && Directory.Exists(p.GitRemote)))
            {
                try
                {
                    new GitRunner(ws.Root, ws.Settings.UserName).Trust(p.GitRemote);
                }
                catch (Exception ex)
                {
                    failures.Add(p.Name + ": " + ex.Message);
                }
            }

            foreach (var p in ws.Programs.Where(p => p.HasRemote && Directory.Exists(Path.Combine(p.CodeFolder, ".git"))))
            {
                try
                {
                    var git = Git(p);
                    git.EnsureRemote(p.GitRemote);
                    git.Push();
                }
                catch (Exception ex)
                {
                    failures.Add(p.Name + ": " + ex.Message);
                }
            }

            return failures;
        }

        private void Backup(ProgramInfo p, GitRunner git, IProgress<string> log)
        {
            if (!p.HasRemote)
            {
                Report(log, "NAS 코드 백업 위치가 없어 업로드는 건너뜀");
                return;
            }

            try
            {
                Report(log, "NAS로 코드 백업 → " + p.GitRemote);
                git.EnsureRemote(p.GitRemote);
                git.Push();
                Report(log, "  백업 완료");
            }
            catch (Exception ex)
            {
                // 배포 자체는 끝났으므로 실패로 돌리지 않는다. 다음 실행 때 자동 백업이 다시 시도한다.
                Report(log, "  ⚠ NAS 백업 실패 (다음 실행 때 다시 시도): " + ex.Message);
                ErrorLog.Write("NAS 코드 백업 실패: " + p.Name, ex);
            }
        }

        private string TryPackage(ProgramInfo p, GitRunner git, ReleaseRecord record, IProgress<string> log)
        {
            if (string.IsNullOrWhiteSpace(ws.Settings.ReleaseStore))
            {
                Report(log, "배포본 보관소가 없어 기준본 배포본은 건너뜀");
                return "";
            }

            try
            {
                var path = ReleasePackager.Create(ws.Settings.ReleaseStore, new PackageRequest
                {
                    Program = p.Name,
                    Version = record.Version,
                    BuildFolder = Directory.Exists(p.BuildFolder) ? p.BuildFolder : "",
                    ManualFolder = p.ManualFolder,
                    Notes = record.Notes,
                    WriteSourceZip = zip => git.Archive(record.Tag, zip)
                }, record.ReleasedAt).PackagePath;
                Report(log, "기준본 배포본 보관 → " + path);
                return path;
            }
            catch (Exception ex)
            {
                Report(log, "  ⚠ 배포본을 만들지 못함: " + ex.Message);
                return "";
            }
        }

        private static void AppendLine(WorkItem item, string line, DateTime when, string timelineText)
        {
            item.ChangedFiles = string.IsNullOrWhiteSpace(item.ChangedFiles) ? line : item.ChangedFiles.TrimEnd() + "\r\n" + line;
            if (timelineText != null)
            {
                item.Timeline.Add(new TimelineEntry { Start = when, Kind = TimelineKind.Note, Text = timelineText });
            }
        }

        private static void Report(IProgress<string> log, string text)
        {
            log?.Report(text);
        }

        private static bool Same(string a, string b)
        {
            return string.Equals(a?.Trim(), b?.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
