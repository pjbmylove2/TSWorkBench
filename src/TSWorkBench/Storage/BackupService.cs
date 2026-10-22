using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace TSWorkBench.Storage
{
    /// <summary>
    /// 하루 한 번 업무 기록을 zip으로 남긴다 (TSWorkData_20261022.zip).
    /// 들어가는 것: settings.json, masters.json, 모든 item.json, Templates. 첨부(files\)는 용량 때문에 넣지 않는다.
    /// </summary>
    public static class BackupService
    {
        private const string FilePrefix = "TSWorkData_";

        public static string FolderOf(Workspace ws)
        {
            return string.IsNullOrWhiteSpace(ws.Settings.BackupFolder) ? Path.Combine(ws.Root, "Backups") : ws.Settings.BackupFolder;
        }

        /// <summary>오늘 백업이 없으면 만든다. 만들었으면 경로, 이미 있으면 null.</summary>
        public static string RunDaily(Workspace ws, DateTime now)
        {
            var path = Path.Combine(FolderOf(ws), FilePrefix + now.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".zip");
            return File.Exists(path) ? null : Create(ws, path);
        }

        /// <summary>지금 바로 백업한다. 같은 날 여러 번 누르면 시각을 붙여 따로 남긴다.</summary>
        public static string RunNow(Workspace ws, DateTime now)
        {
            var path = Path.Combine(FolderOf(ws), FilePrefix + now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".zip");
            return Create(ws, path);
        }

        private static string Create(Workspace ws, string path)
        {
            var folder = Path.GetDirectoryName(path);
            Directory.CreateDirectory(folder);
            var tmp = path + ".tmp";
            using (var zip = ZipFile.Open(tmp, ZipArchiveMode.Create))
            {
                foreach (var file in FilesToBackup(ws.Root))
                {
                    try
                    {
                        zip.CreateEntryFromFile(file, file.Substring(ws.Root.Length).TrimStart('\\', '/'), CompressionLevel.Optimal);
                    }
                    catch (IOException ex)
                    {
                        // 저장 중인 파일 하나 때문에 백업 전체를 버리지 않는다.
                        ErrorLog.Write("백업에서 빠진 파일: " + file, ex);
                    }
                }
            }

            File.Move(tmp, path);
            Prune(folder, ws.Settings.BackupKeepCount);
            return path;
        }

        private static IEnumerable<string> FilesToBackup(string root)
        {
            foreach (var name in new[] { "settings.json", "masters.json" })
            {
                var file = Path.Combine(root, name);
                if (File.Exists(file))
                {
                    yield return file;
                }
            }

            var items = Path.Combine(root, "Items");
            if (Directory.Exists(items))
            {
                foreach (var file in Directory.EnumerateFiles(items, "item.json", SearchOption.AllDirectories))
                {
                    yield return file;
                }
            }

            var templates = Path.Combine(root, "Templates");
            if (Directory.Exists(templates))
            {
                foreach (var file in Directory.EnumerateFiles(templates))
                {
                    yield return file;
                }
            }
        }

        /// <summary>최근 keep개만 남기고 오래된 백업을 지운다. keep이 0 이하면 지우지 않는다.</summary>
        private static void Prune(string folder, int keep)
        {
            if (keep <= 0)
            {
                return;
            }

            foreach (var old in Directory.GetFiles(folder, FilePrefix + "*.zip").OrderByDescending(Path.GetFileName).Skip(keep))
            {
                File.Delete(old);
            }
        }
    }
}
