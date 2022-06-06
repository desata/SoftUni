using System;
using System.Collections.Generic;
using System.Linq;


namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a collection of names as strings from the console, appends "Sir" in front of every name, and prints it back on the console. Use Action<T>.

            Action<List<string>> printNamesWithSir = name =>
            Console.WriteLine("Sir " + string.Join(Environment.NewLine + "Sir ", name));
            List<string> names = Console.ReadLine().Split().ToList();

            printNamesWithSir(names);
            
        }
    }
}
