using System;

namespace _01.SignofIntegerNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A single integer is given, create a method that checks if the given number is positive, negative, or zero. As a result print:
            //•	For positive number: "The number {number} is positive. "
            //•	For negative number: "The number {number} is negative. "
            //•	For zero number: "The number {number} is zero. "


            int number = int.Parse(Console.ReadLine());
            GetSign(number);


            static void GetSign(int number)
            {
                if (number == 0)
                {
                    Console.WriteLine($"The number {number} is zero.");
                }
                else if (number < 0)
                {

                    Console.WriteLine($"The number {number} is negative.");
                }
                else
                {
                    Console.WriteLine($"The number {number} is positive.");
                }

                return;
            }

        }
    }
}
