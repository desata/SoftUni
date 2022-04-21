using System;

namespace ArrayMore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads a sequence of strings from the console. Encrypt every string by summing:
            //The code of each vowel multiplied by the string length
            //The code of each consonant divided by the string length
            //Sort the number sequence in ascending order and print it on the console.
            //On the first line, you will always receive the number of strings you have to read.
            //Peter = 1071
            //e 101+101*5 = 
            //P 80
            //t 116
            //r 114

            int numberOfWords = int.Parse(Console.ReadLine());
            string[] words = new string[numberOfWords];
            char[] vowels = { 'a', 'A', 'e', 'E', 'o', 'O', 'u', 'U', 'i', 'I', 'y', 'Y' };
            int sum = 0;
            int sum1 = 0;
            int sum2 = 0;
            int sumTotal = 0;

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = Console.ReadLine();

            }

            foreach (string word in words)
            {
                char[] chars = word.ToCharArray();


                foreach (char cha in chars)
                {
                    foreach (char vowel in vowels)
                    {
                        if (chars == vowels)
                        {
                            //Console.WriteLine((int)cha);
                            sum1 += (int)cha;

                            //sum1 += sum;

                        }
                        else
                        {
                            sum2 += (int)cha;
                            //sum2 += sum;

                        }
                        Console.WriteLine(sum1);
                        Console.WriteLine(sum2);
                        // sum1 = sum1 * chars.Length;
                        //sum2 = sum2 / chars.Length;
                        sumTotal = sum1 + sum2;
                    }
                }

                Console.WriteLine($"{sumTotal}");

            }
            //Console.WriteLine(String.Join("\n", words));
            //Console.WriteLine("");
            //Console.WriteLine(sum);
            //Console.WriteLine(sum2);
            //Console.WriteLine(sum1);
        }
    }
}
