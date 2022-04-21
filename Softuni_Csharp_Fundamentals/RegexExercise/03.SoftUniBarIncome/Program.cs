using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string regex = @"\%([A-Z]{1}[a-z]+)\%([^$%|.]*?)\<(\w+)\>([^$%|.]*?)\|(\d{1,})\|([^$%|.]*?)([-+]?[0-9]*\.?[0-9]*)\$";

            //Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            double sum = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of shift")
            {
                MatchCollection matches = Regex.Matches(input, regex);

                string name = "";
                string product = "";
                double price = 0;

                foreach (Match item in matches)
                {
                    name = item.Groups[1].Value;
                    product = item.Groups[3].Value;
                    price = double.Parse(item.Groups[5].Value) * double.Parse(item.Groups[7].Value);
                    sum += price;

                    Console.WriteLine($"{name}: {product} - {price:f2}");
                }
            }

            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}
