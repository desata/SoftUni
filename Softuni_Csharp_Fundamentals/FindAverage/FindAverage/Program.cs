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
            Console.WriteLine($"min = {min:F2}");
            Console.WriteLine($"max = {max:F2}");
            Console.WriteLine($"sum = {sum:F2}");
            Console.WriteLine($"avg = {average:F2}");
        }
    }
}
/*
Find Average
You need to calculate the average of a collection of values. Every value will be valid number. The average must be printed with two digits after the decimal point.
Input
On the first line, you will receive N - the number of the values you must read
On the next N lines you will receive numbers.
Output
On the only line of output, print the average with two digits after the decimal point.
*/
