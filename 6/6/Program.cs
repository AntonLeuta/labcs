public class Program
{
    public static double FindRoot(Func<double, double> equation, double lowerBound, double upperBound, double epsilon)
    {
        if (equation(lowerBound) * equation(upperBound) >= 0)
        {
            throw new ArgumentException("The equation should have opposite signs at the lower and upper bounds");
        }

        double root = 0;

        while (Math.Abs(upperBound - lowerBound) > epsilon)
        {
            root = (lowerBound + upperBound) / 2;

            if (equation(root) * equation(lowerBound) < 0)
            {
                upperBound = root;
            }

            else
            {
                lowerBound = root;
            }
        }

        return root;
    }

    public static void Main(string[] args)
    {
        // Пример использования функции для уравнения x^2 - 4 = 0
        // Находим корень на интервале от 1 до 3 с точностью до 0.0001
        double result = FindRoot(x => x * x - 4, 1, 3, 0.0001);
        Console.WriteLine(result);
    }
}