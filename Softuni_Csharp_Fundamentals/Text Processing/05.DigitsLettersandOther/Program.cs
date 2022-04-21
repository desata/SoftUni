using System;

namespace _05.DigitsLettersandOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that receives a single string and on the first line prints all the digits, on the second – all the letters, and on the third – all the other characters.
            //There will always be at least one digit, one letter, and one other character

            string text = Console.ReadLine();
            string digit = "";
            string letter = "";
            string others = "";

                foreach (char item in text)
                {
                if (Char.IsDigit(item))
                {
                    digit += item;
                }
                else if (Char.IsLetter(item))
                {
                    letter += item;
                }
                else
                {
                    others += item;
                }
                }
                Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(others);
        }
    }
}
