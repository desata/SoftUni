using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read a list of integers, remove all negative numbers from it and print the remaining elements in reversed order.
            //If there are no elements left in the list, print "empty".

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            //numbers.Sort();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }

            }
            if (numbers.Count <= 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                numbers.Reverse();
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
