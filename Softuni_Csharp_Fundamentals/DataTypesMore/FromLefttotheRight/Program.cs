using System;
using System.Numerics;

namespace FromLefttotheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * //You will receive a number that represents how many lines we will get as input. 
             * On the next N lines, you will receive a string with 2 numbers separated by a single space. 
             * You need to compare them. If the left number is greater than the right number, 
             * you need to print the sum of all digits in the left number, 
             * otherwise, print the sum of all digits in the right number.*/

            int n = int.Parse(Console.ReadLine());
            long greater = long.MinValue;
            long valueNum;
            long sum = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] numbers = input.Split(' ');
                greater = long.MinValue;
                foreach (string sub in numbers)
                {

                    long.TryParse(sub, out valueNum);
                    if (valueNum >= greater)
                    {

                        greater = valueNum;

                    }
                }
                sum = 0;
                while (Math.Abs(greater) > 0)
                {

                    sum += greater % 10;
                    greater /= 10;
                }
                Console.WriteLine(Math.Abs(sum));
            }

        }
    }
}
