using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a collection of strings from the console and then prints them onto the console. Each name should be printed on a new line. Use Action<T>.

            List<string> names = Console.ReadLine().Split(" ").ToList();
            Action<string> printName = (name) => Console.WriteLine(name);
            foreach (string name in names)
            {
                printName(name);
            }
        }
    }
}

