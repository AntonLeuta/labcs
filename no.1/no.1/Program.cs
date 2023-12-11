using System;

public class Program
{
    public static double[] CardanoMethod(double a, double b, double c, double d)
    {
        double p = (3 * a * c - Math.Pow(b, 2)) / (3 * Math.Pow(a, 2));
        double q = (2 * Math.Pow(b, 3) - 9 * a * b * c + 27 * Math.Pow(a, 2) * d) / (27 * Math.Pow(a, 3));
        double delta = Math.Pow(p / 3, 3) + Math.Pow(q / 2, 2);
        double s = -q / 2 + Math.Sqrt(delta);
        double t = -q / 2 - Math.Sqrt(delta);

        double u = Math.Pow(Math.Abs(s), 0.3333333333333333);
        double v = Math.Pow(Math.Abs(t), 0.3333333333333333);

        double[] roots = new double[3];
        roots[0] = u + v - b / (3 * a);
        roots[1] = -(u + v) / 2 - b / (3 * a) + (u - v) * Math.Sqrt(3) / 2;
        roots[2] = -(u + v) / 2 - b / (3 * a) - (u - v) * Math.Sqrt(3) / 2;

        return roots;
    }

    public static double[] CubicEquation(double a, double b, double c, double d)
    {
        double f = ((3 * c / a) - (Math.Pow(b, 2) / Math.Pow(a, 2))) / 3;
        double g = ((2 * Math.Pow(b, 3) / Math.Pow(a, 3)) - (9 * b * c / Math.Pow(a, 2)) + (27 * d / a)) / 27;
        double h = (Math.Pow(g, 2) / 4) + (Math.Pow(f, 3) / 27);

        double[] roots = new double[3];
        if (h > 0)
        {
            double r = -g / 2 + Math.Sqrt(h);
            double s = Math.Pow(Math.Abs(r), 1 / 3.0);
            double t = -g / 2 - Math.Sqrt(h);
            double u = Math.Pow(Math.Abs(t), 1 / 3.0);

            roots[0] = (s + u) - (b / (3 * a));
            roots[1] = -(s + u) / 2 - (b / (3 * a)) + ((s - u) * Math.Sqrt(3) / 2);
            roots[2] = -(s + u) / 2 - (b / (3 * a)) - ((s - u) * Math.Sqrt(3) / 2);
        }
        else
        {
            double i = Math.Sqrt((Math.Pow(g, 2) / 4) - h);
            double j = Math.Pow(Math.Abs(i), 1 / 3.0);
            double k = Math.Acos(-g / (2 * i));
            double l = -j;
            double m = Math.Cos(k / 3);
            double n = Math.Sqrt(3) * Math.Sin(k / 3);
            double p = (b / (3 * a)) * -1;

            roots[0] = ((2 * j) * Math.Cos(k / 3) - (b / (3 * a)));
            roots[1] = (l * (m + n) + p);
            roots[2] = (l * (m - n) + p);
        }

        return roots;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the coefficients of the cubic equation (a):");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the coefficients of the cubic equation (b):");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the coefficients of the cubic equation (c):");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the coefficients of the cubic equation ( d):");
        double d = double.Parse(Console.ReadLine());

        double[] rootsCardano = CardanoMethod(a, b, c, d);

        Console.WriteLine("The roots of the cubic equation using the Cardano formula:");
        foreach (double root in rootsCardano)
        {
            Console.WriteLine(root);
        }

        double[] rootsCubic = CubicEquation(a, b, c, d);

        Console.WriteLine("\nThe roots of the cubic equation without using the Cardano formula:");
        foreach (double root in rootsCubic)
        {
            Console.WriteLine(root);
        }
    }
}
