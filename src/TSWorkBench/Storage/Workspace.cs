using System;
using System.IO;
using TSWorkBench.Models;

namespace TSWorkBench.Storage
{
    /// <summary>
    /// 데이터 폴더 하나 = 작업 공간 하나. 폴더를 통째로 복사하면 다른 PC·회사로 그대로 옮겨진다.
    /// <code>
    /// 데이터 폴더\
    ///   settings.json   사용자·부서·ID 앞머리
    ///   masters.json    고객사·설비·시스템 목록, 체크리스트 템플릿
    ///   Items\2026\TS-2026-0001\item.json, files\
    ///   Templates\      보고서 템플릿 (수정 가능)
    ///   Reports\        생성된 보고서
    ///   Trash\          삭제한 업무
    /// </code>
    /// </summary>
    public sealed class Workspace
    {
        private Workspace(string root)
        {
            Root = root;
            Items = new WorkRepository(Path.Combine(root, "Items"), Path.Combine(root, "Trash"));
        }

        public string Root { get; }
        public string TemplatesDir => Path.Combine(Root, "Templates");
        public string ReportsDir => Path.Combine(Root, "Reports");
        public AppSettings Settings { get; private set; }
        public MasterData Masters { get; private set; }
        public WorkRepository Items { get; }

        private string SettingsPath => Path.Combine(Root, "settings.json");
        private string MastersPath => Path.Combine(Root, "masters.json");

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
            return ws;
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

        /// <summary>저장 전 새 업무. 유형별 체크리스트를 미리 채운다.</summary>
        public WorkItem NewItem(WorkType type, DateTime now)
        {
            var item = new WorkItem { Type = type, ReceivedAt = now };
            FillChecklist(item);
            item.Timeline.Add(new TimelineEntry { Start = now, Kind = TimelineKind.Contact, Text = "업무 접수" });
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
