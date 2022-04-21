using System;
using System.Linq;

namespace _08.CondenseArraytoNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program to read an array of integers and condense them by summing all adjacent couples of elements until a single integer remains.
            //For example, let us say we have 3 elements - { 2, 10, 3}.
            //We sum the first two and the second two elements and get { 2 + 10, 10 + 3} = { 12, 13}, then we sum all adjacent elements again.This results in { 12 + 13} = { 25}.

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] condensed = new int[numbers.Length-1];

            for (int j = 0; j < condensed.Length; j++)
            {
                for (int i = 0; i < numbers.Length - 1; i++)
                {

                    condensed[i] = numbers[i] + numbers[i + 1];

                }
                numbers = condensed;
            }

            Console.WriteLine(numbers[0]);

        }
    }
}
