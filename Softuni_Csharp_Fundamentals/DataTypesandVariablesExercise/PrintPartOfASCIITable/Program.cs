using System;

namespace PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //write a program that prints part of the ASCII table of characters at the console.
            //On the first line of input, you will receive the char index you should start with,
            //and on the second line - the index of the last character you should print.

            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int number = (secondNumber-firstNumber);
            char symbol = (char)(firstNumber);

            for (int i = 0; i <= number; i++)
            {
                Console.Write($"{(char)(symbol+i)} ");
            }

            
        }
    }
}
