using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            string[] letters = Console.ReadLine().Split();
            char[] command = letters.Select(char.Parse).ToArray();
            FillMatrix(matrix, rows, cols);
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            for (int i = 0; i < command.Length; i++)
            {
                //"R", "L", "U", "D"
                // matrix[playerRow, playerCol] =
                int nextRow = 0;
                int nextCol = 0;
                if (command[i] == 'R')
                {
                    nextRow = playerRow;
                    nextCol = playerCol+1;
                }
                else if (command[i] == 'L')
                {
                    nextRow = playerRow;
                    nextCol = playerCol - 1;
                }
                else if (command[i] == 'U')
                {
                    nextRow = playerRow - 1;
                    nextCol = playerCol;
                }
                else if (command[i] == 'D')
                {
                    nextRow = playerRow + 1;
                    nextCol = playerCol;
                }

                if (matrix[nextRow, nextCol] == '.')
                {
                    matrix[nextRow, nextCol] = matrix[playerRow, playerCol];

                    matrix[playerRow, playerCol] = '.';
                }
            }


            Print(matrix);
            //won or dead + row,col

            static void FillMatrix(char[,] matrix, int rows, int cols)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = input[col];
                    }
                }
            }

            static bool IsInside(char[,] matrix, int row, int col)
            {
                return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
            }

            static void Print(char[,] matrix)
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
        }
    }
}
