using System;
using System.Collections.Generic;

namespace _04.ListOfProducts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read a number n and n lines of products.
            //Print a numbered list of all the products ordered by name.

            int productLines = int.Parse(Console.ReadLine());
            List<string> productName = new List<string>();

            for (int i = 0; i < productLines; i++)
            {
                productName.Add(Console.ReadLine());
            }
            productName.Sort();

            for (int i = 0; i < productLines; i++)
            {
                Console.WriteLine($"{i+1}.{productName[i]}");
            }
            
        }
    }
}
