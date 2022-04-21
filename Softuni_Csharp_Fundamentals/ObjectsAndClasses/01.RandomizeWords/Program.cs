using System;

namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will be given a string that will contain words separated by a single space.
            //Randomize their order and print each word on a new line.

            string[] words = Console.ReadLine().Split(' ');

            Random random = new Random();

            for (int pos1 = 0; pos1 < words.Length; pos1++)

            {

                int pos2 = random.Next(0, words.Length);

                string currentWord = words[pos1];
                words[pos1] = words[pos2];  
                words[pos2] = currentWord;


            }
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

           

        }
    }
}
