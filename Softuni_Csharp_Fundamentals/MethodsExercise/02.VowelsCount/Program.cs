using System;
using System.Linq;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = GetVowelsCount(word);
            Console.WriteLine(count);
        }

        static int GetVowelsCount(string word)
        {
            char[] vowels = new char[] {'a', 'e', 'i', 'o', 'u', 'y'};

            int count = 0;

            foreach (char ch in word.ToLower())
            {
                if (vowels.Contains(ch))
                {
                    count++;
                }
            }
            return count;
        }

    }
}
