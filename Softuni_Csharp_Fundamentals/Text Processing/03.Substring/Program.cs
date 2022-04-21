using System;
using System.Text;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //On the first line, you will receive a string. On the second line, you will receive a second string.
            //Create a program that removes all of the occurrences of the first string in the second until there is no match.
            //At the end print the remaining string.

            string first = Console.ReadLine();
            string second = Console.ReadLine();

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < second.Length; i++)
            {
            
            int index = second.IndexOf(first);
             

            if (second.Contains(first))
            {
                second = second.Remove(index,first.Length);
            }
            }
            Console.WriteLine(second);
        }
    }
}
