using System;

namespace GodzillaVSKong
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            double statists = double.Parse(Console.ReadLine());
            double dress = double.Parse(Console.ReadLine());
            double dressTotalPrice = dress * statists;
            double decor = budget * 0.1;
            double discount = 0.0;
            double total = 0.0;

            if (statists >= 150)
            {
                discount = dressTotalPrice * 0.1;
                dressTotalPrice = dressTotalPrice - discount;
                total = dressTotalPrice + decor;
                double left = budget - total;
                if (left >= 0)
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {left:F2} leva left.");
                }
                if (left < 0)
                {
                    double more = total - budget;
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {more:f2} leva more.");
                }

            }
            else
            {
                total = dressTotalPrice + decor;
                double left = budget - total;
                if (left >= 0)
                {
                    Console.WriteLine("Action!");
                    Console.WriteLine($"Wingard starts filming with {left:F2} leva left.");
                }
                if (left < 0)
                {
                    double more = total - budget;
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine($"Wingard needs {more:f2} leva more.");
                }
            }


        }
    }
}
