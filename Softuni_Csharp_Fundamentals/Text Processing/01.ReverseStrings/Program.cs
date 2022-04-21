using System;
using System.Collections.Generic;

namespace _01.ReverseStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will be given a series of strings until you receive an "end" command.
            //Write a program that reverses strings and prints each pair on a
            //separate line in the format "{word} = {reversed word}".

            string word = Console.ReadLine();
            
            

            while (word != "end")
            {
                string reversed = "";

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    reversed += word[i];
                }
                Console.WriteLine($"{word} = {reversed}");

                word = Console.ReadLine();
            }

            
        }
    }
}
