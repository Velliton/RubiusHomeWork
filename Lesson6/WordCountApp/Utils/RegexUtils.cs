using System.Text.RegularExpressions;

namespace WordCounterApp.Utils
{
    public static class RegexUtils
    {
       
        public static int CountWords(string text)
        {
            var matches = Regex.Matches(text, @"\b\w+\b");
            return matches.Count;
        }
    }
}