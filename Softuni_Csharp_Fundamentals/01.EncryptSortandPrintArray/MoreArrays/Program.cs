using System;

namespace MoreArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //On the first line, you will always receive the number of strings you have to read.
            int numberOfStrings = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberOfStrings];
            string words = "";
            string vowel = "a e u i o A E U I O";
            string consonant = "bBcCdDfFgGhHjJkKlLmMnNpPqQrRsStTvVwWxXyYzZ";


            //Write a program that reads a sequence of strings from the console.
            for (int i = 0; i < numberOfStrings; i++)
            {
                words = Console.ReadLine();
                int wordLength = words.Length;
                    int resultV = 0;
                    int resultC = 0;
                int result = 0;
                foreach (char word in words)
                {

                    int character = (int)word;
                    if (vowel.Contains(word))
                    {
                        resultV += character * wordLength;
                    }
                    if (consonant.Contains(word))
                    {
                        resultC += character / wordLength;
                    }
                
                    result = resultC + resultV;
                    numbers[i] = result;
                }

            }
            Array.Sort(numbers);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

        }
    }
}
