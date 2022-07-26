using System;
using System.Collections.Generic;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<int> stack = new Stack<int>();
            stack.Push((int.Parse)(input[0]));

            for (int i = 1; i < input.Length; i+=2)
            {
                if (input[i] == "-")
                {
                    stack.Push(stack.Pop() - int.Parse(input[i+1]));
                }
                else
                {
                    stack.Push(stack.Pop() + int.Parse(input[i + 1]));
                }
                
            }

            Console.WriteLine(stack.Pop());
        }
    }
}