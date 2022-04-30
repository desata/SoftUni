using System;

namespace _7.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] matrix = new long[n][];
            for (int row = 0; row < n; row++)
            {
                matrix[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    long sum = 0;
                    if (row - 1 >= 0 && col < matrix[row - 1].Length)
                    {
                        sum += matrix[row - 1][col];
                    }
                    if (row - 1 >= 0 && col - 1 >= 0)
                    {
                        sum += matrix[row - 1][col - 1];
                    }
                    if (sum == 0)
                    {
                        sum = 1;
                    }
                    matrix[row][col] = sum;
                }
            }
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}