using System;
using System.Linq;

namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program to find all the top integers in an array.
            //A top integer is an integer that is greater than all the elements to its right.

            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {bool isBigger = true;
                for (int j = i + 1; j < array.Length; j++)
                {
                    
                    if (array[i] <= array[j])
                    {
                        isBigger = false;
                    }

                }

                if (isBigger == true)
                {
                    Console.Write($"{array[i]} ");
                }
            }
        }
    }
}
