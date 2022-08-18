using System;

namespace _04_
{
    internal class Stavri
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalQty = 0;
            double totaldegree = 0;
            double averageDegrees = 0;

            for (int i = 0; i < days; i++)
            {
                double qty = double.Parse(Console.ReadLine());
                double degree = double.Parse(Console.ReadLine());

                totaldegree += qty*degree;
                totalQty += qty;
            }

            averageDegrees = totaldegree/ totalQty;

            Console.WriteLine($"Liter: {totalQty:F2}");
            Console.WriteLine($"Degrees: {averageDegrees:F2}");

            if (averageDegrees < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (averageDegrees >= 38 && averageDegrees < 42)
            {
                Console.WriteLine("Super!");
            }
            else if (averageDegrees >= 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }

        }
    }
}
