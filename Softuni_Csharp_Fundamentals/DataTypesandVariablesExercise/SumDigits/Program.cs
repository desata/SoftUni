using System;

namespace SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Create a program that receives a single integer. Your task is to find the sum of its digits.
            //For example: 12345-> 1 + 2 + 3 + 4 + 5 = 15

            int n = int.Parse(Console.ReadLine());
            int number = n;
            int sum = 0;

            while (number > 0)
            {
                sum += number % 10;
                number /= 10;

            }
            Console.WriteLine(sum);
        }
    }
}
