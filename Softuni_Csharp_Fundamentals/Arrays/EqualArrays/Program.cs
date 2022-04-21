using System;
using System.Linq;

namespace EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //If the arrays are identical find the sum of the elements of one of them and print the following message to the console: "Arrays are identical. Sum: {sum}"
            //Otherwise, find the first index where the arrays differ and print the following message to the console:  "Arrays are not identical. Found difference at {index} index."

            int[] arrayOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arrayTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;


            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] != arrayTwo[i])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }

                else
                {
                    sum += arrayOne[i];

                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sum}");
        }
    }
}
