using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, Person> peopleKVP = new Dictionary<string, Person>();
            Dictionary<string, Product> productKVP = new Dictionary<string, Product>();

            string[] people = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            string[] products = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);
            try
            { 
                for (int i = 0; i < people.Length; i += 2)
                {
                    string name = people[i];
                    decimal money = decimal.Parse(people[i + 1]);

                    Person person = new Person(name, money);

                    peopleKVP.Add(name, person);

                }

                for (int i = 0; i < products.Length; i += 2)
                {
                    string name = products[i];
                    decimal cost = decimal.Parse(products[i + 1]);

                    Product product = new Product(name, cost);

                    productKVP.Add(name, product);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] info = command.Split();

                string personName = info[0];
                string productName = info[1];

                Person person = peopleKVP[personName];
                Product product = productKVP[productName];

                bool isAdded = person.AddProduct(product);

                if (!isAdded)
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
                else
                {
                    Console.WriteLine($"{personName} bought {productName}");
                }

                command = Console.ReadLine();
            }

            foreach (var (name, person) in peopleKVP)
            {
                string productsInfo = person.Products.Count > 0
                    ? string.Join(", ", person.Products.Select(x => x.Name))
                    : "Nothing bought";

                Console.WriteLine($"{name} - {productsInfo}");
            }
        }
    }
}
