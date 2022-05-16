using System;
using System.Linq;

namespace _2.SquaresinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] matixSize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rows = matixSize[0];
            int cols = matixSize[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowArray = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            int sumTwoByTwo = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1] && matrix[row, col] == matrix[row, col + 1])
                    {
                        sumTwoByTwo++;
                    }

                }
            }

            Console.WriteLine(sumTwoByTwo);

        }
    }
}
