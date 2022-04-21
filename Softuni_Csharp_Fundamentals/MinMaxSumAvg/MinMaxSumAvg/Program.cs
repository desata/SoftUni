using System;

namespace FindAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double sum = 0;
            double average = 0;
            double min = double.MaxValue;
            double max = double.MinValue;


            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                sum = sum + num;
                if (min > num)
                {
                    min = num;
                }
                if (max < num)
                {
                    max = num;
                }
            }
            average = sum / n;
            Console.WriteLine($"min={min:F2}");
            Console.WriteLine($"max={max:F2}");
            Console.WriteLine($"sum={sum:F2}");
            Console.WriteLine($"avg={average:F2}");
        }
    }
}
