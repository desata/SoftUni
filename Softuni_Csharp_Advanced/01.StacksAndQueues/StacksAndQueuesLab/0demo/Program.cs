using System;
using System.Collections;
using System.Collections.Generic;

namespace _0demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(5);
            stack.Push(6);
            stack.Push(7);

            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());

        }
    }
}
