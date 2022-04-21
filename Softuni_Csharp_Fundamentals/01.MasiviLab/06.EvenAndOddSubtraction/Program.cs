using System;
using System.Linq;

namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.

            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumOdd = 0;
            int sumEven = 0;
            int diffrence = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    sumEven += number;
                }
                else
                {
                    sumOdd += number;
                }
                diffrence = sumEven - sumOdd;
            }
            Console.WriteLine($"{diffrence}");
        }
    }
}
