using System;

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

        }
    }
}
