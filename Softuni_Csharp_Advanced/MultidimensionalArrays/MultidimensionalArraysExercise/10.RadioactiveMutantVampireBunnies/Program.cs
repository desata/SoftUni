using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            char[,] matrix = new char[rows, cols];
            FillMatrix(matrix, rows, cols);
            char[] input = Console.ReadLine().ToCharArray();
            int playerRow = 0;
            int playerCol = 0;
            int nextRow = 0;
            int nextCol = 0;
            bool isDead = false;
            bool hasWon = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                //"R", "L", "U", "D"

                if (input[i] == 'R')
                {
                    nextRow = 0;
                    nextCol = 1;
                }
                else if (input[i] == 'L')
                {
                    nextRow = 0;
                    nextCol = -1;
                }
                else if (input[i] == 'U')
                {
                    nextRow = -1;
                    nextCol = 0;
                }
                else if (input[i] == 'D')
                {
                    nextRow = 1;
                    nextCol = 0;
                }

                if (!IsInside(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    matrix[playerRow, playerCol] = '.';
                    hasWon = true;
                }

                if (IsInside(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    if (matrix[playerRow + nextRow, playerCol + nextCol] == '.')
                    {
                        matrix[playerRow, playerCol] = matrix[playerRow + nextRow, playerCol + nextCol];
                        playerRow = playerRow + nextRow;
                        playerCol = playerCol + nextCol;
                        matrix[playerRow, playerCol] = 'P';


                    }
                    else if (matrix[playerRow + nextRow, playerCol + nextCol] == 'B')
                    {
                        isDead = true;
                    }

                }
                List<int[]> bunnies = new List<int[]>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row,col] == 'B')
                        {
                            bunnies.Add(new int[] { row, col });
                        }
                    }
                }

                foreach (var bun in bunnies)
                {
                    int bunnieRow = bun[0];
                    int bunnieCol = bun[1];

                    if (IsInside(matrix, bunnieRow - 1, bunnieCol))
                    {
                        if (matrix[bunnieRow - 1, bunnieCol] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnieRow - 1, bunnieCol] = 'B';

                    }
                    if (IsInside(matrix, bunnieRow + 1, bunnieCol))
                    {
                        if (matrix[bunnieRow + 1, bunnieCol] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnieRow + 1, bunnieCol] = 'B';

                    }
                    if (IsInside(matrix, bunnieRow, bunnieCol - 1))
                    {
                        if (matrix[bunnieRow, bunnieCol - 1] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnieRow, bunnieCol - 1] = 'B';

                    }
                    if (IsInside(matrix, bunnieRow, bunnieCol + 1))
                    {
                        if (matrix[bunnieRow, bunnieCol + 1] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnieRow, bunnieCol + 1] = 'B';

                    }
                }

            }

            Print(matrix);

            if (isDead)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
            else if (hasWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            //won or dead + row,col

            static void FillMatrix(char[,] matrix, int rows, int cols)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    char[] input = Console.ReadLine().ToCharArray();

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
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
