using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();
            try
            {
                people = GetPeople();
                products = GetProducts();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] data = line.Split();
                string personName = data[0];
                string productName = data[1];
                var person = people[personName];
                var product = products[productName];

                try
                {
                    person.AddProduct(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var person in people.Values)
            {
                Console.WriteLine(person);
            }
        }

        private static Dictionary<string, Product> GetProducts()
        {
            var result = new Dictionary<string, Product>();
            var data = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var product in data)
            {
                var split = product.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var name = split[0];
                var cost = decimal.Parse(split[1]);
                result.Add(name, new Product(name, cost));
            }
            return result;
        }

        private static Dictionary<string, Person> GetPeople()
        {
            var result = new Dictionary<string, Person>();
            var data = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            foreach (var person in data)
            {
                var split = person.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var name = split[0];
                var money = decimal.Parse(split[1]);
                result.Add(name, new Person(name, money));
            }
            return result;
        }
    }
}
