using System;

namespace CharstoString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char inputChar;
            string output = string.Empty;

            for (int i = 1; i < 4; i++)
            {
                inputChar = char.Parse(Console.ReadLine());
                output += inputChar;
            }
            
            Console.WriteLine($"{output}");
        }
    }
}
