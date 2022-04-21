using System;

namespace SumOfChairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char letter;
            int totalSum = 0;

            for (int i = 1; i <= n; i++)
            {
                letter = char.Parse(Console.ReadLine());
                int letterN = (int)(letter);
                totalSum += letterN; 

            }


            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
