using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WordCounterApp.FileProcessing
{
    public static class FileReader
    {

        // Асинхронное чтение всего текста из файла
        public static async Task<string> ReadAllTextAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            return await File.ReadAllTextAsync(filePath);
        }

        public static async IAsyncEnumerable<string> ReadLinesAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Файл не найден: {filePath}");

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
