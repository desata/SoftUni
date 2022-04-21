using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            SortedDictionary<int, int> counts = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number] += 1;
                }
                else
                {
                    counts.Add(number, 1);
                }
            }

            foreach (var number in counts)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
