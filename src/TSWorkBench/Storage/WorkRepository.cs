using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TSWorkBench.Models;

namespace TSWorkBench.Storage
{
    /// <summary>
    /// 업무 카드 저장소. 카드 1건 = Items\{연도}\{ID}\item.json, 첨부는 같은 폴더의 files\.
    /// 시작할 때 전부 메모리에 올리고, 저장할 때마다 해당 파일만 다시 쓴다.
    /// </summary>
    public sealed class WorkRepository
    {
        private const string ItemFileName = "item.json";
        private readonly string itemsDir;
        private readonly string trashDir;
        private readonly List<WorkItem> items = new List<WorkItem>();

        public WorkRepository(string itemsDir, string trashDir)
        {
            this.itemsDir = itemsDir;
            this.trashDir = trashDir;
        }

        public IReadOnlyList<WorkItem> All => items;

        /// <summary>읽지 못한 파일과 이유. 화면에 경고로 보여준다.</summary>
        public List<string> LoadErrors { get; } = new List<string>();

        public void LoadAll()
        {
            items.Clear();
            LoadErrors.Clear();
            if (!Directory.Exists(itemsDir))
            {
                return;
            }

            foreach (var file in Directory.EnumerateFiles(itemsDir, ItemFileName, SearchOption.AllDirectories))
            {
                try
                {
                    var item = JsonFile.Read<WorkItem>(file);
                    if (item != null && !string.IsNullOrEmpty(item.Id))
                    {
                        items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    LoadErrors.Add(file + " : " + ex.Message);
                }
            }
        }

        public WorkItem Find(string id)
        {
            return items.FirstOrDefault(i => string.Equals(i.Id, id, StringComparison.OrdinalIgnoreCase));
        }

        public string FolderOf(WorkItem item)
        {
            return Path.Combine(itemsDir, YearOf(item.Id), item.Id);
        }

        /// <summary>앞머리-연도-월-번호 (TS-2026-12-0001). 번호는 달마다 0001부터 다시 센다.</summary>
        public string NewId(string prefix, DateTime received)
        {
            var head = prefix + "-" + received.ToString("yyyy-MM", CultureInfo.InvariantCulture) + "-";
            var max = 0;
            var used = items.Select(i => i.Id).Concat(items.SelectMany(i => i.PreviousIds)).Concat(ExistingFolderNames(received.Year));
            foreach (var id in used)
            {
                int n;
                if (id.StartsWith(head, StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(id.Substring(head.Length), NumberStyles.None, CultureInfo.InvariantCulture, out n)
                    && n > max)
                {
                    max = n;
                }
            }

            return head + (max + 1).ToString("0000", CultureInfo.InvariantCulture);
        }

        /// <summary>저장하고 메모리 목록의 같은 ID 카드를 교체한다. ID가 비어 있으면 새로 부여한다.</summary>
        public void Save(WorkItem item, string idPrefix)
        {
            var now = DateTime.Now;
            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = NewId(idPrefix, item.ReceivedAt);
                item.CreatedAt = now;
            }

            item.UpdatedAt = now;
            JsonFile.WriteAtomic(Path.Combine(FolderOf(item), ItemFileName), item);

            var index = items.FindIndex(i => i.Id == item.Id);
            if (index >= 0)
            {
                items[index] = item;
            }
            else
            {
                items.Add(item);
            }
        }

        /// <summary>ID의 연·월 부분. 새 형식 TS-2026-06-0003 → "2026-06", 예전 형식 TS-2026-0001 → "2026".</summary>
        public static string IdMonth(string id)
        {
            var parts = (id ?? "").Split('-');
            if (parts.Length >= 4)
            {
                return parts[1] + "-" + parts[2];
            }

            return parts.Length == 3 ? parts[1] : "";
        }

        /// <summary>ID의 연·월(예전 형식은 연도)이 접수 일시와 같은지. ID가 없으면 true.</summary>
        public static bool IdMatchesReceived(WorkItem item)
        {
            if (string.IsNullOrEmpty(item.Id))
            {
                return true;
            }

            var month = IdMonth(item.Id);
            var expected = month.Length == 4
                ? item.ReceivedAt.ToString("yyyy", CultureInfo.InvariantCulture)
                : item.ReceivedAt.ToString("yyyy-MM", CultureInfo.InvariantCulture);
            return month == expected;
        }

        /// <summary>
        /// 업무 ID를 바꾼다. 업무 폴더를 첨부째 새 ID 폴더로 옮기고 새 위치에 저장한다.
        /// 예전 ID는 PreviousIds에 남겨 그 번호를 다시 쓰지 않게 한다.
        /// </summary>
        public void ChangeId(WorkItem item, string newId)
        {
            var oldId = item.Id;
            var oldFolder = FolderOf(item);
            var newFolder = Path.Combine(itemsDir, YearOf(newId), newId);
            if (Directory.Exists(newFolder))
            {
                throw new IOException("같은 ID 폴더가 이미 있습니다: " + newFolder);
            }

            if (Directory.Exists(oldFolder))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(newFolder));
                Directory.Move(oldFolder, newFolder);
            }

            items.RemoveAll(i => i.Id == oldId);
            item.Id = newId;
            if (!item.PreviousIds.Contains(oldId))
            {
                item.PreviousIds.Add(oldId);
            }

            item.UpdatedAt = DateTime.Now;
            JsonFile.WriteAtomic(Path.Combine(newFolder, ItemFileName), item);
            items.Add(item);
        }

        /// <summary>폴더째 Trash로 옮긴다. 완전히 지우지 않는다.</summary>
        public void MoveToTrash(WorkItem item)
        {
            var folder = FolderOf(item);
            if (Directory.Exists(folder))
            {
                Directory.CreateDirectory(trashDir);
                var target = Path.Combine(trashDir, item.Id + "_" + DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture));
                Directory.Move(folder, target);
            }

            items.RemoveAll(i => i.Id == item.Id);
        }

        /// <summary>파일을 업무 폴더 files\로 복사하고 상대 경로를 돌려준다. 이름이 겹치면 (2), (3)을 붙인다.</summary>
        public string CopyIntoItem(WorkItem item, string sourceFile)
        {
            var filesDir = Path.Combine(FolderOf(item), "files");
            Directory.CreateDirectory(filesDir);
            var target = UniquePath(filesDir, Path.GetFileName(sourceFile));
            File.Copy(sourceFile, target);
            return Path.Combine("files", Path.GetFileName(target));
        }

        public string ResolvePath(WorkItem item, AttachmentRef attachment)
        {
            return attachment.Copied ? Path.Combine(FolderOf(item), attachment.Path) : attachment.Path;
        }

        public static string UniquePath(string dir, string fileName)
        {
            var path = Path.Combine(dir, fileName);
            var stem = Path.GetFileNameWithoutExtension(fileName);
            var ext = Path.GetExtension(fileName);
            for (var n = 2; File.Exists(path) || Directory.Exists(path); n++)
            {
                path = Path.Combine(dir, stem + " (" + n.ToString(CultureInfo.InvariantCulture) + ")" + ext);
            }

            return path;
        }

        /// <summary>ID의 연도 부분. 앞머리에는 '-'를 못 쓰므로 항상 두 번째 조각이다 (예전 형식 TS-2026-0001도 같음).</summary>
        private static string YearOf(string id)
        {
            var parts = id.Split('-');
            return parts.Length >= 3 ? parts[1] : "etc";
        }

        /// <summary>폴더 이름으로 남은 ID. 휴지통의 "ID_시각" 폴더도 넣어서 지운 업무의 번호를 다시 쓰지 않는다.</summary>
        private IEnumerable<string> ExistingFolderNames(int year)
        {
            var dir = Path.Combine(itemsDir, year.ToString(CultureInfo.InvariantCulture));
            var live = Directory.Exists(dir) ? Directory.EnumerateDirectories(dir).Select(Path.GetFileName) : Enumerable.Empty<string>();
            var trashed = Directory.Exists(trashDir)
                ? Directory.EnumerateDirectories(trashDir).Select(d => Path.GetFileName(d).Split('_')[0])
                : Enumerable.Empty<string>();
            return live.Concat(trashed);
        }
    }
}
