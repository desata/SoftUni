using System;

namespace _02.PrintNumbersinReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read n numbers and print them in reverse order, separated by a single space.

            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            for (int j = numbers.Length-1; j >= 0; j--)
            {
                Console.Write($"{numbers[j]} ");
            }
        }
    }
}
