using System;
using System.Collections.Generic;
using System.Linq;


namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line.
            //Use a function that accepts another function as one of its parameters.
            //Start by building a regular function to hold the basic logic of the program.
            //Something along the lines of Func<string, int, bool>.
            //Afterward, create your main function which should accept the first function as one of its parameters.

            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().ToArray();
            Console.WriteLine(names.First(name => name.Select(x => (int)x).Sum() >= n));
           
        }
    }
}
