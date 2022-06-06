using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads some text from the console and counts the occurrences of each character in it. Print the results in alphabetical (lexicographical) order. 

            string input = Console.ReadLine();
            SortedDictionary<char, int> dictionary = new SortedDictionary<char,int>();

            foreach (var item in input)
            {
                if (!dictionary.ContainsKey(item))
                {
                    dictionary.Add(item, 0);
                }
                dictionary[item]++;
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");

            }

        }
    }
}
