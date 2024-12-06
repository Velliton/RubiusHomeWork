using System;
using WordCounterApp.FileProcessing;

namespace WordCounterApp
{
    class Program
    {
        static async Task Main()
        {
            string filePath = "..\\..\\..\\files\\War and Peace.txt";
        
            try
            {
                // Чтение всего файла
                int wordCountFullRead = await WordCounter.CountWordsByFullRead(filePath);
                Console.WriteLine($"Количество слов (чтение всего файла): {wordCountFullRead}");

                // Потоковая обработка файла
                int wordCountStreamRead = await WordCounter.CountWordsByStream(filePath);
                Console.WriteLine($"Количество слов (потоковая обработка): {wordCountStreamRead}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}