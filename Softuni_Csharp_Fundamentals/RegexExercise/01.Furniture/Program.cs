using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            //">>{furniture name}<<{price}!{quantity}"
            List<string> result = new List<string>();
            double totalPrice = 0;

            string regex = @">>(?<name>[A-Za-z\s]+)<<(?<price>(\d+(.\d+)?))\!(?<qty>(\d+))";

            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, regex, RegexOptions.IgnoreCase);
                if (matches.Success)
                {
                    var name = matches.Groups["name"].Value;
                    var price = double.Parse(matches.Groups["price"].Value);
                    var qty = int.Parse(matches.Groups["qty"].Value);

                    result.Add(name);
                    totalPrice+=price*qty;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            result.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
            
        }
    }
}
