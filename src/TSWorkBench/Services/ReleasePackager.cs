using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TSWorkBench.Models;
using TSWorkBench.Storage;

namespace TSWorkBench.Services
{
    /// <summary>배포 패키지 만들기 입력.</summary>
    public sealed class PackageRequest
    {
        public string Program { get; set; } = "";
        public string Version { get; set; } = "";

        /// <summary>빌드 결과 폴더 (bin\Release). 통째로 zip이 된다.</summary>
        public string BuildFolder { get; set; } = "";

        /// <summary>매뉴얼 폴더 (docs). 비워도 된다. manual\로 그대로 복사.</summary>
        public string ManualFolder { get; set; } = "";

        public string Notes { get; set; } = "";
    }

    /// <summary>
    /// 배포본 보관소에 변경 불가 폴더를 만든다.
    /// <code>
    /// 보관소\{Program}\v{Version}\
    ///   {Program}_v{Version}.zip   빌드 결과 (pdb·vshost 제외)
    ///   manual\                    매뉴얼·이미지
    ///   RELEASE_NOTES.md           변경 내역
    ///   SHA256SUMS.txt             파일 무결성 확인용
    /// </code>
    /// 같은 버전 폴더가 이미 있으면 덮어쓰지 않고 거부한다 — 버전을 올려서 다시 만든다.
    /// </summary>
    public static class ReleasePackager
    {
        private static readonly string[] ExcludedExtensions = { ".pdb", ".vshost.exe", ".vshost.exe.config", ".vshost.exe.manifest" };

        public static string PackageFolder(string store, string program, string version)
        {
            return Path.Combine(store, ReleaseRepository.SafeName(program), "v" + ReleaseRepository.SafeName(version));
        }

        public static ReleaseRecord Create(string store, PackageRequest request, DateTime now)
        {
            if (string.IsNullOrWhiteSpace(store))
            {
                throw new InvalidOperationException("설정에서 배포본 보관소 경로를 먼저 지정하세요.");
            }

            if (string.IsNullOrWhiteSpace(request.Program) || string.IsNullOrWhiteSpace(request.Version))
            {
                throw new InvalidOperationException("프로그램 이름과 버전을 입력하세요.");
            }

            if (!Directory.Exists(request.BuildFolder))
            {
                throw new DirectoryNotFoundException("빌드 폴더가 없습니다: " + request.BuildFolder);
            }

            var target = PackageFolder(store, request.Program, request.Version);
            if (Directory.Exists(target))
            {
                throw new InvalidOperationException("이미 있는 버전입니다 (배포본은 덮어쓰지 않습니다). 버전을 올려 주세요.\n" + target);
            }

            // 중간에 실패하면 만들던 폴더를 지워서 반쯤 만든 버전 폴더가 남지 않게 한다.
            // (다 만든 뒤 이름을 바꾸는 방식은 백신·인덱서가 새 파일을 잡고 있으면 거부되어 쓰지 않는다.)
            var work = target;
            Directory.CreateDirectory(work);
            try
            {
                var zipName = ReleaseRepository.SafeName(request.Program) + "_v" + ReleaseRepository.SafeName(request.Version) + ".zip";
                ZipFolder(request.BuildFolder, Path.Combine(work, zipName));

                if (!string.IsNullOrWhiteSpace(request.ManualFolder) && Directory.Exists(request.ManualFolder))
                {
                    CopyFolder(request.ManualFolder, Path.Combine(work, "manual"));
                }

                File.WriteAllText(Path.Combine(work, "RELEASE_NOTES.md"), ReleaseNotes(request, now), new UTF8Encoding(false));
                File.WriteAllText(Path.Combine(work, "SHA256SUMS.txt"), Checksums(work), new UTF8Encoding(false));
            }
            catch
            {
                if (Directory.Exists(work))
                {
                    Directory.Delete(work, true);
                }

                throw;
            }

            return new ReleaseRecord
            {
                Program = request.Program.Trim(),
                Version = request.Version.Trim(),
                Tag = "v" + request.Version.Trim(),
                ReleasedAt = now,
                PackagePath = target,
                Notes = request.Notes
            };
        }

        /// <summary>패키지를 만든 뒤 소스 저장소에서 실행할 명령.</summary>
        public static string GitTagCommand(ReleaseRecord r)
        {
            return "git tag -a " + r.Tag + " -m \"" + r.Program + " " + r.Version + " 배포\"\r\ngit push origin " + r.Tag;
        }

        private static string ReleaseNotes(PackageRequest r, DateTime now)
        {
            return "# " + r.Program + " v" + r.Version + "\n\n배포일: " + now.ToString("yyyy-MM-dd HH:mm") + "\n\n## 변경 내역\n"
                   + (string.IsNullOrWhiteSpace(r.Notes) ? "-" : r.Notes.Replace("\r\n", "\n").Trim()) + "\n";
        }

        private static void ZipFolder(string folder, string zipPath)
        {
            using (var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                foreach (var file in Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories))
                {
                    if (ExcludedExtensions.Any(e => file.EndsWith(e, StringComparison.OrdinalIgnoreCase)))
                    {
                        continue;
                    }

                    zip.CreateEntryFromFile(file, file.Substring(folder.Length).TrimStart('\\', '/'), CompressionLevel.Optimal);
                }
            }
        }

        private static void CopyFolder(string source, string target)
        {
            foreach (var file in Directory.EnumerateFiles(source, "*", SearchOption.AllDirectories))
            {
                var dest = Path.Combine(target, file.Substring(source.Length).TrimStart('\\', '/'));
                Directory.CreateDirectory(Path.GetDirectoryName(dest));
                File.Copy(file, dest);
            }
        }

        /// <summary>sha256sum 형식: "해시  상대경로"</summary>
        public static string Checksums(string folder)
        {
            var lines = new List<string>();
            using (var sha = SHA256.Create())
            {
                foreach (var file in Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories).OrderBy(f => f, StringComparer.Ordinal))
                {
                    var relative = file.Substring(folder.Length).TrimStart('\\', '/').Replace('\\', '/');
                    if (relative == "SHA256SUMS.txt")
                    {
                        continue;
                    }

                    using (var stream = File.OpenRead(file))
                    {
                        var hash = BitConverter.ToString(sha.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                        lines.Add(hash + "  " + relative);
                    }
                }
            }

            return string.Join("\n", lines) + "\n";
        }
    }
}
