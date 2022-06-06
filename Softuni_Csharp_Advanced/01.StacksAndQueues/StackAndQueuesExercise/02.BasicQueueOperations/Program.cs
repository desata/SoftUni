using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueueOperations
{

        internal class Program
        {
            static void Main(string[] args)
            {
                
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int[] integers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Queue<int> stack = new Queue<int>();
                int pushN = numbers[0];
                int popS = numbers[1];
                int lookForX = numbers[2];
                int minNum = int.MaxValue;

                for (int i = 0; i < pushN; i++)
                {
                    stack.Enqueue(integers[i]);
                }
                for (int i = 0; i < popS; i++)
                {
                    stack.Dequeue();
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