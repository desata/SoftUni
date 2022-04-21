using System;
using System.Linq;

namespace EvenOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that calculates the difference between the sum of the even and the sum of the odd numbers in an array.

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    sumEven += array[i];
                }
                else
                {
                    sumOdd += array[i];
                }
            }


            Console.WriteLine(sumEven-sumOdd);
        }
    }
}
