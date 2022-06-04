
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads one line of double prices separated by ", ". Print the prices with added VAT for all of them. Format them to 2 signs after the decimal point. The order of the prices must be the same. VAT is equal to 20 % of the price.

            double[] prices = Console.ReadLine().Split(", ").Select(p => double.Parse(p)).Select(n => n * 1.2).ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
