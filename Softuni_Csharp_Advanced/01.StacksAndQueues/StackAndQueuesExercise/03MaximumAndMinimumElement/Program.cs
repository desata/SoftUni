using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int queries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            int minNum = int.MaxValue;
            int maxNum = int.MinValue;

            for (int i = 0; i < queries; i++)
            {
                int[] element = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (element[0] == 1)
                {
                    stack.Push(element[1]);
                }
                else if (element[0] == 2)
                {
                    if (stack.Count > 0)
                    {
                                     
                    stack.Pop();
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (element[0] == 3)
                {
                    if (stack.Count > 0)
                    {
                        foreach (int item in stack)
                        {
                            if (item > maxNum)
                            {
                                maxNum = item;
                            }
                        }
                        Console.WriteLine(maxNum);
                    }
                }
                else if (element[0] == 4)
                {
                    if (stack.Count > 0)
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
            
            Console.WriteLine($"{String.Join(", ", stack)}");
        }
    }
}
