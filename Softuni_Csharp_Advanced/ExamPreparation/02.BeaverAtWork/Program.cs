using System;
using System.Linq;

namespace _02.BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                int matrixSize = int.Parse(Console.ReadLine());
                int[,] matrix = new int[matrixSize, matrixSize];

                FillMatrix(matrix, matrixSize);
                //TODO

                //up", "down", "left", and "right". These will be the commands that you'll receive





                //print
                Print(matrix);
            }




            static void FillMatrix(int[,] matrix, int matrixSise)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = input[col];
                    }
                }
            }
            static void Print(int[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
            static bool IsInside(char[,] matrix, int givenRow, int givenCol)
            {
                return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                       givenCol >= 0 && givenCol < matrix.GetLength(1);
            }
        }
    }
}
