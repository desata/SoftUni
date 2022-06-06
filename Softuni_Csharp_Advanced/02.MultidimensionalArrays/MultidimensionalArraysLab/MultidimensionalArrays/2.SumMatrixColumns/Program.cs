using System;
using System.Linq;

namespace _2.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a matrix from the console and prints the sum for each column.
            //On the first line, you will get matrix rows. On the next rows lines, you will get elements for each column separated with a space. 

            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[,] matrix = new int[rows, cols];
            int sumColumn = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] rowArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    sumColumn += matrix[row, col];
                }
                Console.WriteLine(sumColumn);
                sumColumn = 0;
            }

        }
    }
}
