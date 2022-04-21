using System;
using System.Linq;

namespace _04.WordFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Read an array of strings and take only words,
            //whose length is an even number.
            //Print each word on a new line.

            string[] words = Console.ReadLine().Split(' ').Where(w => w.Length % 2 == 0).ToArray();


            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
