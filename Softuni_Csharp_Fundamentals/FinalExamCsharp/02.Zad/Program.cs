using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;

namespace _02.Zad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //02. Easter Eggs

            //string regex = @"(\@{1,}|#{1,})(?<color>[a-z]{3,})(\@{1,}|#{1,})(\W+)\/+(?<amount>\d+)\/+";
            string regex = @"(@|#)+(?<color>[a-z]{3,})(@|#)+([^a-z0-9])+(/)+(?<amount>[0-9]+)(/)+";

            string input = Console.ReadLine();

            MatchCollection matches = Regex.Matches(input, regex);

            foreach (Match match in matches)
            {
                string colorname = (match.Groups["color"].Value);
                int amount = int.Parse(match.Groups["amount"].Value);

                if (amount > 0) 
                {
                
                Console.WriteLine($"You found {match.Groups["amount"].Value} {match.Groups["color"].Value} eggs!");
            }
            }

        }
    }
}
