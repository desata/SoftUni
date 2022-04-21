using System;
using System.Collections.Generic;

namespace _1.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Reads an input string
            //•	Reverses it using a Stack< T >
            //•	Prints the result back at the terminal

            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);

            foreach (var item in stack)
            {
                
                stack.Peek();
                Console.Write(item);
            }

        }
    }
}
