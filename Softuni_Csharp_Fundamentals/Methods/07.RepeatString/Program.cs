using System;

namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method that receives two parameters:
//•	A string
//•	A number n(integer) represents how many times the string will be repeated
// The method should return a new string, containing the initial one, repeated n times without space. 

            string word = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());

            PrintRepeat(word, repeat);


        }
        static string PrintRepeat(string word, int repeat)
        {
            for (int i = 0; i < repeat; i++)
            {
                Console.Write(word);
            }
            return word;
        }
    }
}
