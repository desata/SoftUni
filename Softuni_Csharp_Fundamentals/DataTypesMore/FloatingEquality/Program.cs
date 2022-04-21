using System;

namespace FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Write a program that safely compares floating-point numbers (double) with precision eps = 0.000001. 
            Note that we cannot directly compare two floating-point numbers a and b by a==b because of the nature of the floating-point arithmetic. 
            Therefore, we assume two numbers are equal if they are more close to each other than some fixed constant eps. 
            You will receive two lines, each containing a floating-point number. Your task is to compare the values of the two numbers.
             */

            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());
            double result = Math.Abs(numberA - numberB);

            if (numberA == numberB || numberA == numberB || result <= 0.000001)
            {
                
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
