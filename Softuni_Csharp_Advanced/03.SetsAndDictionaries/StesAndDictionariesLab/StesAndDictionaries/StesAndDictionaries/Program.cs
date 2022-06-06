using System;
using System.Collections.Generic;

namespace StesAndDictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fruits = new Dictionary<string, double>();
            fruits["banana"] = 2.20;
            fruits["apple"] = 1.40;
            fruits["kiwi"] = 3.20;
            Console.WriteLine(string.Join(", ", fruits.Keys));


            var sortedFruits = new SortedDictionary<string, double>();
            fruits["kiwi"] = 4.50;
            fruits["orange"] = 2.50;
            fruits["banana"] = 2.20;
            Console.WriteLine(string.Join(", ", fruits.Keys));

        }
    }
}
