using System;
using System.Numerics;

namespace sumOfReal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program to enter n numbers and calculate and print their exact sum (without rounding).
            int n = int.Parse(Console.ReadLine());
            decimal num = 0;
            decimal sum = 0;

            for (int i = 1; i <= n; i++)
            {
                num = decimal.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
