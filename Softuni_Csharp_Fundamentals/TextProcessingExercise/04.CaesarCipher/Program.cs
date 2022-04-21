using System;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that returns an encrypted version of the same text.
            //Encrypt the text by shifting each character with three positions forward.
            //For example, A would be replaced by D, B would become E, and so on.
            //Print the encrypted text.

            string text = Console.ReadLine();

            foreach (char item in text)
            {
               
                var newChar = (char)(item + 3);
                Console.Write(newChar);

            }
        }
    }
}
