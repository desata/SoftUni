using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2 + 5 + 10 - 2 - 1	14
            //2 - 2 + 5   5
            //Create a simple calculator that can evaluate simple expressions with only addition and subtraction. There will not be any parentheses.
            //Solve the problem using a Stack.

            string[] input = Console.ReadLine().Split().ToArray();
            Stack<string> stack = new Stack<string>(new Stack<string>(input));

            while (stack.Count > 1)
            {
                int x = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int y = int.Parse(stack.Pop());

                if (sign == "+")
                {
                    stack.Push((x + y).ToString());
                }
                else if (sign == "-")
                {
                    stack.Push((x - y).ToString());
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
