using System;
using System.Collections.Generic;
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
                ProgramChecks(root + "_programs");
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

        /// <summary>
        /// 실제 git으로 사용자 시나리오: OCR 기준본 1.0.0을 ESWA·ESHD·ESOT가 사용 → ESWA만 1.1.0 배포 →
        /// 설치 현황에서 ESHD·ESOT는 업데이트 가능. 과거 zip 가져오기, 기존 저장소 등록, NAS(임시 bare) 백업.
        /// </summary>
        private static void ProgramChecks(string root)
        {
            if (!GitRunner.IsAvailable)
            {
                Fail("git이 없어 프로그램 검증을 건너뜀");
                return;
            }

            // 사용자 git 설정(safe.directory)을 건드리지 않도록 검증용 설정 파일을 쓴다.
            var globalConfig = Path.Combine(root, "gitconfig");
            var savedGlobal = Environment.GetEnvironmentVariable("GIT_CONFIG_GLOBAL");
            try
            {
                Directory.CreateDirectory(root);
                File.WriteAllText(globalConfig, "");
                Environment.SetEnvironmentVariable("GIT_CONFIG_GLOBAL", globalConfig);
                var now = new DateTime(2026, 10, 22, 18, 0, 0);
                var ws = Workspace.Open(Path.Combine(root, "data"), Templates);
                ws.Settings.ReleaseStore = Path.Combine(root, "NAS", "TSWork", "Releases");
                Check("Git 백업 위치 자동 = 보관소 옆 Git", ws.GitStore == Path.Combine(root, "NAS", "TSWork", "Git"), ws.GitStore);

                Check("버전 계산", VersionUtil.Next("1.0.0", VersionStep.Patch) == "1.0.1" && VersionUtil.Next("1.0.3", VersionStep.Minor) == "1.1.0"
                                  && VersionUtil.Next("1.4.2", VersionStep.Major) == "2.0.0" && VersionUtil.Latest(new[] { "1.2.0", "v1.10.0", "1.9.9" }) == "1.10.0");
                Check("인수 감싸기", GitRunner.Quote("a b") == "\"a b\"" && GitRunner.Quote(@"C:\x y\") == "\"C:\\x y\\\\\"" && GitRunner.Quote("") == "\"\"");

                // 코드 폴더 (아직 Git 아님) + 빌드 결과
                var code = Path.Combine(root, "Source", "OCR");
                Directory.CreateDirectory(Path.Combine(code, "OCR", "bin", "Release"));
                File.WriteAllText(Path.Combine(code, "OCR.sln"), "sln");
                File.WriteAllText(Path.Combine(code, "OCR", "Main.cs"), "class A { } // 기준");
                File.WriteAllText(Path.Combine(code, "OCR", "bin", "Release", "OCR.exe"), "exe-1.0.0");
                var ocr = new ProgramInfo
                {
                    Name = "OCR",
                    CodeFolder = code,
                    BuildFolder = Path.Combine(code, "OCR", "bin", "Release"),
                    GitRemote = Path.Combine(ws.GitStore, "OCR.git")
                };
                var sites = new[] { "ESWA", "ESHD", "ESOT" }.Select(s => new Deployment { Customer = "LGES", Site = s, Equipment = "OCR 검사기" }).ToList();
                var service = new ProgramService(ws);
                var current = service.Register(ocr, "1.0.0", new DateTime(2025, 3, 1), sites, null);
                var git = service.Git(ocr);
                Check("등록: Git 저장소·기준본 태그", current == "1.0.0" && git.IsRepo && git.TagExists("v1.0.0") && git.IsClean);
                Check("등록: bin은 기록 안 함", !git.Run("ls-files").Output.Contains("bin/"));
                var baseRelease = ws.Releases.Find("OCR", "1.0.0");
                Check("등록: 기준본 배포본(소스 zip·빌드 zip)", baseRelease != null
                                                       && File.Exists(Path.Combine(baseRelease.PackagePath, "OCR_v1.0.0_source.zip"))
                                                       && File.Exists(Path.Combine(baseRelease.PackagePath, "OCR_v1.0.0.zip")));
                Check("등록: 3사이트 1.0.0 설치", service.InstallStatus().Count(r => r.Program == "OCR" && r.Version == "1.0.0") == 3);
                Check("등록: NAS 백업", new GitRunner(ocr.GitRemote, "x").Run("rev-parse", "-q", "--verify", "refs/tags/v1.0.0").Ok);

                // ESWA 요청 → 업무 카드 → VS에서 커밋 (여기서는 git으로 대신)
                var card = ws.NewItem(WorkType.ProgramChange, now.AddDays(-2));
                card.Title = "ESWA 검사 영역 이탈";
                card.Site = "ESWA";
                ws.Save(card);
                File.WriteAllText(Path.Combine(code, "OCR", "Main.cs"), "class A { } // 수정");
                Check("커밋 전에는 배포 거부", Throws(() => { ReleaseRecord ignored; service.NewRelease(new NewReleaseRequest { Program = "OCR", Version = "1.1.0" }, null, out ignored); }));
                git.CommitAll(card.Id + " [ESWA] 검사 영역 이탈 수정", null);
                File.WriteAllText(Path.Combine(code, "OCR", "bin", "Release", "OCR.exe"), "exe-1.1.0");

                var pending = service.GetPending(ocr);
                Check("새 버전 화면 정보: 최신 1.0.0·새 커밋 1개·업무 ID 인식", pending.LatestVersion == "1.0.0" && pending.NewCommits.Count == 1
                                                                      && pending.WorkItemIds.SequenceEqual(new[] { card.Id }) && pending.UncommittedFiles.Count == 0
                                                                      && pending.SuggestedNotes.Contains("검사 영역 이탈 수정"));
                ReleaseRecord v110;
                var line = service.NewRelease(new NewReleaseRequest
                {
                    Program = "OCR",
                    Version = VersionUtil.Next(pending.LatestVersion, VersionStep.Minor),
                    Notes = pending.SuggestedNotes,
                    WorkItemIds = pending.WorkItemIds,
                    Targets = { new Deployment { Customer = "LGES", Site = "ESWA", Equipment = "OCR 검사기" } },
                    DeployedAt = now
                }, null, out v110);
                Check("배포: 태그·배포본·소스 zip", git.TagExists("v1.1.0") && File.Exists(Path.Combine(v110.PackagePath, "OCR_v1.1.0_source.zip")) && line.Contains("v1.1.0"));
                using (var zip = System.IO.Compression.ZipFile.OpenRead(Path.Combine(v110.PackagePath, "OCR_v1.1.0_source.zip")))
                {
                    Check("소스 zip은 그 버전 코드", zip.Entries.Any(e => e.FullName == "OCR/Main.cs") && !zip.Entries.Any(e => e.FullName.Contains("bin/")));
                }

                var reCard = ws.Items.Find(card.Id);
                Check("업무 카드 변경 내역 자동 기입", reCard.ChangedFiles.Contains("OCR v1.1.0") && reCard.ChangedFiles.Contains(v110.Commit));
                var status = service.InstallStatus().Where(r => r.Program == "OCR").ToList();
                Check("설치 현황: ESWA 1.1.0 최신, 나머지 1.0.0 업데이트 가능",
                    status.Single(r => r.Site == "ESWA").Version == "1.1.0" && status.Single(r => r.Site == "ESWA").IsLatest
                    && status.Where(r => r.Site != "ESWA").All(r => r.Version == "1.0.0" && !r.IsLatest && r.LatestVersion == "1.1.0"));
                Check("낮은 버전 배포 거부", Throws(() => { ReleaseRecord ignored; service.NewRelease(new NewReleaseRequest { Program = "OCR", Version = "1.0.5" }, null, out ignored); }));
                Check("NAS에 1.1.0", new GitRunner(ocr.GitRemote, "x").Run("rev-parse", "-q", "--verify", "refs/tags/v1.1.0").Ok);

                // 과거 버전 zip 가져오기 (LineScan처럼 날짜별 zip만 있던 프로그램)
                var zips = Path.Combine(root, "zips");
                foreach (var day in new[] { "20221223", "20231213" })
                {
                    var src = Path.Combine(root, "src_" + day, "LineScan_" + day);
                    Directory.CreateDirectory(src);
                    File.WriteAllText(Path.Combine(src, "Scan.cs"), "// " + day);
                    if (day == "20221223")
                    {
                        File.WriteAllText(Path.Combine(src, "Old.cs"), "// 다음 버전에서 삭제");
                    }

                    Directory.CreateDirectory(zips);
                    System.IO.Compression.ZipFile.CreateFromDirectory(Path.GetDirectoryName(src), Path.Combine(zips, day + "_LineScan_현장적용본.zip"));
                }

                var lineScan = new ProgramInfo { Name = "LineScan", CodeFolder = Path.Combine(root, "Source", "LineScan") };
                var emptyResult = service.Register(lineScan, "1.0.0", DateTime.Today, new List<Deployment>(), null);
                Check("빈 폴더 등록: 프로그램만 저장", emptyResult == null && ws.FindProgram("LineScan") != null && Directory.Exists(lineScan.CodeFolder));
                var lsCard = ws.NewItem(WorkType.ProgramChange, new DateTime(2023, 12, 11));
                lsCard.Title = "포커스 알람";
                ws.Save(lsCard);
                service.ImportVersions(lineScan, new List<ImportVersion>
                {
                    new ImportVersion { SourcePath = Path.Combine(zips, "20231213_LineScan_현장적용본.zip"), Date = new DateTime(2023, 12, 13, 12, 0, 0), Version = "1.1.0", WorkItemId = lsCard.Id },
                    new ImportVersion { SourcePath = Path.Combine(zips, "20221223_LineScan_현장적용본.zip"), Date = new DateTime(2022, 12, 23, 12, 0, 0), Version = "1.0.0", Note = "기준본" }
                }, null);
                var lsGit = service.Git(lineScan);
                var tags = lsGit.Tags();
                Check("가져오기: 날짜순 커밋·태그", tags.Select(t => t.Tag).SequenceEqual(new[] { "v1.0.0", "v1.1.0" })
                                              && tags[0].Date.Date == new DateTime(2022, 12, 23) && tags[1].Subject.StartsWith(lsCard.Id));
                Check("가져오기: 겉 폴더 벗기기·지워진 파일 반영", File.Exists(Path.Combine(lineScan.CodeFolder, "Scan.cs"))
                                                           && !File.Exists(Path.Combine(lineScan.CodeFolder, "Old.cs"))
                                                           && !Directory.Exists(Path.Combine(lineScan.CodeFolder, "LineScan_20231213")));
                Check("가져오기: 배포 기록·카드 연결", ws.Releases.Find("LineScan", "1.1.0").WorkItemIds.Single() == lsCard.Id
                                                 && ws.Items.Find(lsCard.Id).ChangedFiles.Contains("LineScan v1.1.0"));

                // 이미 Git인 폴더 등록 (태그 v1.0.0 + 태그 없는 커밋 1개)
                var existing = Path.Combine(root, "Source", "Existing");
                var exGit = new GitRunner(existing, "x");
                exGit.Init();
                File.WriteAllText(Path.Combine(existing, "a.cs"), "1");
                exGit.CommitAll("기준본", new DateTime(2022, 1, 1));
                exGit.Tag("v1.0.0", "기준", null, new DateTime(2022, 1, 1));
                File.WriteAllText(Path.Combine(existing, "a.cs"), "2");
                exGit.CommitAll("TS-2023-12-0009 기능 추가", new DateTime(2023, 12, 13));
                var exCurrent = service.Register(new ProgramInfo { Name = "Existing", CodeFolder = existing }, "1.0.0", new DateTime(2023, 12, 13), new List<Deployment>(), null);
                Check("기존 저장소 등록: 태그 없는 커밋 → 1.1.0", exCurrent == "1.1.0" && ws.Releases.Find("Existing", "1.1.0").WorkItemIds.Single() == "TS-2023-12-0009"
                                                               && ws.Releases.Find("Existing", "1.0.0") != null);

                var reopened = Workspace.Open(Path.Combine(root, "data"), Templates);
                Check("programs.json 저장·로드", reopened.Programs.Select(p => p.Name).OrderBy(n => n).SequenceEqual(new[] { "Existing", "LineScan", "OCR" }));
                Check("전체 NAS 백업", new ProgramService(reopened).PushAll().Count == 0);
                var ocrRemote = Path.Combine(root, "NAS", "TSWork", "Git", "OCR.git").Replace('\\', '/');
                var trusted = File.ReadAllText(globalConfig);
                Check("NAS 저장소를 safe.directory에 한 번만 등록", trusted.Split('\n').Count(l => l.Trim().EndsWith(ocrRemote, StringComparison.OrdinalIgnoreCase)) == 1, trusted);
            }
            finally
            {
                Environment.SetEnvironmentVariable("GIT_CONFIG_GLOBAL", savedGlobal);
                if (Directory.Exists(root))
                {
                    foreach (var f in Directory.GetFiles(root, "*", SearchOption.AllDirectories))
                    {
                        File.SetAttributes(f, FileAttributes.Normal);
                    }

                    Directory.Delete(root, true);
                }
            }
        }

        private static bool Throws(Action action)
        {
            try
            {
                action();
                return false;
            }
            catch (InvalidOperationException)
            {
                return true;
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
