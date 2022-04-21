using System;

namespace PoundstoDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that converts British pounds to US dollars formatted to the 3rd decimal point.
            // 1 British Pound = 1.31 Dollars
            float pounds = float.Parse(Console.ReadLine());
            float dollars = (pounds * 1.31f);

            if (pounds >= 0)
            {
                Console.WriteLine($"{dollars:F3}");
            }
            else
            {
                Console.WriteLine("0.000");
            }
            
        }
    }
}
