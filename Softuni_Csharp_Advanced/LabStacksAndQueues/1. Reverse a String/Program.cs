using System;
using System.Collections.Generic;

namespace _1._Reverse_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();
            string input = Console.ReadLine();

            foreach (var character in input)
            {
                stack.Push(character);
            }


            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

        }
    }
}
