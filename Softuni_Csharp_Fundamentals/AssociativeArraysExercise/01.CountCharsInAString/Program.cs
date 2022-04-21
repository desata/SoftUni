using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that counts all characters in a string
            //except for space (' '). 
            //Print all the occurrences in the following format:
            //"{char} -> {occurrences}"

            //string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            //char[] text = string.Join(input[]);
            char[] text = Console.ReadLine().Replace(" ", "").ToArray();
            
            Dictionary<char, int> characters = new Dictionary<char, int>();

            foreach (char s in text)
            {
                if (characters.ContainsKey(s))
                {
                    characters[s] += 1;
                }
                else
                    characters.Add(s, 1);
            }
        
            foreach(var character in characters)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
