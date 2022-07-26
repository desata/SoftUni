using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);

            string[] arg = Console.ReadLine().Split();
            string command = arg[0].ToLower();

            while (command != "end")
            {                
                if (command == "add")
                {
                    int firstNumberToAdd = int.Parse(arg[1]);
                    int secondNumberToAdd = int.Parse(arg[2]);
                    stack.Push(firstNumberToAdd);
                    stack.Push(secondNumberToAdd);

                }
                else if (command == "remove")
                {
                    int numbersToRemove = int.Parse(arg[1]);

                    if (stack.Count - numbersToRemove > 0)
                    {
                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                arg = Console.ReadLine().Split();
                command = arg[0].ToLower();
            }

            int sum = 0;
           // Console.WriteLine(stack);
            foreach (int item in stack)
            {
                sum += item;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
