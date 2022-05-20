using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentandCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads continents, countries, and their cities put them in a nested dictionary and prints them.

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> collection = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string city = input[2];

                if (!collection.ContainsKey(continent))
                {
                    collection.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!collection[continent].ContainsKey(country))
                {
                    collection[continent][country] = new List<string>();

                }

                collection[continent][country].Add(city);
            }

            foreach (var continent in collection)
            {
                var country = continent.Value;

                Console.WriteLine($"{continent.Key}:");
                foreach (var item in country)
                {
                    Console.Write($"  {item.Key} -> ");
                    Console.WriteLine(String.Join(", ", item.Value));
                }
            }
        }
    }
}
