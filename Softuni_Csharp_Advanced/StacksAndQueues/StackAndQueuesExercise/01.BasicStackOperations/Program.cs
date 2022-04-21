using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Play around with a stack. You will be given an integer N representing the number of elements to push into the stack, an integer S representing the number of elements to pop from the stack, and finally an integer X, an element that you should look for in the stack. If it’s found, print "true" on the console. If it isn't, print the smallest element currently present in the stack. If there are no elements in the sequence, print 0 on the console.
            //On the first line, you will be given N, S, and X, separated by a single space
            //On the next line, you will be given N number of integers

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            int pushN = numbers[0];
            int popS = numbers[1];
            int lookForX = numbers[2];
            int minNum = int.MaxValue;

            for (int i = 0; i < pushN; i++)
            {
                stack.Push(integers[i]);
            }
            for (int i = 0; i < popS; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(lookForX))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                foreach (int item in stack)
                {
                    if (item < minNum)
                    {
                        minNum = item;
                    }
                }
                Console.WriteLine(minNum);
            }
            

        }
    }
}
