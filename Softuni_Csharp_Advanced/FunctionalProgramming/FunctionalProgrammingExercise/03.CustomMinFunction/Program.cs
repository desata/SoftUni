using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection. Use Func<T, T>.
            
            //with BiulIn Min()
            //Func<int[], int> getMinNumber = numbers => numbers.Min();

            //with custom Min function
            Func<int[], int> getMinNumber = numbers
                =>
            {
                int minValue = int.MaxValue;

                foreach (var number in numbers)
                {
                    if (number<minValue)
                    {
                        minValue = number;
                    }
                }
                return minValue;
            };

            int[] inputNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            

            Console.WriteLine(getMinNumber(inputNumbers));
        }
    }
}
