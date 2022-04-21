using System;

namespace BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            double volume = 0;
            double tempValue = double.MinValue;
            string model = string.Empty;
            string tempModel = string.Empty;
            double radius = 0;
            int height = 0;


            for (int i = 1; i <= n; i++)
            {

                model = Console.ReadLine();
                radius = double.Parse(Console.ReadLine());
                height = int.Parse(Console.ReadLine());

                volume = Math.PI * Math.Pow(2, radius) * height;

                if (tempValue < volume)
                {
                    tempValue = volume;
                    tempModel = model;

                }

            }

            Console.WriteLine(tempModel);


        }
    }
}
