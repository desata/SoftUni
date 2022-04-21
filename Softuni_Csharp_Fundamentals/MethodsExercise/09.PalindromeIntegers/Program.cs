using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads positive integers until you receive the "END" command.
            //For each number, print whether the number is a palindrome or not.
            //A palindrome is a number that reads the same backward as forward, such as 323 or 1001. 

            string commands = "";
            IsPalindrome(commands);

            while (commands != "END")
            {
                commands = Console.ReadLine();
               
            
            if (commands == "END")
            {
                break;
            }
            if (IsPalindrome(commands))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
            

        }
        static bool IsPalindrome(string commands)
                {
                    return commands.SequenceEqual(commands.Reverse());
                }
    }
}
