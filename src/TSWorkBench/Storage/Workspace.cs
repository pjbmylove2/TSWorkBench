using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TSWorkBench.Models;

namespace TSWorkBench.Storage
{
    /// <summary>
    /// 데이터 폴더 하나 = 작업 공간 하나. 폴더를 통째로 복사하면 다른 PC·회사로 그대로 옮겨진다.
    /// <code>
    /// 데이터 폴더\
    ///   settings.json   사용자·부서·ID 앞머리
    ///   masters.json    고객사·설비·시스템 목록, 체크리스트 템플릿
    ///   programs.json   버전 관리하는 프로그램 (코드 폴더·빌드 폴더·NAS 코드 백업 위치)
    ///   Items\2026\TS-2026-10-0001\item.json, files\
    ///   Templates\      보고서 템플릿 (수정 가능)
    ///   Reports\        생성된 보고서
    ///   Releases\       배포 기록 (프로그램\버전.json)
    ///   Backups\        자동 백업 zip (설정에서 다른 폴더 지정 가능)
    ///   Trash\          삭제한 업무
    /// </code>
    /// </summary>
    public sealed class Workspace
    {
        private Workspace(string root)
        {
            Root = root;
            Items = new WorkRepository(Path.Combine(root, "Items"), Path.Combine(root, "Trash"));
            Releases = new ReleaseRepository(Path.Combine(root, "Releases"));
        }

        public string Root { get; }
        public string TemplatesDir => Path.Combine(Root, "Templates");
        public string ReportsDir => Path.Combine(Root, "Reports");
        public AppSettings Settings { get; private set; }
        public MasterData Masters { get; private set; }
        public WorkRepository Items { get; }
        public ReleaseRepository Releases { get; }

        /// <summary>버전을 관리하는 프로그램 목록 (programs.json).</summary>
        public List<ProgramInfo> Programs { get; private set; } = new List<ProgramInfo>();

        private string SettingsPath => Path.Combine(Root, "settings.json");
        private string MastersPath => Path.Combine(Root, "masters.json");
        private string ProgramsPath => Path.Combine(Root, "programs.json");

        /// <summary>NAS 코드 백업 폴더. 설정이 비어 있으면 배포본 보관소 옆 Git 폴더 (…\TSWork\Releases → …\TSWork\Git).</summary>
        public string GitStore
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Settings.GitStore))
                {
                    return Settings.GitStore.Trim();
                }

                var store = (Settings.ReleaseStore ?? "").Trim().TrimEnd('\\', '/');
                var parent = store.Length == 0 ? null : Path.GetDirectoryName(store);
                return string.IsNullOrEmpty(parent) ? "" : Path.Combine(parent, "Git");
            }
        }

        public ProgramInfo FindProgram(string name)
        {
            return Programs.FirstOrDefault(p => string.Equals(p.Name, name?.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public void SavePrograms()
        {
            JsonFile.WriteAtomic(ProgramsPath, Programs);
        }

        /// <summary>폴더가 없으면 만들고, 빠진 기본 파일·템플릿을 채운 뒤 업무를 모두 읽는다.</summary>
        public static Workspace Open(string root, string defaultTemplatesDir)
        {
            var ws = new Workspace(root);
            Directory.CreateDirectory(root);
            Directory.CreateDirectory(ws.ReportsDir);

            ws.Settings = File.Exists(ws.SettingsPath) ? JsonFile.Read<AppSettings>(ws.SettingsPath) : new AppSettings();
            ws.Masters = File.Exists(ws.MastersPath) ? JsonFile.Read<MasterData>(ws.MastersPath) : MasterData.CreateDefault();
            if (!File.Exists(ws.SettingsPath))
            {
                ws.SaveSettings();
            }

            if (!File.Exists(ws.MastersPath))
            {
                ws.SaveMasters();
            }

            CopyMissingTemplates(defaultTemplatesDir, ws.TemplatesDir);
            ws.Items.LoadAll();
            ws.Releases.LoadAll();
            ws.LoadPrograms();
            return ws;
        }

        /// <summary>programs.json을 읽는다. 없으면 예전 기준 정보의 '프로그램' 목록과 배포 기록의 프로그램 이름으로 만든다.</summary>
        private void LoadPrograms()
        {
            if (File.Exists(ProgramsPath))
            {
                Programs = JsonFile.Read<List<ProgramInfo>>(ProgramsPath) ?? new List<ProgramInfo>();
                return;
            }

            var names = MasterData.Names(Masters.Programs).Concat(Releases.All.Select(r => r.Program))
                .Where(n => !string.IsNullOrWhiteSpace(n)).Distinct(StringComparer.OrdinalIgnoreCase);
            Programs = names.Select(n => new ProgramInfo { Name = n.Trim(), CreatedAt = DateTime.Now }).ToList();
            if (Programs.Count > 0)
            {
                SavePrograms();
            }
        }

        public void SaveSettings()
        {
            JsonFile.WriteAtomic(SettingsPath, Settings);
        }

        public void SaveMasters()
        {
            JsonFile.WriteAtomic(MastersPath, Masters);
        }

        public void Save(WorkItem item)
        {
            Items.Save(item, Settings.IdPrefix);
        }

        /// <summary>
        /// 접수 일시의 연·월로 ID를 다시 받는다. 후속 업무의 원본 ID와 배포 기록의 업무 ID도 함께 바꾼다.
        /// 이미 만든 보고서 파일과 다른 카드 글 속에 적힌 ID 글자는 바꾸지 않는다. 새 ID를 돌려준다.
        /// </summary>
        public string ReassignId(WorkItem item, DateTime now)
        {
            var oldId = item.Id;
            var newId = Items.NewId(Settings.IdPrefix, item.ReceivedAt);
            item.Timeline.Add(new TimelineEntry
            {
                Start = now,
                Kind = TimelineKind.Note,
                Text = "업무 ID 변경: " + oldId + " → " + newId + " (접수 일시 수정)"
            });
            Items.ChangeId(item, newId);

            foreach (var child in Items.All.Where(i => i.ParentId == oldId).ToList())
            {
                child.ParentId = newId;
                Save(child);
            }

            foreach (var release in Releases.All.ToList())
            {
                var changed = false;
                for (var k = 0; k < release.WorkItemIds.Count; k++)
                {
                    if (release.WorkItemIds[k] == oldId)
                    {
                        release.WorkItemIds[k] = newId;
                        changed = true;
                    }
                }

                foreach (var d in release.Deployments.Where(d => d.WorkItemId == oldId))
                {
                    d.WorkItemId = newId;
                    changed = true;
                }

                if (changed)
                {
                    Releases.Save(release);
                }
            }

            return newId;
        }

        /// <summary>저장 전 새 업무. 유형별 체크리스트를 미리 채운다.</summary>
        public WorkItem NewItem(WorkType type, DateTime now)
        {
            var item = new WorkItem { Type = type, ReceivedAt = now };
            FillChecklist(item);
            item.Timeline.Add(new TimelineEntry { Start = now, Kind = TimelineKind.Contact, Text = "업무 접수" });
            return item;
        }

        /// <summary>
        /// 반복 업무(정기 점검 등)용 복제. 어디·무엇·현상과 체크리스트 항목만 가져오고
        /// 원인·조치·검증·이력·첨부는 비운다. 저장 전이라 ID는 없다.
        /// </summary>
        public WorkItem Duplicate(WorkItem source, DateTime now)
        {
            var item = new WorkItem
            {
                Title = source.Title,
                Type = source.Type,
                Priority = source.Priority,
                Customer = source.Customer,
                Site = source.Site,
                Equipment = source.Equipment,
                TargetSystem = source.TargetSystem,
                Tags = source.Tags,
                Requester = source.Requester,
                Symptom = source.Symptom,
                ReceivedAt = now
            };
            item.Checklist.AddRange(source.Checklist.Select(c => new ChecklistItem { Text = c.Text }));
            item.Timeline.Add(new TimelineEntry { Start = now, Kind = TimelineKind.Note, Text = source.Id + " 복제" });
            return item;
        }

        public void FillChecklist(WorkItem item)
        {
            foreach (var text in Masters.ChecklistFor(item.Type))
            {
                item.Checklist.Add(new ChecklistItem { Text = text });
            }
        }

        public string ReadTemplate(string fileName)
        {
            return File.ReadAllText(Path.Combine(TemplatesDir, fileName));
        }

        private static void CopyMissingTemplates(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            if (!Directory.Exists(sourceDir))
            {
                return;
            }

            foreach (var file in Directory.GetFiles(sourceDir))
            {
                var target = Path.Combine(targetDir, Path.GetFileName(file));
                if (!File.Exists(target))
                {
                    File.Copy(file, target);
                }
            }
        }
    }
}
