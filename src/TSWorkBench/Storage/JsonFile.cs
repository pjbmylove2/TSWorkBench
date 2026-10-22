using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TSWorkBench.Storage
{
    /// <summary>JSON 읽기·쓰기. 쓰기는 임시 파일에 먼저 쓰고 바꿔치기해서, 저장 도중 꺼져도 원본이 깨지지 않는다.</summary>
    public static class JsonFile
    {
        private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);

        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            DateFormatString = "yyyy-MM-dd'T'HH:mm:ss",
            ObjectCreationHandling = ObjectCreationHandling.Replace,
            Converters = { new StringEnumConverter() }
        };

        public static string Serialize(object value)
        {
            return JsonConvert.SerializeObject(value, Settings);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, Settings);
        }

        public static T Read<T>(string path)
        {
            return Deserialize<T>(File.ReadAllText(path, Encoding.UTF8));
        }

        public static T Clone<T>(T value)
        {
            return Deserialize<T>(Serialize(value));
        }

        /// <summary>path에 원자적으로 저장하고 직전 내용은 path.bak으로 남긴다.</summary>
        public static void WriteAtomic(string path, object value)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            var tmp = path + ".tmp";
            File.WriteAllText(tmp, Serialize(value), Utf8NoBom);

            if (!File.Exists(path))
            {
                File.Move(tmp, path);
                return;
            }

            try
            {
                File.Replace(tmp, path, path + ".bak");
            }
            catch (IOException)
            {
                // 일부 네트워크·동기화 폴더는 File.Replace를 지원하지 않는다.
                File.Copy(path, path + ".bak", true);
                File.Copy(tmp, path, true);
                File.Delete(tmp);
            }
        }
    }
}
