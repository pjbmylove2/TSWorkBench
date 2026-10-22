using System;
using System.IO;
using System.Text;

namespace TSWorkBench
{
    /// <summary>오류를 %AppData%\TSWorkBench\error.log에 남긴다. 기록 자체가 실패해도 프로그램은 계속 돈다.</summary>
    public static class ErrorLog
    {
        private const long MaxBytes = 1024 * 1024;
        private static readonly object Sync = new object();

        public static string FilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TSWorkBench", "error.log");

        public static void Write(string message, Exception ex = null)
        {
            try
            {
                lock (Sync)
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FilePath));
                    var info = new FileInfo(FilePath);
                    if (info.Exists && info.Length > MaxBytes)
                    {
                        // 1MB를 넘으면 한 세대만 남기고 새로 시작한다.
                        File.Copy(FilePath, FilePath + ".old", true);
                        File.Delete(FilePath);
                    }

                    File.AppendAllText(FilePath,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + message + (ex != null ? Environment.NewLine + ex : "") + Environment.NewLine,
                        Encoding.UTF8);
                }
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }
    }
}
