using System;

namespace REversedString
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string reversedWord = string.Empty;

            for (int i = word.Length - 1; i >= 0; i--)
            {
                reversedWord += word[i];
            }

            Console.WriteLine(reversedWord);
        }
    }
}
