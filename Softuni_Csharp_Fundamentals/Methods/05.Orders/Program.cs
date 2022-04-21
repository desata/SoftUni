using System;

namespace _05.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that calculates and prints the total price of an order. The method should receive two parameters:
            //•	A string, representing a product -"coffee",  "water", "coke", "snacks"
            //•	An integer, representing the quantity of the product
            //The prices for a single item of each product are:
            //•	coffee – 1.50
            //•	water – 1.00
            //•	coke – 1.40
            //•	snacks – 2.00
            //Print the result rounded to the second decimal place.

            string product = Console.ReadLine();
            int qty = int.Parse(Console.ReadLine());
            
            GetOrder(product,qty);
                    }
        static void GetOrder(string product, int qty) 
        {
            double result = 0;
            double price = 0;
            if (product == "coffee")
            {
                price = 1.5;
            }
            if (product == "water")
            {
                price = 1.0;
            }
            if (product == "coke")
            {
                price = 1.4;
            }
            if (product == "snacks")
            {
                price = 2.0;
            }
            result = price * qty;
            Console.WriteLine($"{result:f2}");
        }
    }
}
