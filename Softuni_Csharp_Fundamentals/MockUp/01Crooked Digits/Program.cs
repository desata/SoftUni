using System;
using System.Linq;
using System.Collections.Generic;

namespace _01Crooked_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sums the digits of the number N and stores the result back in N.
            //If the obtained result is bigger than 9, step 1. is repeated, otherwise the algorithm finishes.
            //The last obtained value of N is the result, calculated by the algorithm.

            string numbers = Console.ReadLine();

            int sum = 0;

            foreach (char digit in numbers)
            {
                int number = (int)digit;

                if (number >= 48 && number <= 57)
                {
                    number -= 48;
                    sum = sum + number;
                }
                else
                {
                    continue;
                }
            }
            while (sum > 9)
            {
                if (sum <= 9)
                {
                    Console.WriteLine(sum);
                }
                else
                {
                    int num = sum;
                    sum = 0;
                    while (num > 0)
                    {
                        sum += num % 10;
                        num /= 10;

                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
