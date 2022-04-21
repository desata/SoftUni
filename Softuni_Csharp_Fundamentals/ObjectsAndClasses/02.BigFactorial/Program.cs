using System;
using System.Numerics;


namespace _02.BigFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive a number N in the range [0 - 1000].
            //Calculate the Factorial of N and print out the result.

            int number = int.Parse(Console.ReadLine());
            BigInteger result = 1;

            for (int i = 1; i <= number; i++)
            {
                result *= i; 
            }
            Console.WriteLine(result);
        }
    }
}
