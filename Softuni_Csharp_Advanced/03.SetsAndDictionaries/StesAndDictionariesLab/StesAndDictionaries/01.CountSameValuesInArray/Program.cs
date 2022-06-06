using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that counts in a given array of double values the number of occurrences of each value. 

            double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray(); ;
            Dictionary<double,int> numbers = new Dictionary<double,int>();

            foreach (var item in array)
            {
                if (!numbers.ContainsKey(item))
                {
                    numbers.Add(item, 0);
                }
                numbers[item]++;
            }

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }

        }
    }
}
