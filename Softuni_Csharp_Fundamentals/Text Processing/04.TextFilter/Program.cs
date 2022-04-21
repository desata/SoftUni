using System;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that takes a text and a string of banned words.
            //All words included in the ban list should be replaced with asterisks "*", equal to the word's length.
            //The entries in the ban list will be separated by a comma and space ", ".
            //The ban list should be entered on the first input line and the text on the second input line.

            string[] bannedWord = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (var item in bannedWord)
            {
                text = text.Replace(item, new string('*', item.Length));
            }
            Console.WriteLine(text);
        }
    }
}
