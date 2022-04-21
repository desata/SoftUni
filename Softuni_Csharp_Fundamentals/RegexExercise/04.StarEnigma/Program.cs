using System;
using System.Collections.Generic;

namespace _04.StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messages = int.Parse(Console.ReadLine());
            var attacked = new List<string>();
            var destroyed = new List<string>();
            for (int i = 1; i <= messages; i++)
            {
                string input = Console.ReadLine();
                int deduction = 0;
                foreach (var symbol in input.ToLower())
                {
                    if (symbol == 's' || symbol == 't' || symbol == 'a' || symbol == 'r') deduction++;
                }
                string newString = string.Empty;
                for (int j = 0; j < input.Length; j++)
                {
                    newString += (char)(input[j] - deduction);
                }
                string regex = @"\w*[^@\-!:>]*@(?<planet>[A-Za-z]+)\W*\d*:[@\-!:>]*[A-Za-z]*(?<population>\d+)[A-Za-z]*[^@\-!:>]*![^@\-!:>]*(?<type>[A|D])[0-9]*[@\-!:>]*![^@\-!:>]*->[A-Za-z]*[@\-!:>]*(?<soldiers>\d+)([A-Za-z]*[^@\-!:>]*)";

                var data = Regex.Matches(newString, regex);

                if (data.Count > 0)
                {
                    foreach (Match item in data)
                    {
                        string planetName = item.Groups["planet"].Value;
                        string type = item.Groups["type"].Value;
                        if (type == "A") attacked.Add(planetName);
                        else destroyed.Add(planetName);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            if (attacked.Count > 0)
            {
                attacked.Sort();
                for (int i = 0; i < attacked.Count; i++)
                {
                    Console.WriteLine($"-> {attacked[i]}");
                }
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            if (destroyed.Count > 0)
            {
                destroyed.Sort();
                for (int i = 0; i < destroyed.Count; i++)
                {
                    Console.WriteLine($"-> {destroyed[i]}");
                }
            }
        }
    }
}
