using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.

            int n = int.Parse(Console.ReadLine());
            
            Predicate<string> lengthFilter = x => x.Length <= n;
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().FindAll(lengthFilter).ForEach(Console.WriteLine);

        }
    }
}