using WordCounterApp.Utils;

namespace WordCounterApp.FileProcessing
{
    public static class WordCounter
    {
        
        public static int CountWordsByFullRead(string filePath)
        {
            string content = FileReader.ReadAllText(filePath);
            return RegexUtils.CountWords(content);
        }

       
        public static int CountWordsByStream(string filePath)
        {
            int wordCount = 0;
            foreach (var line in FileReader.ReadLines(filePath))
            {
                wordCount += RegexUtils.CountWords(line);
            }
            return wordCount;
        }
    }
}