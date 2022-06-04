using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a line of text from the console. Print all the words that start with an uppercase letter in the same order you've received them in the text.
            //Use Func<string, bool> and use " " for splitting words.

            Predicate<string> checker = n => n[0] == n.ToUpper()[0];

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Where(i => checker(i)).ToArray();

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}
