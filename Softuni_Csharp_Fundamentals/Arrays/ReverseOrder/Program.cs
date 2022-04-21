using System;

namespace ReverseOrder
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

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write($"{numbers[i]}" + " ");
            }
        }
    }
}
