using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TSWorkBench.Services
{
    public sealed class GitResult
    {
        public int ExitCode { get; set; }
        public string Output { get; set; } = "";
        public string Error { get; set; } = "";
        public bool Ok => ExitCode == 0;

        public string Message => (Error.Trim().Length > 0 ? Error : Output).Trim();
    }

    /// <summary>커밋 1개 요약.</summary>
    public sealed class GitCommit
    {
        public string Hash { get; set; } = "";
        public DateTime Date { get; set; }
        public string Subject { get; set; } = "";

        /// <summary>이 커밋을 가리키는 태그 (Tags()에서만 채움).</summary>
        public string Tag { get; set; } = "";
    }

    /// <summary>
    /// git.exe를 대신 실행한다. 사용자는 터미널을 쓰지 않고, 커밋은 VS2022에서 한다.
    /// git은 PATH → Git for Windows 기본 위치 → VS2022 내장 git 순서로 찾는다.
    /// </summary>
    public sealed class GitRunner
    {
        public const string DefaultGitIgnore = "bin/\nobj/\n.vs/\npackages/\n*.user\n*.suo\n";
        private const int TimeoutMs = 10 * 60 * 1000;
        private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);
        private static string gitPath;

        private readonly string workDir;
        private readonly string fallbackName;

        /// <param name="workDir">코드 작업 폴더</param>
        /// <param name="fallbackName">git에 사용자 이름이 설정되지 않았을 때 커밋에 쓸 이름</param>
        public GitRunner(string workDir, string fallbackName)
        {
            this.workDir = workDir;
            this.fallbackName = string.IsNullOrWhiteSpace(fallbackName) ? "TS WorkBench" : fallbackName;
        }

        public static bool IsAvailable => GitPath != null;

        public static string GitPath
        {
            get
            {
                if (gitPath == null)
                {
                    gitPath = Locate();
                }

                return gitPath;
            }
        }

        private static string Locate()
        {
            if (Works("git"))
            {
                return "git";
            }

            var programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            var candidates = new List<string> { Path.Combine(programFiles, "Git", "cmd", "git.exe") };
            var vsRoot = Path.Combine(programFiles, "Microsoft Visual Studio", "2022");
            if (Directory.Exists(vsRoot))
            {
                candidates.AddRange(Directory.GetDirectories(vsRoot).Select(edition => Path.Combine(edition,
                    @"Common7\IDE\CommonExtensions\Microsoft\TeamFoundation\Team Explorer\Git\cmd\git.exe")));
            }

            return candidates.FirstOrDefault(c => File.Exists(c) && Works(c));
        }

        private static bool Works(string exe)
        {
            try
            {
                using (var p = Process.Start(new ProcessStartInfo(exe, "--version") { UseShellExecute = false, CreateNoWindow = true, RedirectStandardOutput = true }))
                {
                    p.StandardOutput.ReadToEnd();
                    p.WaitForExit(10000);
                    return p.ExitCode == 0;
                }
            }
            catch (Win32Exception)
            {
                return false;
            }
        }

        // ── 실행 ─────────────────────────────────────────────

        public GitResult Run(params string[] args)
        {
            return Run(null, args);
        }

        public GitResult Run(DateTime? date, params string[] args)
        {
            if (!IsAvailable)
            {
                throw new InvalidOperationException("git을 찾을 수 없습니다. Git for Windows를 설치하거나 VS2022의 Git 구성 요소를 설치하세요.");
            }

            var all = new List<string> { "-c", "core.quotepath=false", "-c", "i18n.logOutputEncoding=UTF-8" };
            all.AddRange(args);
            var psi = new ProcessStartInfo(GitPath, string.Join(" ", all.Select(Quote)))
            {
                WorkingDirectory = workDir,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };
            psi.EnvironmentVariables["GIT_TERMINAL_PROMPT"] = "0";
            if (date.HasValue)
            {
                var stamp = date.Value.ToString("yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture);
                psi.EnvironmentVariables["GIT_AUTHOR_DATE"] = stamp;
                psi.EnvironmentVariables["GIT_COMMITTER_DATE"] = stamp;
            }

            using (var p = Process.Start(psi))
            {
                var output = p.StandardOutput.ReadToEndAsync();
                var error = p.StandardError.ReadToEndAsync();
                if (!p.WaitForExit(TimeoutMs))
                {
                    p.Kill();
                    throw new TimeoutException("git이 응답하지 않습니다: git " + string.Join(" ", args));
                }

                return new GitResult { ExitCode = p.ExitCode, Output = output.Result, Error = error.Result };
            }
        }

        /// <summary>실패하면 git의 메시지를 담아 예외를 던진다.</summary>
        public GitResult Must(DateTime? date, params string[] args)
        {
            var r = Run(date, args);
            if (!r.Ok)
            {
                throw new InvalidOperationException("git " + args.FirstOrDefault() + " 실패: " + r.Message);
            }

            return r;
        }

        /// <summary>Windows 명령줄 인수 규칙대로 감싼다 (공백·따옴표·역슬래시).</summary>
        public static string Quote(string arg)
        {
            if (arg.Length > 0 && arg.IndexOfAny(new[] { ' ', '\t', '"' }) < 0)
            {
                return arg;
            }

            var sb = new StringBuilder("\"");
            var backslashes = 0;
            foreach (var c in arg)
            {
                if (c == '\\')
                {
                    backslashes++;
                    continue;
                }

                sb.Append('\\', c == '"' ? backslashes * 2 + 1 : backslashes);
                backslashes = 0;
                sb.Append(c);
            }

            sb.Append('\\', backslashes * 2).Append('"');
            return sb.ToString();
        }

        // ── 상태 ─────────────────────────────────────────────

        /// <summary>이 폴더 자체가 Git 저장소인지 (상위 폴더의 저장소는 치지 않는다).</summary>
        public bool IsRepo => Directory.Exists(Path.Combine(workDir, ".git"));

        public bool HasCommits => IsRepo && Run("rev-parse", "--verify", "-q", "HEAD").Ok;

        /// <summary>커밋 안 한 변경 파일 목록 (git status). 깨끗하면 빈 목록.</summary>
        public List<string> PendingChanges()
        {
            return Lines(Must(null, "status", "--porcelain").Output);
        }

        public bool IsClean => PendingChanges().Count == 0;

        public GitCommit Head()
        {
            return ParseCommits(Must(null, "log", "-1", "--format=%h%x1f%cI%x1f%s").Output).FirstOrDefault();
        }

        public bool TagExists(string tag)
        {
            return Run("rev-parse", "-q", "--verify", "refs/tags/" + tag).Ok;
        }

        /// <summary>HEAD를 가리키는 태그들.</summary>
        public List<string> TagsAtHead()
        {
            return Lines(Must(null, "tag", "--points-at", "HEAD").Output);
        }

        /// <summary>모든 태그와 그 커밋 (오래된 순).</summary>
        public List<GitCommit> Tags()
        {
            var result = new List<GitCommit>();
            foreach (var tag in Lines(Must(null, "tag", "--list").Output))
            {
                var c = ParseCommits(Must(null, "log", "-1", "--format=%h%x1f%cI%x1f%s", tag).Output).FirstOrDefault();
                if (c != null)
                {
                    c.Tag = tag;
                    result.Add(c);
                }
            }

            return result.OrderBy(c => c.Date).ToList();
        }

        /// <summary>태그 이후의 커밋 (최신 순). 태그가 없으면 전체.</summary>
        public List<GitCommit> CommitsSince(string tag)
        {
            var range = string.IsNullOrEmpty(tag) ? "HEAD" : tag + "..HEAD";
            return ParseCommits(Must(null, "log", "--format=%h%x1f%cI%x1f%s", range).Output);
        }

        public string RemoteUrl()
        {
            var r = Run("remote", "get-url", "origin");
            return r.Ok ? r.Output.Trim() : "";
        }

        // ── 기록 ─────────────────────────────────────────────

        public void Init()
        {
            Directory.CreateDirectory(workDir);
            if (!Run("init", "-b", "main").Ok)
            {
                // 2.28보다 오래된 git은 -b가 없다.
                Must(null, "init");
                Must(null, "symbolic-ref", "HEAD", "refs/heads/main");
            }

            EnsureGitIgnore();
        }

        public void EnsureGitIgnore()
        {
            var path = Path.Combine(workDir, ".gitignore");
            if (!File.Exists(path))
            {
                File.WriteAllText(path, DefaultGitIgnore, Utf8NoBom);
            }
        }

        /// <summary>폴더의 모든 변경을 커밋한다. date를 주면 그 날짜로 기록. 바뀐 게 없어도 커밋을 남긴다.</summary>
        public GitCommit CommitAll(string message, DateTime? date)
        {
            Must(null, "add", "-A");
            WithMessageFile(message, file => Must(date, Identity(new[] { "commit", "--allow-empty", "-F", file }).ToArray()));
            return Head();
        }

        /// <summary>이름표(태그)를 붙인다. commit이 없으면 HEAD.</summary>
        public void Tag(string tag, string message, string commit, DateTime? date)
        {
            var args = new List<string> { "tag", "-a", tag };
            WithMessageFile(message, file =>
            {
                args.Add("-F");
                args.Add(file);
                if (!string.IsNullOrEmpty(commit))
                {
                    args.Add(commit);
                }

                return Must(date, Identity(args).ToArray());
            });
        }

        /// <summary>태그 시점의 소스를 zip으로 (bin·obj는 .gitignore로 이미 빠져 있다).</summary>
        public void Archive(string tag, string zipPath)
        {
            Must(null, "archive", "--format=zip", "-o", zipPath, tag);
        }

        /// <summary>NAS의 백업 저장소를 준비하고 origin으로 연결한다. 없으면 만든다(bare).</summary>
        public void EnsureRemote(string url)
        {
            if (!Directory.Exists(url))
            {
                Directory.CreateDirectory(url);
                new GitRunner(url, fallbackName).Must(null, "init", "--bare");
            }

            Trust(url);
            var current = RemoteUrl();
            if (current.Length == 0)
            {
                Must(null, "remote", "add", "origin", url);
            }
            else if (!string.Equals(current, url, StringComparison.OrdinalIgnoreCase))
            {
                Must(null, "remote", "set-url", "origin", url);
            }
        }

        /// <summary>커밋과 태그를 NAS로 보낸다.</summary>
        public void Push()
        {
            Trust(RemoteUrl());
            Must(null, "push", "-u", "origin", "HEAD", "--tags");
        }

        /// <summary>
        /// NAS 폴더는 소유자가 내 계정으로 보이지 않아 git이 "dubious ownership"으로 거부한다.
        /// 그 저장소 하나만 사용자 git 설정(safe.directory)에 믿을 곳으로 올린다. VS2022의 푸시·가져오기도 같이 된다.
        /// </summary>
        public void Trust(string url)
        {
            if (string.IsNullOrEmpty(url) || !(url.StartsWith(@"\\") || Path.IsPathRooted(url)))
            {
                return;
            }

            var entry = url.TrimEnd('\\', '/').Replace('\\', '/');
            var trusted = Lines(Run("config", "--global", "--get-all", "safe.directory").Output);
            if (!trusted.Any(t => t == "*" || string.Equals(t.TrimEnd('/'), entry, StringComparison.OrdinalIgnoreCase)))
            {
                Must(null, "config", "--global", "--add", "safe.directory", entry);
            }
        }

        private IEnumerable<string> Identity(IEnumerable<string> args)
        {
            var name = Run("config", "user.name").Output.Trim();
            var email = Run("config", "user.email").Output.Trim();
            var prefix = new List<string>();
            if (name.Length == 0)
            {
                prefix.AddRange(new[] { "-c", "user.name=" + fallbackName });
            }

            if (email.Length == 0)
            {
                prefix.AddRange(new[] { "-c", "user.email=tsworkbench@localhost" });
            }

            return prefix.Concat(args);
        }

        private static GitResult WithMessageFile(string message, Func<string, GitResult> action)
        {
            var file = Path.GetTempFileName();
            try
            {
                File.WriteAllText(file, message.Replace("\r\n", "\n"), Utf8NoBom);
                return action(file);
            }
            finally
            {
                File.Delete(file);
            }
        }

        private static List<string> Lines(string text)
        {
            return text.Split('\n').Select(l => l.TrimEnd('\r')).Where(l => l.Trim().Length > 0).ToList();
        }

        private static List<GitCommit> ParseCommits(string text)
        {
            var result = new List<GitCommit>();
            foreach (var line in Lines(text))
            {
                var parts = line.Split('\x1f');
                if (parts.Length < 3)
                {
                    continue;
                }

                DateTimeOffset date;
                DateTimeOffset.TryParse(parts[1], CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                result.Add(new GitCommit { Hash = parts[0], Date = date.LocalDateTime, Subject = parts[2] });
            }

            return result;
        }
    }
}
