using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will receive a single string.
            //Create a method that prints the character found at its middle.
            //If the length of the string is even there are two middle characters.

            string word = Console.ReadLine();
            PrintResult(word);
                        
        }

        static string PrintResult(string word)
        {
            char[] wordCh = word.ToCharArray();
            int wordLegth = word.Length / 2;
            string result = " ";

            if (word.Length % 2 == 0)
            {

                result = ($"{wordCh[wordLegth-1]}{wordCh[wordLegth]}");
               
            }
            else
            {

                result = ($"{wordCh[wordLegth]}");
                
            }
            Console.WriteLine(result);    
            return result;
        }

    }
}
