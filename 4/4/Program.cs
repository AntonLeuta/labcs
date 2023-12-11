using System;

public class DecimalToBaseKConverter
{
    public static string Convert(decimal number, int baseK)
    {
        if (baseK < 2 || baseK > 36)
        {
            throw new ArgumentException("Base must be between 2 and 36");
        }

        string result = string.Empty;
        decimal integerPart = Math.Truncate(number);
        decimal fractionalPart = number - integerPart;

        // Convert the integer part to base-K
        while (integerPart > 0)
        {
            int remainder = (int)(integerPart % baseK);
            result = GetCharFromDigit(remainder) + result;
            integerPart /= baseK;
        }

        // Add the fraction separator
        if (fractionalPart > 0)
        {
            result += ".";
        }

        // Convert the fractional part to base-K
        const int maxFractionDigits = 100; // Maximum number of digits to show for the fractional part
        int fractionDigitsCount = 0;

        while (fractionalPart > 0 && fractionDigitsCount < maxFractionDigits)
        {
            fractionalPart *= baseK;
            int digit = (int)Math.Truncate(fractionalPart);
            result += GetCharFromDigit(digit);
            fractionalPart -= digit;
            fractionDigitsCount++;
        }

        // Check if the fractional part is repeating
        if (fractionalPart > 0)
        {
            string repeatingDigits = FindRepeatingDigits(fractionalPart * baseK, baseK);
            result += "(" + repeatingDigits + ")";
        }

        return result;
    }

    private static string GetCharFromDigit(int digit)
    {
        if (digit >= 0 && digit <= 9)
        {
            return digit.ToString();
        }
        else if (digit >= 10 && digit <= 35)
        {
            return ((char)(digit + 55)).ToString();
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(digit), "Digit must be between 0 and 35");
        }
    }

    private static string FindRepeatingDigits(decimal number, int baseK)
    {
        string digits = string.Empty;
        decimal originalNumber = number;

        while (true)
        {
            int digit = (int)Math.Truncate(number);
            digits += GetCharFromDigit(digit);
            number -= digit;

            if (number == originalNumber)
            {
                break;
            }

            number *= baseK;
        }

        return digits;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        decimal number = 1.0m / 3.0m;
        int baseK = 7;

        string result = DecimalToBaseKConverter.Convert(number, baseK);
        Console.WriteLine($"Number {number} in base-{baseK} is: {result}");
    }
}