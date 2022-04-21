using System;
using System.Linq;

namespace ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads an array of strings, reverses it, and prints its elements. The input consists of a sequence of space-separated Strings.
            //Print the output on a single line (space separated).
            

            string[] array = Console.ReadLine().Split().ToArray();

            for (int i = array.Length - 1; i >= 0; i--)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}
