using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TSWorkBench.Services
{
    /// <summary>템플릿의 {{이름}}을 값으로 바꾼다. 모르는 이름은 빈 문자열이 된다.</summary>
    public static class TemplateEngine
    {
        private static readonly Regex Placeholder = new Regex(@"\{\{\s*(\w+)\s*\}\}", RegexOptions.Compiled);

        public static string Render(string template, IDictionary<string, string> values)
        {
            return Placeholder.Replace(template, m =>
            {
                string value;
                return values.TryGetValue(m.Groups[1].Value, out value) ? value ?? "" : "";
            });
        }
    }
}
