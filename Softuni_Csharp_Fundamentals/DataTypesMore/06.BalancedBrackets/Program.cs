using System;

namespace _06.BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive n lines. On those lines, you will receive one of the following:
            //•	Opening bracket – “(“,
            //•	Closing bracket – “)” or
            //•	Random string
            //Your task is to find out if the brackets are balanced.
            //That means after every closing bracket should follow an opening one.Nested parentheses are not valid, and if two consecutive opening brackets exist, the expression should be marked as unbalanced.
            //Input
            //•	On the first line, you will receive n – the number of lines, which will follow
            //•	On the next n lines, you will receive "(", ")" or another string
            //Output
            //You have to print "BALANCED" if the parentheses are balanced and "UNBALANCED" otherwise.

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string line = Console.ReadLine();
            }


        }
    }
}
