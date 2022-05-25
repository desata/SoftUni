using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that prints a set of elements. On the first line, you will receive two numbers - n and m, which represent the lengths of two separate sets. On the next n + m lines, you will receive n numbers, which are the numbers in the first set, and m numbers, which are in the second set. Find all the unique elements that appear in both of them and print them in the order in which they appear in the first set - n.

            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = nm[0];
            int m = nm[1];

            HashSet<int> firstSet = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                int numbersN = int.Parse(Console.ReadLine());
                firstSet.Add(numbersN);
            }
            HashSet<int> secondSet = new HashSet<int>();
            for (int i = 0; i < m; i++)
            {
                int numbersM = int.Parse(Console.ReadLine());
                secondSet.Add(numbersM);

            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));

        }
    }
}
