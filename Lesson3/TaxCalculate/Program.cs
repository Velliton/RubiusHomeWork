using System;

namespace TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal income = GetIncomeFromUser();
            decimal tax = CalculateTax(income);
            Console.WriteLine($"Сумма налогов к уплате: {tax} рублей.");
        }

        static decimal GetIncomeFromUser()
        {
            decimal income;
            while (true)
            {
                Console.Write("Введите сумму дохода: ");
                if (decimal.TryParse(Console.ReadLine(), out income))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите числовое значение.");
                }
            }
            return income;
        }

        static decimal CalculateTax(decimal income)
        {
            decimal taxRate = 0.13m; 
            decimal tax = income * taxRate;
            return Math.Round(tax, 2); 
        }
    }
}