using System;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int tank = 255;
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            int tempSum = sum;

            for (int i = 1; i <= n; i++)
            {
                int litters = int.Parse(Console.ReadLine());
                tempSum += litters;

                if (tempSum > tank)
                {
                    tempSum -= litters;
                    Console.WriteLine("Insufficient capacity!");
                }

            }
            Console.WriteLine(tempSum);
        }
    }
}
