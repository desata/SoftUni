using System;

namespace _07.NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method that receives a single integer n and prints an NxN matrix using this number as a filler.

            int inputNumber = int.Parse(Console.ReadLine());

            DrawMatrixNxN(inputNumber);

        }
        static int DrawMatrixNxN(int number)
        {
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write($"{number} ");

                }
                Console.WriteLine("");
            }
            return number;
        }
    }
}
