using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads from the console a sequence of N usernames and keeps a collection only of the unique ones. On the first line, you will be given an integer N. On the next N lines, you will receive one username per line. Print the collection on the console in order of insertion:

            int n = int.Parse(Console.ReadLine());
            HashSet<string> usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                usernames.Add(input);
            }

            Console.WriteLine(string.Join("\n", usernames));
        }
    }
}
