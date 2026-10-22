using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TSWorkBench.Models;

namespace TSWorkBench.Services
{
    /// <summary>가져오기 검토 화면의 한 줄. 사용자가 고친 뒤 업무 카드로 등록된다.</summary>
    public sealed class ImportCandidate
    {
        public bool Selected { get; set; } = true;
        public string SourcePath { get; set; } = "";
        public bool IsFolder { get; set; }
        public DateTime Date { get; set; }
        public string DateSource { get; set; } = "";
        public string Title { get; set; } = "";
        public string Customer { get; set; } = "";
        public string Equipment { get; set; } = "";
        public string TargetSystem { get; set; } = "";
        public WorkType Type { get; set; } = WorkType.Other;
        public int FileCount { get; set; }
        public bool AlreadyImported { get; set; }
    }

    /// <summary>
    /// 정리되지 않은 과거 자료 폴더를 훑어 완료 업무 초안을 만든다.
    /// 깊이 N의 폴더 하나 = 업무 1건, 그보다 위에 흩어진 문서 파일 하나 = 업무 1건.
    /// 날짜는 이름(20241021, 2024-10-21, 241021 …) → 메일 헤더 → 파일 수정일 순으로 추정한다.
    /// </summary>
    public static class ImportScanner
    {
        private static readonly HashSet<string> DocumentExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            ".doc", ".docx", ".xls", ".xlsx", ".xlsm", ".ppt", ".pptx", ".pdf", ".hwp", ".hwpx", ".txt", ".md", ".eml", ".msg", ".zip", ".7z"
        };

        private static readonly Regex FullDate = new Regex(@"(?<!\d)(20\d{2})[-._ 년]?\s?(0?[1-9]|1[0-2])[-._ 월]?\s?(0?[1-9]|[12]\d|3[01])(?!\d)", RegexOptions.Compiled);
        private static readonly Regex ShortDate = new Regex(@"(?<!\d)(\d{2})(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])(?!\d)", RegexOptions.Compiled);
        private static readonly Regex EncodedWord = new Regex(@"=\?([^?]+)\?([BbQq])\?([^?]*)\?=", RegexOptions.Compiled);

        private static readonly KeyValuePair<WorkType, string[]>[] TypeKeywords =
        {
            new KeyValuePair<WorkType, string[]>(WorkType.PreventiveCheck, new[] { "점검", "PM", "예방" }),
            new KeyValuePair<WorkType, string[]>(WorkType.ProgramChange, new[] { "수정", "패치", "배포", "업데이트", "버전", "patch", "update" }),
            new KeyValuePair<WorkType, string[]>(WorkType.HardwareFix, new[] { "교체", "카메라", "조명", "렌즈", "케이블", "HW" }),
            new KeyValuePair<WorkType, string[]>(WorkType.RemoteAnalysis, new[] { "분석", "로그", "원격", "log" }),
            new KeyValuePair<WorkType, string[]>(WorkType.Improvement, new[] { "개선", "검토" }),
            new KeyValuePair<WorkType, string[]>(WorkType.Inquiry, new[] { "문의", "질의", "회신" }),
            new KeyValuePair<WorkType, string[]>(WorkType.FieldVisit, new[] { "출동", "현장", "방문", "출장" })
        };

        public static List<ImportCandidate> Scan(string root, int depth, MasterData masters, IEnumerable<WorkItem> existing)
        {
            var imported = new HashSet<string>(existing.Select(i => i.ImportedFrom).Where(p => !string.IsNullOrEmpty(p)), StringComparer.OrdinalIgnoreCase);
            var result = new List<ImportCandidate>();
            Walk(root, root, 1, Math.Max(1, depth), masters, imported, result);
            return result.OrderBy(c => c.Date).ToList();
        }

        private static void Walk(string root, string dir, int level, int depth, MasterData masters, HashSet<string> imported, List<ImportCandidate> result)
        {
            foreach (var file in Directory.EnumerateFiles(dir))
            {
                var name = Path.GetFileName(file);
                if (DocumentExtensions.Contains(Path.GetExtension(file)) && !name.StartsWith("~$", StringComparison.Ordinal))
                {
                    result.Add(Build(root, file, false, masters, imported));
                }
            }

            foreach (var sub in Directory.EnumerateDirectories(dir))
            {
                if ((File.GetAttributes(sub) & (FileAttributes.Hidden | FileAttributes.System)) != 0)
                {
                    continue;
                }

                if (level < depth)
                {
                    Walk(root, sub, level + 1, depth, masters, imported, result);
                }
                else
                {
                    result.Add(Build(root, sub, true, masters, imported));
                }
            }
        }

        private static ImportCandidate Build(string root, string path, bool isFolder, MasterData masters, HashSet<string> imported)
        {
            var name = isFolder ? Path.GetFileName(path) : Path.GetFileNameWithoutExtension(path);
            var relative = path.Length > root.Length ? path.Substring(root.Length).TrimStart('\\', '/') : name;
            var files = isFolder ? SafeFiles(path) : new[] { path };

            var c = new ImportCandidate
            {
                SourcePath = path,
                IsFolder = isFolder,
                Title = CleanTitle(name),
                FileCount = files.Length,
                Customer = Match(masters.Customers, relative),
                Equipment = Match(masters.Equipments, relative),
                TargetSystem = Match(masters.Systems, relative),
                Type = GuessType(relative),
                AlreadyImported = imported.Contains(path)
            };
            c.Selected = !c.AlreadyImported;

            DateTime date;
            if (TryDateFromName(relative, out date))
            {
                c.Date = date;
                c.DateSource = "이름";
            }
            else if (!isFolder && string.Equals(Path.GetExtension(path), ".eml", StringComparison.OrdinalIgnoreCase) && TryReadEml(path, c))
            {
                c.DateSource = "메일";
            }
            else
            {
                c.Date = files.Length == 0 ? Directory.GetLastWriteTime(path) : files.Max(f => File.GetLastWriteTime(f));
                c.DateSource = "수정일";
            }

            return c;
        }

        /// <summary>경로 끝(가장 구체적인 이름)부터 날짜를 찾는다.</summary>
        public static bool TryDateFromName(string text, out DateTime date)
        {
            var segments = text.Split('\\', '/').Reverse();
            foreach (var segment in segments)
            {
                var m = FullDate.Match(segment);
                if (m.Success && TryMake(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, out date))
                {
                    return true;
                }

                m = ShortDate.Match(segment);
                if (m.Success && TryMake("20" + m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, out date))
                {
                    return true;
                }
            }

            date = default(DateTime);
            return false;
        }

        public static string CleanTitle(string name)
        {
            var text = FullDate.Replace(name, " ");
            text = ShortDate.Replace(text, " ");
            text = text.Replace('_', ' ');
            text = Regex.Replace(text, @"\[\s*\]|\(\s*\)", " ");
            text = Regex.Replace(text, @"\s+", " ").Trim(' ', '-', '.', ',');
            return text.Length == 0 ? name : text;
        }

        public static WorkType GuessType(string text)
        {
            foreach (var pair in TypeKeywords)
            {
                if (pair.Value.Any(k => text.IndexOf(k, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    return pair.Key;
                }
            }

            return WorkType.Other;
        }

        public static WorkItem ToWorkItem(ImportCandidate c, DateTime now)
        {
            var item = new WorkItem
            {
                Title = c.Title,
                Type = c.Type,
                Status = WorkStatus.Done,
                Customer = c.Customer,
                Equipment = c.Equipment,
                TargetSystem = c.TargetSystem,
                ReceivedAt = c.Date,
                CompletedAt = c.Date,
                Tags = "과거이관",
                ImportedFrom = c.SourcePath
            };
            item.Attachments.Add(new AttachmentRef
            {
                Name = Path.GetFileName(c.SourcePath),
                Path = c.SourcePath,
                Note = c.IsFolder ? "원본 폴더 (" + c.FileCount + "개 파일)" : "원본 파일"
            });
            item.Timeline.Add(new TimelineEntry
            {
                Start = now,
                Kind = TimelineKind.Note,
                Text = "과거 자료 가져오기 (날짜 근거: " + c.DateSource + ")"
            });
            return item;
        }

        public static string[] SafeFiles(string folder)
        {
            try
            {
                return Directory.GetFiles(folder, "*", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException)
            {
                return new string[0];
            }
        }

        private static string Match(IEnumerable<MasterEntry> entries, string text)
        {
            foreach (var entry in entries)
            {
                if (entry.Terms().Any(t => text.IndexOf(t, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    return entry.Name;
                }
            }

            return "";
        }

        private static bool TryMake(string y, string m, string d, out DateTime date)
        {
            date = default(DateTime);
            int year, month, day;
            if (!int.TryParse(y, out year) || !int.TryParse(m, out month) || !int.TryParse(d, out day))
            {
                return false;
            }

            if (year < 2000 || year > DateTime.Now.Year + 1 || day > DateTime.DaysInMonth(year, month))
            {
                return false;
            }

            date = new DateTime(year, month, day, 9, 0, 0);
            return true;
        }

        /// <summary>메일 헤더의 Subject·Date만 읽는다.</summary>
        private static bool TryReadEml(string path, ImportCandidate c)
        {
            var headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            string lastKey = null;
            foreach (var line in File.ReadLines(path, Encoding.UTF8).Take(400))
            {
                if (line.Length == 0)
                {
                    break;
                }

                if ((line[0] == ' ' || line[0] == '\t') && lastKey != null)
                {
                    headers[lastKey] += " " + line.Trim();
                    continue;
                }

                var colon = line.IndexOf(':');
                if (colon > 0)
                {
                    lastKey = line.Substring(0, colon).Trim();
                    headers[lastKey] = line.Substring(colon + 1).Trim();
                }
            }

            string subject;
            if (headers.TryGetValue("Subject", out subject) && subject.Length > 0)
            {
                c.Title = CleanTitle(DecodeHeader(subject));
            }

            string dateText;
            DateTime date;
            if (headers.TryGetValue("Date", out dateText) && TryParseMailDate(dateText, out date))
            {
                c.Date = date;
                return true;
            }

            return false;
        }

        public static string DecodeHeader(string value)
        {
            // 이어진 인코딩 단어 사이의 공백은 원문에 없는 글자다.
            value = Regex.Replace(value, @"\?=\s+=\?", "?==?");
            return EncodedWord.Replace(value, m =>
            {
                try
                {
                    var encoding = Encoding.GetEncoding(m.Groups[1].Value);
                    var payload = m.Groups[3].Value;
                    if (m.Groups[2].Value.Equals("B", StringComparison.OrdinalIgnoreCase))
                    {
                        return encoding.GetString(Convert.FromBase64String(payload));
                    }

                    var bytes = new List<byte>();
                    for (var i = 0; i < payload.Length; i++)
                    {
                        if (payload[i] == '=' && i + 2 < payload.Length)
                        {
                            bytes.Add(byte.Parse(payload.Substring(i + 1, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture));
                            i += 2;
                        }
                        else
                        {
                            bytes.Add((byte)(payload[i] == '_' ? ' ' : payload[i]));
                        }
                    }

                    return encoding.GetString(bytes.ToArray());
                }
                catch (Exception)
                {
                    return m.Value;
                }
            });
        }

        public static bool TryParseMailDate(string text, out DateTime date)
        {
            var cleaned = Regex.Replace(text, @"\s*\([^)]*\)\s*$", "");
            cleaned = Regex.Replace(cleaned, @"([+-]\d{2})(\d{2})$", "$1:$2");
            DateTimeOffset offset;
            var formats = new[] { "ddd, d MMM yyyy HH:mm:ss zzz", "d MMM yyyy HH:mm:ss zzz", "ddd, d MMM yyyy HH:mm zzz" };
            if (DateTimeOffset.TryParseExact(cleaned, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out offset)
                || DateTimeOffset.TryParse(cleaned, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out offset))
            {
                date = offset.LocalDateTime;
                return true;
            }

            date = default(DateTime);
            return false;
        }
    }
}
