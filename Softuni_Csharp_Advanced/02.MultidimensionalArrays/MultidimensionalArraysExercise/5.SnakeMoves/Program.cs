using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int[] matrixSize = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            string snake = Console.ReadLine();
            char[,] matrix = new char[rows, cols];
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }
                    }

                }
                else
                {
                    for (int col = matrix.GetLength(1)-1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[counter++];

                        if (counter == snake.Length)
                        {
                            counter = 0;
                        }

                    }
 
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }


        }
    }
}
