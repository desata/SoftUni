using System;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method that receives two characters and prints all the characters between them according to ASCII (on a single line).
            //NOTE: If the second letter's ASCII value is less than that of the first one then the two initial letters should be swapped.

            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());

            GetAsciiCode(char1, char2);
            GetMissingChars(char1, char2);
        }
        static void GetAsciiCode(char char1, char char2)
        {
            int charInt1 = (int)char1;
            int charInt2 = (int)char2;
            return;
        }

        static void GetMissingChars(int asciiChar1, int asciiChar2)
        {


            if (asciiChar1 > asciiChar2)
            {
                for (int i = asciiChar2 + 1; i <= asciiChar1 - 1; i++)
                {
                    Console.Write((char)i);
                    Console.Write(" ");
                }

            }
            else if (asciiChar1 < asciiChar2)
            {
                for (int i = asciiChar1 + 1; i <= asciiChar2 - 1; i++)
                {
                    Console.Write((char)i);
                    Console.Write(" ");
                }

            }
            return;
        }
    }
}