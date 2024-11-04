using System;

class Program
{
    static void Main()
    {
        CheckLeapYear();
        CalculateExpenses();
    }

    static void CheckLeapYear()
    {
        Console.WriteLine("Введите номер года:");
        int year = int.Parse(Console.ReadLine());

        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }

        Console.WriteLine(); // Пустая строка для удобства чтения
    }

    static void CalculateExpenses()
    {
        Console.WriteLine("Введите количество категорий расходов:");
        int count = int.Parse(Console.ReadLine());

        decimal totalExpenses = 0;

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"Введите сумму для расхода #{i}:");
            decimal expense = decimal.Parse(Console.ReadLine());
            totalExpenses += expense;
        }

        Console.WriteLine($"Общая сумма расходов: {totalExpenses} руб.");
    }
}