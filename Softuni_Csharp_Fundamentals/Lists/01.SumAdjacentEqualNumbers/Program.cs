using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program to sum all of the adjacent equal numbers in a list of decimal numbers, starting from left to right.

            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int i = 0; i < numbers.Count-1; i++)
            {
                if (numbers[i] == numbers[i+1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
