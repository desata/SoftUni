using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            // write a program that receives a single integer and calculates is it a strong or not. a number is strong if the sum of the factorial of each digit is equal to the number. 
            // example: 145 is a strong number, because 1! + 4! + 5! = 145. 
            // print "yes" if the number is strong or "no" if the number is not strong.

            int number = int.Parse(Console.ReadLine());
            int tempNumber = number;
            int factorialSum = 0;

            while (tempNumber>0)
            {
                int currNumber = tempNumber % 10;
                tempNumber /= 10;
                int currFactNum = 1;
                for (int i = 1; i <= currNumber; i++)
                {
                    currFactNum *= i;
                }
                factorialSum += currFactNum;
            }
            string result = factorialSum == number ? "yes" : "no";
            Console.WriteLine(result);
        }
    }
}
