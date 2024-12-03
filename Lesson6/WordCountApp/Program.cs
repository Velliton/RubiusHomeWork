using System;
using WordCounterApp.FileProcessing;

namespace WordCounterApp
{
    class Program
    {
        static void Main()
        {
            string filePath = "D:\\Курс Rubius\\RubiusHomeWork\\Lesson6\\WordCountApp\\files\\War and Peace.txt";

            try
            {
                // Чтение всего файла
                int wordCountFullRead = WordCounter.CountWordsByFullRead(filePath);
                Console.WriteLine($"Количество слов (чтение всего файла): {wordCountFullRead}");

                // Потоковая обработка файла
                int wordCountStreamRead = WordCounter.CountWordsByStream(filePath);
                Console.WriteLine($"Количество слов (потоковая обработка): {wordCountStreamRead}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}