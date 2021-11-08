using System.Text.RegularExpressions;

namespace ACT_Chat.FFXIV_ACT_Plugin.LogLineParser
{
    public static class LogLineParserUtil
    {
        public static Regex CreateRegex(string pattern)
        {
            return new Regex(pattern, RegexOptions.Compiled);
        }
    }
}