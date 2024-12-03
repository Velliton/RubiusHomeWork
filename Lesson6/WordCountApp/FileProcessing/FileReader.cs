using System;
using System.IO;

namespace WordCounterApp.FileProcessing
{
    public static class FileReader
    {
      
        public static string ReadAllText(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            return File.ReadAllText(filePath);
        }

        public static IEnumerable<string> ReadLines(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            return File.ReadLines(filePath);
        }
    }
}
