using System;
using System.Collections.Generic;

namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

            for (int i = 1; i <= numbers; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (pairs.ContainsKey(word))
                { 
                pairs[word].Add(synonym);
                }
                else
                {
                    pairs.Add(word, new List<string>() {synonym});
                }
            }

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.Key} - {string.Join(", ", pair.Value)}");
            }
        }
    }
}
