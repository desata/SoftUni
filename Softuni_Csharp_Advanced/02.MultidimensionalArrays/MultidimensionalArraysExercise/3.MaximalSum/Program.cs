using System;
using System.Linq;

namespace _3.MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matixSize[0];
            int cols = matixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowArray = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            int maximalSum = 0;
            int sum = 0;
            int initRow = 0;
            int initCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    sum = matrix[row, col] + matrix[row, col+1]+ matrix[row, col+2]
                        + matrix[row+ 1, col] + matrix[row+1, col + 1] + matrix[row+1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maximalSum)
                    {
                        maximalSum = sum;
                        initRow = row;
                        initCol = col;
                    }

                }
            }

            Console.WriteLine($"Sum = {maximalSum}");

            for (int row = initRow; row < initRow + 3; row++)
            {
                for (int col = initCol; col < initCol+3; col++)
                {
                    Console.Write(matrix[row,col] + " ");

                }
                Console.WriteLine();
            }

        }
    }
}
