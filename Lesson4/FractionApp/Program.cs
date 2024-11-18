using System;

public class Fraction
{
    private int numerator;   // Числитель
    private int denominator; // Знаменатель

    public int Numerator
    {
        get => numerator;
        set => numerator = value;
    }

    public int Denominator
    {
        get => denominator;
        set
        {
            if (value == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");
            denominator = value;
        }
    }

    // Конструктор
    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        Simplify();
    }

    // Упрощение дроби
    private void Simplify()
    {
        int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
        Numerator /= gcd;
        Denominator /= gcd;
        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }


    private static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

  
    public static Fraction operator +(Fraction a, Fraction b) =>
        new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    public static Fraction operator -(Fraction a, Fraction b) =>
        new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);

    public static Fraction operator *(Fraction a, Fraction b) =>
        new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Невозможно разделить на ноль.");
        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }


    public float ToFloat() => (float)Numerator / Denominator;
    public double ToDouble() => (double)Numerator / Denominator;

    
    public override string ToString() => $"{Numerator}/{Denominator}";

   
    public static Fraction Parse(string input)
    {
        var parts = input.Split('/');
        if (parts.Length != 2)
            throw new FormatException("Введите дробь в формате 'числитель/знаменатель'.");

        int numerator = int.Parse(parts[0]);
        int denominator = int.Parse(parts[1]);

        return new Fraction(numerator, denominator);
    }
}


class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите первую дробь (в формате числитель/знаменатель): ");
            var frac1 = Fraction.Parse(Console.ReadLine());

            Console.Write("Введите вторую дробь (в формате числитель/знаменатель): ");
            var frac2 = Fraction.Parse(Console.ReadLine());

            Console.WriteLine($"Сумма: {frac1} + {frac2} = {frac1 + frac2}");
            Console.WriteLine($"Разность: {frac1} - {frac2} = {frac1 - frac2}");
            Console.WriteLine($"Умножение: {frac1} * {frac2} = {frac1 * frac2}");
            Console.WriteLine($"Деление: {frac1} / {frac2} = {frac1 / frac2}");
            Console.WriteLine($"Дробь {frac1} в формате float: {frac1.ToFloat()}");
            Console.WriteLine($"Дробь {frac1} в формате double: {frac1.ToDouble()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
