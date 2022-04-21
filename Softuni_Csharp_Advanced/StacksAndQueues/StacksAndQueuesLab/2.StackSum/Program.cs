using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Reads an input of integer numbers and adds them to a stack
            //•	Reads command until "end" is received
            //•	Prints the sum of the remaining elements of the stack

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);
            string[] command = Console.ReadLine().Split();
            int sum = 0;

            while (command[0].ToLower() != "end")
            {
                string argument = command[0].ToLower();

                if (argument == "add")
                {

                    stack.Push(int.Parse(command[1]));
                    stack.Push(int.Parse(command[2]));
                }
                else if (argument == "remove")
                {
                    int first = int.Parse(command[1]);
                    if (first < stack.Count)
                    {
                        for (int i = 0; i < first; i++)
                        {
                            stack.Pop();
                        }
                    }
                    
                }

                command = Console.ReadLine().Split();
            }

            foreach (var item in stack)
            {
                sum += item;

            }
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
