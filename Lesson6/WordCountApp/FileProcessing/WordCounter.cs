using WordCounterApp.Utils;

namespace WordCounterApp.FileProcessing
{
    public static class WordCounter
    {
        
        public static async Task <int> CountWordsByFullRead(string filePath)
        {
            string content = await FileReader.ReadAllTextAsync(filePath);
            return RegexUtils.CountWords(content);
        }

       
        public static async Task <int> CountWordsByStream(string filePath)
        {
            int wordCount = 0;
           await foreach (var line in FileReader.ReadLinesAsync(filePath))
            {
                wordCount += RegexUtils.CountWords(line);
            }
            return wordCount;
        }
    }
}