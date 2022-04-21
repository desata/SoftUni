using System;

namespace _10.MultiplyEvensbyOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Create a program that multiplies the sum of all even digits of a number by the sum of all odd digits of the same number:
            •	Create a method called GetMultipleOfEvenAndOdds()
            •	Create a method GetSumOfEvenDigits()
            •	Create GetSumOfOddDigits()
            •	You may need to use Math.Abs() for negative numbers
            */
            int number = int.Parse(Console.ReadLine());
            int result = Math.Abs(GetSumOfEvenDigits(number) * GetSumOfOddDigits(number));
            Console.WriteLine($"{result}");

        }
        static void GetMultipleOfEvenAndOdds(int number)
        {
            GetSumOfEvenDigits(number);
            GetSumOfOddDigits(number);

        }

        static int GetSumOfEvenDigits(int number)
        {
            number = Math.Abs(number);
            int num = 0;
            int sum = 0;
            while (number > 0)
            {
                num = number % 10;
                if (num % 2 == 0)
                {
                    sum += num;
                }
                number /= 10;
            }
           // Console.WriteLine(sum);
            return sum;
        }

        static int GetSumOfOddDigits(int number)
        {
            number = Math.Abs(number);
            int num = 0;
            int sum = 0;
            while (number > 0)
            {
                num = number % 10;
                if (num % 2 != 0)
                {
                    sum += num;
                }
                number /= 10;
            }
           // Console.WriteLine(sum);
            return sum;
        }

    }
}
