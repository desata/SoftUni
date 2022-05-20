using System;
using System.Collections.Generic;

namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            string[] input = Console.ReadLine().Split(", ");
            SortedDictionary<string, Dictionary<string, double>> foodShop = new SortedDictionary<string, Dictionary<string, double>>();

            while (input[0] != "Revision")
            {
                string shops = input[0];
                string product = input[1];
                double price = double.Parse(input[2]);

                if (!foodShop.ContainsKey(shops))
                {
                    foodShop[shops] = new Dictionary<string,double>();

                }
                foodShop[shops][product] = price;


                input = Console.ReadLine().Split(", ");
            }

            foreach (var shops in foodShop)
            {
                var product = shops.Value;

                Console.WriteLine($"{shops.Key}->");

                foreach (var item in product)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
            //{shop}->
            //Product: {product}, Price: {price:D1}

        }
    }
}
