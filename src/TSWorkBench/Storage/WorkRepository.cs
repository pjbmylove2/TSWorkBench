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

        public string NewId(string prefix, int year)
        {
            var head = prefix + "-" + year.ToString(CultureInfo.InvariantCulture) + "-";
            var max = 0;
            foreach (var id in items.Select(i => i.Id).Concat(ExistingFolderNames(year)))
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
                item.Id = NewId(idPrefix, item.ReceivedAt.Year);
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

        private static string YearOf(string id)
        {
            var parts = id.Split('-');
            return parts.Length >= 3 ? parts[parts.Length - 2] : "etc";
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
