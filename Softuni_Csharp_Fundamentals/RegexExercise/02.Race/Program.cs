using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regexNames = new Regex(@"(?<name>[A-Za-z])");
            Regex regexKm = new Regex(@"(?<km>\d)");
            int totalkm = 0;

            List<string> racers = Console.ReadLine().Split(", ").ToList();
            Dictionary<string, int> result = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "end of race")
            {
                totalkm = 0;
                MatchCollection matchedNames = regexNames.Matches(input);
                MatchCollection matchedKm = regexKm.Matches(input);
                var currName = string.Join("", matchedNames);
                var currKm = string.Join("", matchedKm);

                for (int i = 0; i < currKm.Length; i++)
                {
                    totalkm += int.Parse(currKm[i].ToString());
                    
                }
                if (racers.Contains(currName))
                {
                    if (!result.ContainsKey(currName))
                    {
                        result.Add(currName, totalkm);
                    }
                    else
                    {
                        result[currName] += totalkm;
                    }
                }
                input = Console.ReadLine();
            }
            var winners = result.OrderByDescending(x => x.Value).ToList();
            Console.WriteLine($"1st place: {winners[0].Key}");
            Console.WriteLine($"2nd place: {winners[1].Key}");
            Console.WriteLine($"3rd place: {winners[2].Key}");

        }
    }
}
