using System;
using System.IO;
using System.Linq;
using TSWorkBench.Models;
using TSWorkBench.Services;
using TSWorkBench.Storage;

namespace TSWorkBench.Checks
{
    /// <summary>
    /// 화면 없이 핵심 로직을 확인하는 검증 프로그램. 실패가 하나라도 있으면 종료 코드 1.
    /// 임시 폴더에 작업 공간을 만들고 끝나면 지운다.
    /// </summary>
    internal static class Program
    {
        private static int failures;

        private static int Main(string[] args)
        {
            if (args.Length == 2 && args[0] == "--examples")
            {
                ExampleChecks(args[1]);
                Console.WriteLine(failures == 0 ? "EXAMPLES OK" : failures + " FAILED");
                return failures == 0 ? 0 : 1;
            }

            var root = Path.Combine(Path.GetTempPath(), "TSWorkBench.Checks_" + Guid.NewGuid().ToString("N"));
            try
            {
                StorageChecks(root);
                WorkflowChecks();
                TemplateChecks();
                ImportChecks();
                ReportChecks(root);
                FeatureChecks(root + "_features");
            }
            catch (Exception ex)
            {
                Fail("예외 발생: " + ex);
            }
            finally
            {
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }

            Console.WriteLine(failures == 0 ? "ALL PASSED" : failures + " FAILED");
            return failures == 0 ? 0 : 1;
        }

        private static string Templates => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates");

        private static void StorageChecks(string root)
        {
            var ws = Workspace.Open(root, Templates);
            Check("기본 파일 생성", File.Exists(Path.Combine(root, "settings.json")) && File.Exists(Path.Combine(root, "masters.json")));
            Check("템플릿 복사", File.Exists(Path.Combine(ws.TemplatesDir, ReportGenerator.FieldReportTemplate)));

            var received = new DateTime(2026, 10, 20, 9, 30, 0);
            var a = ws.NewItem(WorkType.FieldVisit, received);
            a.Title = "2라인 OCR 오판정";
            a.Customer = "A사";
            a.Symptom = "야간조부터 오판정\n시간당 5회";
            a.Timeline.Add(new TimelineEntry { Start = received.AddHours(1), End = received.AddHours(3.5), Kind = TimelineKind.OnSite, Text = "현장 확인" });
            ws.Save(a);
            Check("ID 부여", a.Id == "TS-2026-10-0001", a.Id);
            Check("체크리스트 템플릿", a.Checklist.Count > 0);

            ws.Save(a);
            var file = Path.Combine(ws.Items.FolderOf(a), "item.json");
            Check("두 번째 저장 후 .bak", File.Exists(file + ".bak"));
            Check("임시 파일 남지 않음", !File.Exists(file + ".tmp"));

            var b = ws.NewItem(WorkType.Inquiry, received);
            b.Title = "문의";
            ws.Save(b);
            var c = ws.NewItem(WorkType.Inquiry, received);
            c.Title = "문의2";
            ws.Save(c);
            Check("ID 연속", b.Id == "TS-2026-10-0002" && c.Id == "TS-2026-10-0003", b.Id + ", " + c.Id);

            ws.Items.MoveToTrash(c);
            var d = ws.NewItem(WorkType.Inquiry, received);
            d.Title = "문의3";
            ws.Save(d);
            Check("휴지통 ID 재사용 안 함", d.Id == "TS-2026-10-0004", d.Id);

            var nextMonth = ws.Items.NewId("TS", new DateTime(2026, 11, 2));
            Check("달이 바뀌면 0001부터", nextMonth == "TS-2026-11-0001", nextMonth);
            var oldFolder = ws.Items.FolderOf(new WorkItem { Id = "TS-2026-0099" });
            Check("예전 형식 ID도 연도 폴더", oldFolder.EndsWith(Path.Combine("2026", "TS-2026-0099")), oldFolder);

            var reopened = Workspace.Open(root, Templates);
            var loaded = reopened.Items.Find(a.Id);
            Check("다시 열기 건수", reopened.Items.All.Count == 3, reopened.Items.All.Count.ToString());
            Check("저장→로드 동일", loaded != null && JsonFile.Serialize(loaded) == JsonFile.Serialize(a));

            File.WriteAllText(Path.Combine(ws.Items.FolderOf(b), "item.json"), "{ 깨진 파일");
            var broken = Workspace.Open(root, Templates);
            Check("깨진 파일은 건너뛰고 오류 목록에", broken.Items.All.Count == 2 && broken.Items.LoadErrors.Count == 1);
        }

        private static void WorkflowChecks()
        {
            var now = new DateTime(2026, 10, 22, 15, 0, 0);
            var item = new WorkItem { Id = "TS-2026-10-0010", Title = "카메라 교체", Type = WorkType.HardwareFix, ReceivedAt = now.AddDays(-2) };

            var refused = false;
            try
            {
                WorkflowRules.ChangeStatus(item, WorkStatus.Canceled, now);
                WorkflowRules.ChangeStatus(item, WorkStatus.Verifying, now);
            }
            catch (InvalidOperationException)
            {
                refused = true;
            }

            Check("허용 안 된 전이 거부 (취소→검증)", refused);
            item.Status = WorkStatus.Received;
            item.Timeline.Clear();

            Check("완료 전 빈 항목", WorkflowRules.MissingForDone(item).SequenceEqual(new[] { "현상", "원인", "조치", "검증 결과" }));
            foreach (var to in new[] { WorkStatus.Analyzing, WorkStatus.InProgress, WorkStatus.Verifying, WorkStatus.Done })
            {
                WorkflowRules.ChangeStatus(item, to, now);
            }

            Check("완료 시각 기록", item.CompletedAt == now);
            Check("상태 변경 타임라인 4건", item.Timeline.Count(t => t.Kind == TimelineKind.StatusChange) == 4);

            item.NeedsRevisit = true;
            item.RevisitDate = now.Date.AddDays(3);
            var followUps = WorkflowRules.CreateFollowUps(item, new AppSettings { FollowUpDays = 7 }, now);
            Check("후속 업무 2건 (모니터링+재방문)", followUps.Count == 2);
            Check("모니터링 기한 D+7", followUps[0].DueDate == now.Date.AddDays(7) && followUps[0].ParentId == item.Id);
            Check("재방문 기한", followUps[1].DueDate == now.Date.AddDays(3) && followUps[1].Type == WorkType.FieldVisit);

            WorkflowRules.ChangeStatus(item, WorkStatus.InProgress, now);
            Check("재오픈하면 완료 시각 지움", item.CompletedAt == null);
        }

        private static void TemplateChecks()
        {
            var text = TemplateEngine.Render("[{{Id}}] {{ Title }} {{Unknown}}!", new System.Collections.Generic.Dictionary<string, string> { { "Id", "TS-1" }, { "Title", "제목" } });
            Check("템플릿 치환", text == "[TS-1] 제목 !", text);
        }

        private static void ImportChecks()
        {
            DateTime date;
            Check("날짜 yyyyMMdd", ImportScanner.TryDateFromName("20241021_2라인 카메라 교체", out date) && date.Date == new DateTime(2024, 10, 21));
            Check("날짜 yyyy-MM-dd", ImportScanner.TryDateFromName(@"A사\2024-03-05 정기점검", out date) && date.Date == new DateTime(2024, 3, 5));
            Check("날짜 yyMMdd", ImportScanner.TryDateFromName("241105 OCR 수정", out date) && date.Date == new DateTime(2024, 11, 5));
            Check("날짜 경로 끝 우선", ImportScanner.TryDateFromName(@"2023\20230115 조명", out date) && date.Date == new DateTime(2023, 1, 15));
            Check("날짜 없음", !ImportScanner.TryDateFromName("작업보고서 최종", out date));
            Check("잘못된 날짜 거부", !ImportScanner.TryDateFromName("20241345 test", out date));

            var title = ImportScanner.CleanTitle("20241021_2라인 카메라 교체");
            Check("제목 정리", title == "2라인 카메라 교체", title);
            Check("유형 추정: 교체→HW", ImportScanner.GuessType("2라인 카메라 교체") == WorkType.HardwareFix);
            Check("유형 추정: 수정→프로그램", ImportScanner.GuessType("OCR 수정") == WorkType.ProgramChange);
            Check("유형 추정: 점검", ImportScanner.GuessType("정기점검") == WorkType.PreventiveCheck);

            var decoded = ImportScanner.DecodeHeader("=?UTF-8?B?7ZWc6riA?= =?UTF-8?B?IOuplOydvA==?=");
            Check("메일 제목 디코딩", decoded == "한글 메일", decoded);
            Check("메일 날짜", ImportScanner.TryParseMailDate("Mon, 21 Oct 2024 10:00:00 +0900 (KST)", out date)
                              && date == new DateTimeOffset(2024, 10, 21, 10, 0, 0, TimeSpan.FromHours(9)).LocalDateTime);
        }

        private static void ReportChecks(string root)
        {
            var ws = Workspace.Open(root, Templates);
            ws.Settings.UserName = "홍길동";
            var item = ws.Items.All.First(i => i.Title == "2라인 OCR 오판정");
            item.Cause = "조명 열화 <측정값 60%>";
            var generator = new ReportGenerator(ws);

            var path = generator.SaveFieldReport(item);
            var html = File.ReadAllText(path);
            Check("현장 보고서 파일", File.Exists(path));
            Check("현장 보고서 치환 완료", !html.Contains("{{") && html.Contains(item.Id) && html.Contains("홍길동"));
            Check("HTML 인코딩", html.Contains("&lt;측정값 60%&gt;") && html.Contains("야간조부터 오판정<br>시간당 5회"));

            var md = generator.ItemMarkdown(item);
            Check("Notion MD", md.StartsWith("# [" + item.Id + "]") && md.Contains("| 현장 작업 |"));

            var from = new DateTime(2026, 10, 19);
            var files = generator.SavePeriodReport("주간 업무 보고", from, from.AddDays(7), new DateTime(2026, 10, 22));
            var period = File.ReadAllText(files[0]);
            Check("주간 보고 MD·HTML", files.All(File.Exists) && period.Contains("2026-10-19 ~ 2026-10-25") && !period.Contains("{{"));
            Check("주간 보고 현장 시간", period.Contains("현장 작업 2.5시간"), period);

            var stats = StatsService.Compute(ws.Items.All.ToList(), from, from.AddDays(7), new DateTime(2026, 10, 22));
            // 깨진 파일(0002)은 읽지 않으므로 0001·0004 두 건
            Check("통계 접수 건수", stats.Received == 2, stats.Received.ToString());

            var xlsx = Path.Combine(ws.ReportsDir, "대장.xlsx");
            ExcelExporter.Export(xlsx, ws.Items.All.ToList(), stats, "통계");
            Check("엑셀 생성", File.Exists(xlsx) && new FileInfo(xlsx).Length > 1000);
        }

        /// <summary>자동 백업, 업무 복제, 유사 사례, 배포 패키지·설치 기록.</summary>
        private static void FeatureChecks(string root)
        {
            try
            {
                var now = new DateTime(2026, 10, 22, 10, 0, 0);
                var ws = Workspace.Open(Path.Combine(root, "data"), Templates);
                ws.Settings.BackupFolder = Path.Combine(root, "backup");
                ws.Settings.BackupKeepCount = 2;

                var a = ws.NewItem(WorkType.HardwareFix, now.AddDays(-5));
                a.Title = "2라인 OCR 오판정 증가";
                a.Equipment = "노칭 2호기";
                a.TargetSystem = "OCR 검사";
                a.Tags = "조명, 오판정";
                a.Cause = "조명 열화";
                a.Status = WorkStatus.Done;
                ws.Save(a);
                var other = ws.NewItem(WorkType.Inquiry, now.AddDays(-3));
                other.Title = "검사 이미지 보관 기간 문의";
                other.Equipment = "롤프레스 1호기";
                ws.Save(other);

                // 자동 백업
                var first = BackupService.RunDaily(ws, now);
                Check("백업 zip 생성", first != null && File.Exists(first));
                Check("같은 날 두 번째는 건너뜀", BackupService.RunDaily(ws, now.AddHours(3)) == null);
                using (var zip = System.IO.Compression.ZipFile.OpenRead(first))
                {
                    Check("백업에 item.json 포함", zip.Entries.Count(e => e.Name == "item.json") == 2 && zip.Entries.Any(e => e.FullName == "settings.json"));
                }

                BackupService.RunDaily(ws, now.AddDays(1));
                BackupService.RunDaily(ws, now.AddDays(2));
                Check("보관 개수만 남김", Directory.GetFiles(ws.Settings.BackupFolder, "*.zip").Length == 2);

                // 업무 ID 다시 부여 (접수 일시를 6월로 잘못 넣고 저장 → 5월로 고침)
                Check("IdMonth 새·예전 형식", WorkRepository.IdMonth("TS-2026-06-0003") == "2026-06" && WorkRepository.IdMonth("TS-2026-0001") == "2026");
                var june = ws.NewItem(WorkType.ProgramChange, new DateTime(2026, 6, 10, 9, 0, 0));
                june.Title = "접수일 잘못 넣은 업무";
                ws.Save(june);
                var juneId = june.Id;
                var juneFile = Path.Combine(ws.Items.FolderOf(june), "files", "사진.png");
                Directory.CreateDirectory(Path.GetDirectoryName(juneFile));
                File.WriteAllText(juneFile, "png");
                var follow = ws.NewItem(WorkType.FollowUp, now);
                follow.Title = "후속";
                follow.ParentId = juneId;
                ws.Save(follow);
                var linked = new ReleaseRecord { Program = "Tool", Version = "1.0.0", ReleasedAt = now, WorkItemIds = { juneId } };
                linked.Deployments.Add(new Deployment { Equipment = "설비", DeployedAt = now, WorkItemId = juneId });
                ws.Releases.Save(linked);

                june.ReceivedAt = new DateTime(2026, 5, 28, 14, 0, 0);
                Check("접수 월이 바뀌면 불일치 감지", juneId == "TS-2026-06-0001" && !WorkRepository.IdMatchesReceived(june), juneId);
                var mayId = ws.ReassignId(june, now);
                Check("새 ID는 5월 번호", mayId == "TS-2026-05-0001" && june.Id == mayId && WorkRepository.IdMatchesReceived(june), mayId);
                Check("폴더·첨부 이동", !Directory.Exists(Path.Combine(ws.Root, "Items", "2026", juneId))
                                       && File.Exists(Path.Combine(ws.Items.FolderOf(june), "files", "사진.png")));
                var re = Workspace.Open(Path.Combine(root, "data"), Templates);
                Check("다시 열어도 새 ID·연결 갱신", re.Items.Find(mayId) != null && re.Items.Find(juneId) == null
                                                && re.Items.Find(follow.Id).ParentId == mayId
                                                && re.Releases.Find("Tool", "1.0.0").WorkItemIds.Single() == mayId
                                                && re.Releases.Find("Tool", "1.0.0").Deployments.Single().WorkItemId == mayId);
                Check("ID 변경이 작업 이력에", re.Items.Find(mayId).Timeline.Any(t => t.Text.Contains(juneId + " → " + mayId)));
                Check("예전 6월 번호는 다시 안 씀", re.Items.NewId("TS", new DateTime(2026, 6, 20)) == "TS-2026-06-0002");
                ws = re;

                // 업무 복제
                a.Timeline.Add(new TimelineEntry { Start = now, Kind = TimelineKind.OnSite, Text = "x" });
                a.Checklist[0].Done = true;
                var copy = ws.Duplicate(a, now);
                Check("복제: ID 없음·어디/무엇 복사", copy.Id == "" && copy.Equipment == a.Equipment && copy.Title == a.Title);
                Check("복제: 원인 비움·체크 해제", copy.Cause == "" && copy.Checklist.All(c => !c.Done) && copy.Checklist.Count == a.Checklist.Count);

                // 유사 사례
                var probe = new WorkItem { Title = "OCR 오판정", Equipment = "노칭 2호기", Tags = "조명" };
                var similar = SimilarCases.Find(probe, ws.Items.All);
                Check("유사 사례: 같은 설비·태그 사례만", similar.Count == 1 && similar[0].Id == a.Id, string.Join(",", similar.Select(s => s.Id)));

                // 배포 패키지
                var build = Path.Combine(root, "bin");
                Directory.CreateDirectory(Path.Combine(build, "sub"));
                File.WriteAllText(Path.Combine(build, "App.exe"), "exe");
                File.WriteAllText(Path.Combine(build, "App.pdb"), "pdb");
                File.WriteAllText(Path.Combine(build, "sub", "a.dll"), "dll");
                var manual = Path.Combine(root, "manual");
                Directory.CreateDirectory(Path.Combine(manual, "images"));
                File.WriteAllText(Path.Combine(manual, "사용설명서.md"), "# 설명");
                File.WriteAllText(Path.Combine(manual, "images", "1.png"), "png");
                var store = Path.Combine(root, "Releases");
                var request = new PackageRequest { Program = "OmniSight", Version = "2.4.2", BuildFolder = build, ManualFolder = manual, Notes = "- 재연결 수정" };
                var release = ReleasePackager.Create(store, request, now);
                var folder = Path.Combine(store, "OmniSight", "v2.4.2");
                Check("패키지 폴더 구성", release.PackagePath == folder
                                       && File.Exists(Path.Combine(folder, "OmniSight_v2.4.2.zip"))
                                       && File.Exists(Path.Combine(folder, "manual", "images", "1.png"))
                                       && File.ReadAllText(Path.Combine(folder, "RELEASE_NOTES.md")).Contains("- 재연결 수정"));
                using (var zip = System.IO.Compression.ZipFile.OpenRead(Path.Combine(folder, "OmniSight_v2.4.2.zip")))
                {
                    Check("zip: pdb 제외·하위 폴더 포함", zip.Entries.Count == 2 && zip.Entries.Any(e => e.FullName.Replace('\\', '/') == "sub/a.dll"));
                }

                var sums = File.ReadAllText(Path.Combine(folder, "SHA256SUMS.txt"));
                Check("SHA256SUMS 다시 계산과 같음", sums == ReleasePackager.Checksums(folder) && sums.Contains("  manual/사용설명서.md"));
                var refused = false;
                try
                {
                    ReleasePackager.Create(store, request, now);
                }
                catch (InvalidOperationException)
                {
                    refused = true;
                }

                Check("같은 버전 다시 만들기 거부", refused && File.Exists(Path.Combine(folder, "SHA256SUMS.txt")));

                // 설치 기록·설비별 현재 버전
                release.Deployments.Add(new Deployment { Customer = "A사", Equipment = "노칭 2호기", DeployedAt = now, WorkItemId = a.Id });
                ws.Releases.Save(release);
                var v243 = new ReleaseRecord { Program = "OmniSight", Version = "2.4.3", ReleasedAt = now.AddDays(1) };
                v243.Deployments.Add(new Deployment { Customer = "A사", Equipment = "노칭 2호기", DeployedAt = now.AddDays(1), RolledBack = true });
                v243.Deployments.Add(new Deployment { Customer = "B사", Equipment = "롤프레스 1호기", DeployedAt = now.AddDays(1) });
                ws.Releases.Save(v243);
                var reopened = Workspace.Open(Path.Combine(root, "data"), Templates);
                Check("배포 기록 저장→로드", reopened.Releases.All.Count(r => r.Program == "OmniSight") == 2 && reopened.Releases.Find("omnisight", "2.4.2").Deployments.Count == 1);
                var current = ReleaseRepository.CurrentVersions(reopened.Releases.All).Where(c => c.Program == "OmniSight").ToList();
                Check("설비별 현재 버전 (되돌림 제외)", current.Count == 2
                                                 && current.Single(c => c.Equipment == "노칭 2호기").Version == "2.4.2"
                                                 && current.Single(c => c.Equipment == "롤프레스 1호기").Version == "2.4.3");

                var md = new ReportGenerator(reopened).PeriodMarkdown("주간 업무 보고", new DateTime(2026, 10, 19), new DateTime(2026, 10, 26), now);
                Check("주간 보고에 배포 표", md.Contains("| OmniSight | 2.4.2 |") && md.Contains("2.4.3 (되돌림)"), md);
            }
            finally
            {
                if (Directory.Exists(root))
                {
                    Directory.Delete(root, true);
                }
            }
        }

        /// <summary>docs\examples의 예제 데이터 폴더가 오류 없이 읽히는지 보고, 샘플 보고서를 그 폴더에 만든다.</summary>
        private static void ExampleChecks(string root)
        {
            var ws = Workspace.Open(root, Templates);
            Check("예제 읽기 오류 없음", ws.Items.LoadErrors.Count == 0, string.Join("; ", ws.Items.LoadErrors));
            Check("예제 6건", ws.Items.All.Count == 6, ws.Items.All.Count.ToString());

            var generator = new ReportGenerator(ws);
            foreach (var id in new[] { "TS-2026-10-0001", "TS-2026-10-0002" })
            {
                Console.WriteLine("  → " + generator.SaveFieldReport(ws.Items.Find(id)));
            }

            var from = new DateTime(2026, 10, 12);
            var today = new DateTime(2026, 10, 22);
            foreach (var path in generator.SavePeriodReport("주간 업무 보고", from, from.AddDays(7), today))
            {
                Console.WriteLine("  → " + path);
            }

            var all = ws.Items.All.ToList();
            var xlsx = Path.Combine(ws.ReportsDir, "업무대장_전체_예제.xlsx");
            ExcelExporter.Export(xlsx, all, StatsService.Compute(all, new DateTime(2026, 10, 1), new DateTime(2026, 11, 1), today), "2026년 10월 통계");
            Console.WriteLine("  → " + xlsx);
            File.WriteAllText(Path.Combine(ws.ReportsDir, "TS-2026-10-0001_notion.md"), generator.ItemMarkdown(ws.Items.Find("TS-2026-10-0001")));
        }

        private static void Check(string name, bool ok, string detail = "")
        {
            Console.WriteLine((ok ? "  ok   " : "  FAIL ") + name + (ok || detail.Length == 0 ? "" : "  → " + detail));
            if (!ok)
            {
                failures++;
            }
        }

        private static void Fail(string message)
        {
            Console.WriteLine("  FAIL " + message);
            failures++;
        }
    }
}
