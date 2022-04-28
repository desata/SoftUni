using System;
using System.Collections.Generic;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                if (command[0] == "1")
                {
                    stack.Push(command[1]);
                }
                else if (command[0] == "2")
                {
                    int count = int.Parse(command[1]);
                    string current = stack.Peek();
                    while (count != 0)
                    {
                        stack.Pop();
                        count--;
                    }
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);
                    string current = stack.Peek();
                    Console.WriteLine(current[index-1]);
                }
                else if (command[0] == "4")
                {
                    continue;
                }
            }


        }
    }
}
