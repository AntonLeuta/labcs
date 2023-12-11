using System;

class Program
{
    static void Main(string[] args)
    {
        bool readFromConsole = true;
        string input = "";

        // Проверяем флаги командной строки
        if (args.Length > 0)
        {
            if (args[0] == "-f")
            {
                readFromConsole = false;
                if (args.Length < 2)
                {
                    Console.WriteLine("Не указан путь к файлу");
                    return;
                }
                try
                {
                    input = System.IO.File.ReadAllText(args[1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
                    return;
                }
            }
        }

        if (readFromConsole)
        {
            Console.WriteLine("Введите числа, разделенные пробелами:");
            input = Console.ReadLine();
        }

        string[] numbers = input.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        double product = 1;
        double sumOfInverses = 0;
        int count = 0;

        foreach (string number in numbers)
        {
            double value;
            if (Double.TryParse(number, out value))
            {
                if (value <= 0)
                {
                    Console.WriteLine("Ошибка: недопустимое значение числа");
                    return;
                }
                product *= value;
                sumOfInverses += 1 / value;
                count++;
            }
        }

        if (count > 0)
        {
            double geometricMean = Math.Pow(product, 1.0 / count);
            double harmonicMean = count / sumOfInverses;

            Console.WriteLine("Среднее геометрическое: " + geometricMean);
            Console.WriteLine("Среднее гармоническое: " + harmonicMean);
        }
        else
        {
            Console.WriteLine("Не найдено чисел для вычисления среднего геометрического и среднего гармонического");
        }
    }
}