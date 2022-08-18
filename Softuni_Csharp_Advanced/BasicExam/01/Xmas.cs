using System;

namespace _01_
{
    internal class Xmas
    {
        static void Main(string[] args)
        {
            int rollPaper = int.Parse(Console.ReadLine());
            int rollFabric = int.Parse(Console.ReadLine());
            double glue = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            
            double paperPrice = 5.80;
            double fabricPrice = 7.20;
            double gluePrice = 1.20;

            double totalPrice = (rollPaper * paperPrice) + (rollFabric * fabricPrice) + (glue * gluePrice);
            double finalPrice = totalPrice - (totalPrice * discount / 100);

            Console.WriteLine($"{finalPrice:F3}");

        }
    }
}
