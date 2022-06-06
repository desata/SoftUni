using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            string input = Console.ReadLine();
            bool isBalanced = true;
            Stack<char> parenthesis = new Stack<char>();

            foreach (var item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    parenthesis.Push(item);
                    continue;
                }

                if (parenthesis.Count == 0)
                {
                    isBalanced = false;
                    break;
                }

                if (item == ')' && parenthesis.Peek() == '(')
                {
                    parenthesis.Pop();  
                }
                else if (item == '}' && parenthesis.Peek() == '{')
                {
                    parenthesis.Pop();
                }
                else if (item == ']' && parenthesis.Peek() == '[')
                {
                    parenthesis.Pop();
                }
                else
                {
                    isBalanced = false;
                    break;
                }

            }
            if (!isBalanced || parenthesis.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }

        }
    }
}
