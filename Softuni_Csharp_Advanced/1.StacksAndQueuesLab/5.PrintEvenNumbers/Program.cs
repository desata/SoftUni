using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //	Reads an array of integers and adds them to a queue
            //	Prints the even numbers separated by ", "
            // 1 2 3 4 5 6	||| 2, 4, 6
            // 11 13 18 95 2 112 81 46 ||| 18, 2, 112, 46

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            foreach (int item in input)
            {
                if (item % 2 == 0)
                {
                    queue.Enqueue(item);
                }
            }
            Console.Write($"{string.Join(", ", queue)}");
        }
    }
}
