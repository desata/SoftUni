using System;

namespace _03.LongerLine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            IsCloser(x1, y1, x2, y2, x3, y3, x4, y4);
            IsLonger(x1, y1, x2, y2, x3, y3, x4, y4);
        }
        static void IsCloser(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double sqc1 = (Math.Abs(x1 * x1) + Math.Abs(y1 * y1));
            double sqc2 = (Math.Abs(x2 * x2) + Math.Abs(y2 * y2));
            if (sqc1 < sqc2)
            {

                Console.WriteLine($"({x1}, {y1})");

            }
            else
            {

                Console.WriteLine($"({x2}, {y2})");

            }
        }
        static void IsLonger(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
        {
            double a1 = Math.Abs(x1) + Math.Abs(x2);
            double b1 = Math.Abs(y1) + Math.Abs(y2);
            double c1 = Math.Sqrt(Math.Pow(a1, 2) + Math.Pow(b1, 2));

            double a2 = Math.Abs(x3) + Math.Abs(x4);
            double b2 = Math.Abs(y3) + Math.Abs(y4);
            double c2 = Math.Sqrt(Math.Pow(a2, 2) + Math.Pow(b2, 2));

            if (c1 > c2)
            {
                return;
            }

        }
    }
}
