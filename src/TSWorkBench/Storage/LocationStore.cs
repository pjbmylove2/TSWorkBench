using System;
using System.IO;

namespace TSWorkBench.Storage
{
    /// <summary>이 PC에서 마지막으로 쓴 데이터 폴더 경로만 기억한다 (%AppData%\TSWorkBench\location.json).</summary>
    public static class LocationStore
    {
        private static string FilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TSWorkBench", "location.json");

        public static string Load()
        {
            try
            {
                return File.Exists(FilePath) ? JsonFile.Read<Location>(FilePath)?.DataFolder : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void Save(string dataFolder)
        {
            JsonFile.WriteAtomic(FilePath, new Location { DataFolder = dataFolder });
        }

        private sealed class Location
        {
            public string DataFolder { get; set; }
        }
    }
}
