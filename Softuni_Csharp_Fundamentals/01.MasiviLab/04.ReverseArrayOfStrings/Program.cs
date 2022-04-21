using System;

namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads an array of strings, reverses it, and prints its elements. The input consists of a sequence of space-separated Strings.
            //Print the output on a single line (space separated).

            string[] words = Console.ReadLine().Split(' ');

            for (int i = words.Length-1; i >= 0; i--)
            {
                Console.Write(words[i] + " ");
            }

        }
    }
}
