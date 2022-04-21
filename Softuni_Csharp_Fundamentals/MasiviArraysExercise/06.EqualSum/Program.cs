using System;
using System.Linq;

namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that determines if an element exists in an array for which the sum of all elements to its left is equal to the sum of all elements to its right.
            //If there are no elements to the left or right, their sum is considered to be 0.
            //Print the index of the element that satisfies the condition or "no" if there is no such element.

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (array.Length <= 1)
            {
                Console.WriteLine(0);
            }
            else if (array.Length <= 2)
            {
                Console.WriteLine("no");
            }

            for (int i = 0; i < array.Length; i++)
            {
                int sumL = 0;
                int sumR = 0;

                for (int j = 1; j < i; j++)
                {

                    sumL += array[j];

                }



            }
        }
    }
}
