using System;
using ZAGS.Services;

namespace ZAGS
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new RegistryService();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить запись");
                Console.WriteLine("2. Показать все записи (отсортировано по дате)");
                Console.WriteLine("3. Получить записи по дате");
                Console.WriteLine("4. Выход");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddRecord(service);
                        break;
                    case "2":
                        ShowAllRecords(service);
                        break;
                    case "3":
                        GetRecordsByDate(service);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор, попробуйте снова.");
                        break;
                }
            }
        }

        static void AddRecord(RegistryService service)
        {
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();

            Console.Write("Введите дату регистрации (гггг-мм-дд): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime registrationDate))
            {
                service.AddRecord(surname, registrationDate);
            }
            else
            {
                Console.WriteLine("Некорректный формат даты!");
            }
        }

        static void ShowAllRecords(RegistryService service)
        {
            var records = service.GetAllRecordsSorted();

            Console.WriteLine("\nВсе записи (отсортированы по дате):");
            foreach (var record in records)
            {
                Console.WriteLine(record);
            }
        }

        static void GetRecordsByDate(RegistryService service)
        {
            Console.Write("Введите дату регистрации (гггг-мм-дд): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                var records = service.GetRecordsByDate(date);

                if (records.Any())
                {
                    Console.WriteLine("\nЗаписи на указанную дату:");
                    foreach (var record in records)
                    {
                        Console.WriteLine(record);
                    }
                }
                else
                {
                    Console.WriteLine("Записей на указанную дату не найдено.");
                }
            }
            else
            {
                Console.WriteLine("Некорректный формат даты!");
            }
        }
    }
}