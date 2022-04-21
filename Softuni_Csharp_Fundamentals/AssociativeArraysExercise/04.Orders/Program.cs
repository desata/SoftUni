using System;
using System.Linq;
using System.Collections.Generic;


namespace _04.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string,List<double>> productList = new Dictionary<string,List<double>>();

            while (input[0] != "buy")
            {
                string item = input[0];
                double price = double.Parse(input[1]);
                int quantity = int.Parse(input[2]);


                if (productList.ContainsKey(item))
                {

                    productList[item][0] = price;
                    productList[item][1] += quantity;

                }
                else
                {
                    productList.Add(item, new List<double> {price, quantity});
                   
                }



                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var product in productList)
            {
                double totalprise = product.Value[0] * product.Value[1];
                Console.WriteLine($"{product.Key} -> {totalprise:F2}");
            }
        }
    }
}
