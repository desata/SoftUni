using System;

namespace dollar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            double result = pounds * 1.310;

            Console.WriteLine($"{result:F3}");
        }
    }
}
