using System;

namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method that takes two strings as arguments and returns
            //the sum of their character codes multiplied (multiply str1[0] with str2[0] and add to the total sum).
            //Then continue with the next two characters. If one of the strings is longer than the other,
            //add the remaining character codes to the total sum without multiplication.

                var input = Console.ReadLine().Split();

                var firstString = input[0];
                var secondString = input[1];

                var longestWord = firstString;
                var shortestWord = secondString;

                if (firstString.Length < secondString.Length)
                {
                    longestWord = secondString;
                    shortestWord = firstString;
                }
                var total = CharMultiply(longestWord, shortestWord);
                Console.WriteLine(total);
            }
            public static int CharMultiply(string longestWord, string shortestWord)
            {
                var sum = 0;

                for (int i = 0; i < shortestWord.Length; i++)
                {
                    var multiply = longestWord[i] * shortestWord[i];
                    sum += multiply;
                }

                for (int i = shortestWord.Length; i < longestWord.Length; i++)
                {
                    sum += longestWord[i];
                }
                return sum;
            }
        }
}
