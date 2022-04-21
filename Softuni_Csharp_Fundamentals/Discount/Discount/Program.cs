using System;

namespace FindAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double discountedPrice = 0;
            double discount = 0.65;


            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());                
                discountedPrice = num - (num * discount);
                Console.WriteLine($"{discountedPrice:F2}");
            }

            

        }
    }
}
/*
You need to calculate the discounted price for each item in your shopping cart. The discount is 65%, a real deal for you.
Input
On the first line, you will receive N - the number of the items in your shopping cart
On the next N lines you will each item's price
Output
On each line in the output print the discounted price of the item with two digits after the decimal point (Math rules for rounding apply)
*/
