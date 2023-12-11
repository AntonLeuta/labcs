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
            Console.WriteLine("Введите последовательность символов, разделенных пробелами:");
            input = Console.ReadLine();
        }

        string[] symbols = input.Split(' ');

        int sum = 0;
        int count = 0;

        foreach (string symbol in symbols)
        {
            int code;
            if (Int32.TryParse(symbol, out code))
            {
                sum += code;
                count++;
            }
        }

        if (count > 0)
        {
            double average = (double)sum / count;
            Console.WriteLine("Среднее арифметическое: " + average);
        }
        else
        {
            Console.WriteLine("Не найдено цифр для вычисления среднего арифметического");
        }
    }
}