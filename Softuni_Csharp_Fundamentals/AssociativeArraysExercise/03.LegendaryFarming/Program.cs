using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.LegendaryFarming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Shadowmourne - requires 250 Shards;
            //Valanyr - requires 250 Fragments;
            //Dragonwrath - requires 250 Motes;

            string[] input;// = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool hasLegendary = false;
            Dictionary<string, int> items = new Dictionary<string, int>();
            {
                items["shards"] = 0;
                items["motes"] = 0;
                items["fragments"] = 0;

            };

            while (hasLegendary == false)
            {
                input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 1; i < input.Length; i += 2)
                {
                    //string wordToLower = word.ToLower();
                    string wordToLower = input[i].ToLower();
                    if (items.ContainsKey(wordToLower))
                    {
                        items[wordToLower] += int.Parse(input[i - 1]);
                    }
                    else
                    {
                        items.Add(wordToLower, int.Parse(input[i - 1]));
                    }

                    if (items["shards"] >= 250)
                    {
                        items["shards"] -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        hasLegendary = true;
                        break;
                    }
                    if (items["fragments"] >= 250)
                    {
                        hasLegendary = true;
                        items["fragments"] -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        break;
                    }
                    if (items["motes"] >= 250)
                    {
                        items["motes"] -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        hasLegendary = true;
                        break;
                    }
                }
            }
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
