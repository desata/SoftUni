using System;
using System.Collections.Generic;
using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a string from the console and replaces any sequence of the same letters with a single corresponding letter.

            string input = Console.ReadLine();

            char firstChar = input[0];
            Console.Write(firstChar);
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (firstChar != currentChar)
                { 
                    firstChar=currentChar;
                    Console.Write(firstChar);
                }
            }
           
        }
    }
}
;