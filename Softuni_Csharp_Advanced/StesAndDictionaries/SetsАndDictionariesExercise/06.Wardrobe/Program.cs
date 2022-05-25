using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] cloth = input[1].Split(",");

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                }
                Dictionary<string, int> clothes = wardrobe[color];

                foreach (var item in cloth)
                {
                    if (!clothes.ContainsKey(item))
                    {
                        clothes.Add(item, 0);
                    }
                    clothes[item]++;

                }
            }

            string[] colorAndCloth = Console.ReadLine().Split();


            foreach (var color in wardrobe)
            {
                var drehi = color.Value;

                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in drehi)
                {
                    if (colorAndCloth[0] == color.Key && colorAndCloth[1] == item.Key)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }


        }
    }
}
