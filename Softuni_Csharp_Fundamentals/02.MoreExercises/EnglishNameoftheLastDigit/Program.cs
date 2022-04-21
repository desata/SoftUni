using System;

namespace EnglishNameoftheLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a method that returns the English spelling of the last digit of a given number.
            //Write a program that reads an integer and prints the returned value from this method.;

            int n = int.Parse(Console.ReadLine());
            string name = string.Empty;
            int sum = n % 10;

            if (sum ==1)
            {
                name = "one";
            }
            if (sum == 2)
            {
                name = "two";
            }
            if (sum == 3)
            {
                name = "tree";
            }
            if (sum == 4)
            {
                name = "four";
            }
            if (sum == 5)
            {
                name = "five";
            }
            if (sum == 6)
            {
                name = "six";
            }
            if (sum == 7)
            {
                name = "seven";
            }
            if (sum == 8)
            {
                name = "eight";
            }
            if (sum == 9)
            {
                name = "nine";
            }
            if (sum == 0)
            {
                name = "zero";
            }

            Console.WriteLine(name);

        }
    }
}
