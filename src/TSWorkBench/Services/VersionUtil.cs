using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace TSWorkBench.Services
{
    /// <summary>무엇을 바꿨는지에 따라 버전의 어느 자리를 올릴지.</summary>
    public enum VersionStep
    {
        /// <summary>버그 수정: 1.0.0 → 1.0.1</summary>
        Patch,

        /// <summary>기능 추가: 1.0.0 → 1.1.0</summary>
        Minor,

        /// <summary>큰 변경(설정·통신 형식이 바뀜): 1.0.0 → 2.0.0</summary>
        Major
    }

    /// <summary>버전 번호 "주.부.수정" (예: 1.2.3). 앞의 v는 있어도 된다.</summary>
    public static class VersionUtil
    {
        public const string BaseVersion = "1.0.0";

        public static bool TryParse(string text, out Version version)
        {
            version = null;
            var t = (text ?? "").Trim();
            if (t.StartsWith("v", StringComparison.OrdinalIgnoreCase))
            {
                t = t.Substring(1);
            }

            var parts = t.Split('.');
            if (parts.Length != 3)
            {
                return false;
            }

            int major, minor, patch;
            if (!int.TryParse(parts[0], NumberStyles.None, CultureInfo.InvariantCulture, out major)
                || !int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out minor)
                || !int.TryParse(parts[2], NumberStyles.None, CultureInfo.InvariantCulture, out patch))
            {
                return false;
            }

            version = new Version(major, minor, patch);
            return true;
        }

        public static bool IsValid(string text)
        {
            Version v;
            return TryParse(text, out v);
        }

        public static string Normalize(string text)
        {
            Version v;
            return TryParse(text, out v) ? v.ToString(3) : (text ?? "").Trim();
        }

        /// <summary>두 버전 비교. 읽을 수 없는 버전은 가장 낮게 친다.</summary>
        public static int Compare(string a, string b)
        {
            Version va, vb;
            var okA = TryParse(a, out va);
            var okB = TryParse(b, out vb);
            if (okA && okB)
            {
                return va.CompareTo(vb);
            }

            return okA.CompareTo(okB);
        }

        /// <summary>가장 높은 버전. 없으면 null.</summary>
        public static string Latest(IEnumerable<string> versions)
        {
            string best = null;
            foreach (var v in versions.Where(IsValid))
            {
                if (best == null || Compare(v, best) > 0)
                {
                    best = Normalize(v);
                }
            }

            return best;
        }

        public static string Next(string current, VersionStep step)
        {
            Version v;
            if (!TryParse(current, out v))
            {
                return BaseVersion;
            }

            switch (step)
            {
                case VersionStep.Major: return (v.Major + 1) + ".0.0";
                case VersionStep.Minor: return v.Major + "." + (v.Minor + 1) + ".0";
                default: return v.Major + "." + v.Minor + "." + (v.Build + 1);
            }
        }
    }
}
