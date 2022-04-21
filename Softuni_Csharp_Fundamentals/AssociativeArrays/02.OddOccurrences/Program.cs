using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string wordToLower = word.ToLower();

                if (counts.ContainsKey(wordToLower))
                {
                    counts[wordToLower] += 1;
                }
                else
                {
                    counts.Add(wordToLower, 1);
                }
            }

            string[] result = counts.Where(item => item.Value % 2 != 0).Select(count => count.Key).ToArray();
            Console.WriteLine(string.Join(" ", result));

            //foreach (var count in counts)
            //{
            //    if (count.Value %2 !=0)
            //    {
            //        Console.Write(count.Key + " ");
            //    }
            //}
        }
    }
}
