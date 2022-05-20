using System;
using System.Linq;

namespace _03.Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read a list of integers and print the largest 3 of them. If there are less than 3, print all of them.

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] sorted = input.OrderByDescending(x => x).ToArray();
            int loop = 3;
            if (sorted.Length < 3)
            {
                loop = sorted.Length;
            }

            for (int i = 0; i < loop; i++)
            {
                Console.Write($"{sorted[i]} ");
            }

        }
    }
}
