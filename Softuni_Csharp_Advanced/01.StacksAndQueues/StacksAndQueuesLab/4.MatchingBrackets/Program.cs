using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //We are given an arithmetic expression with brackets. Scan through the string and extract each sub-expression.
            //Print the result back at the terminal.

            var expression = Console.ReadLine();
            Stack<int> index = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    index.Push(i);
                }
                else if (expression[i] == ')')
                { 
                    int startIndex = index.Pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                    
                }
            }
        }
    }
}
