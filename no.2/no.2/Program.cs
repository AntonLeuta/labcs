using System;

namespace ConstColculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: Program.exe <epsilon>");
                return;
            }

            // Получаем значение эпсилон из аргумента командной строки
            double epsilon = double.Parse(args[0]);


            Console.WriteLine($"e: {CalculateE(epsilon)}");
            Console.WriteLine($"π: {CalculatePi(epsilon)}");
            Console.WriteLine($"ln 2: {CalculateLn2(epsilon)}");
            Console.WriteLine($"2: {CalculateTwo(epsilon)}");
            Console.WriteLine($"γ: {CalculateGamma(epsilon)}");
        }

        static double CalculateE(double epsilon)
        {
            // Ряд: e = 1 + 1/1! + 1/2! + 1/3! + ...
            double result = 1.0;
            double term = 1.0;
            int n = 1;

            while (Math.Abs(term) > epsilon)
            {
                term /= n;
                result += term;
                n++;
            }

            return result;
        }

        // Вычисление значения числа π с использованием ряда Мадхавы
        static double CalculatePi(double epsilon)
        {
            // Ряд Мадхавы: π = 4 * (1 - 1/3 + 1/5 - 1/7 + ...)
            double result = 0.0;
            double term = 1.0;
            int n = 0;

            while (Math.Abs(term) > epsilon)
            {
                term = (n % 2 == 0) ? 1.0 / (2 * n + 1) : -1.0 / (2 * n + 1);
                result += 4 * term;
                n++;
            }

            return result;
        }

        // Вычисление значения натурального логарифма 2
        static double CalculateLn2(double epsilon)
        {
            // Ряд: ln(2) = 1 - 1/2 + 1/3 - 1/4 + ...
            double result = 0.0;
            double term = 1.0;
            int n = 1;

            while (Math.Abs(term) > epsilon)
            {
                term = (n % 2 == 0) ? -1.0 / n : 1.0 / n;
                result += term;
                n++;
            }

            return result;
        }

        // Вычисление значения числа 2 с использованием ряда
        static double CalculateTwo(double epsilon)
        {
            // Ряд: 2 = 1 + 1/2 + 1/4 + 1/8 + ...
            double result = 0.0;
            double term = 1.0;
            int n = 0;

            while (Math.Abs(term) > epsilon)
            {
                term = 1.0 / Math.Pow(2, n);
                result += term;
                n++;
            }

            return result;
        }

        // Вычисление значения по��тоянной Эйлера γ (гамма)
        static double CalculateGamma(double epsilon)
        {
            // Ряд: γ = 1 - 1/2 + 1/3 - 1/4 + ...
            double result = 0.0;
            double term = 1.0;
            int n = 1;

            while (Math.Abs(term) > epsilon)
            {
                term = (n % 2 == 0) ? -1.0 / n : 1.0 / n;
                result += term;
                n++;
            }

            return result;
        }
    }
}
