using System;
using System.Text;

namespace LowerOrUpper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that prints whether a given character is upper-case or lower case.

            char inputChar = char.Parse(Console.ReadLine());
            int character = inputChar;
            string result;

            if (character >= 65 && character <= 90)
            {
                result = "upper-case";
            }
            else
            {
                result = "lower-case";
            }        

            Console.WriteLine($"{result}");
        }
    }
}