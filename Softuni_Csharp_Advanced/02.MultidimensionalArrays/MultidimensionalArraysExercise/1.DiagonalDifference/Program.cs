using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that finds the difference between the sums of the square matrix diagonals (absolute value).
            //•	Print the absolute difference between the sums of the primary and the secondary diagonal

            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sumPrime = 0;
            int sumSec = 0;

            for (int row = 0; row < n; row++)
            {
                int[] rowArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                
                sumPrime += matrix[row, row];
                sumSec += matrix[row, matrix.GetLength(0) -1 - row];
               
            }
            Console.WriteLine(Math.Abs(sumPrime-sumSec));
        }
    }
}
