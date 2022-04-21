using System;

namespace specialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //A number is special when its sum of digits is 5, 7, or 11.
            //Write a program to read an integer n and for all numbers in the range 1…n to print the number and if it is special or not (True / False).
            //Hint: To calculate the sum of digits of given number num, you might repeat the following: sum the last digit (num % 10) and remove it (sum = sum / 10) until num reaches 0.

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {


                int number = i;
                int sum = 0;

                while (number > 0)
                {
                    sum += number % 10;
                    number /= 10;
                }

                bool isSpecial = false;

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    
                    isSpecial = true;
                }
                Console.WriteLine($"{i} -> {isSpecial}");
            }

        }
    }
}
