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

            int playerRow = 0;
            int playerCol = 0;

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
            string input = Console.ReadLine();

            bool isDead = false;
            bool hasWon = false;

            foreach (var direction in input)
            {
                int nextRow = 0;
                int nextCol = 0;

                switch (direction)
                {
                    //"R", "L", "U", "D"

                    case 'R':
                        nextCol = 1;
                        break;

                    case 'L':

                        nextCol = -1;
                        break;

                    case 'U':
                        nextRow = -1;
                        break;

                    case 'D':
                        nextRow = 1;
                        break;

                }

                matrix[playerRow, playerCol] = '.';

                if (!IsInside(matrix, playerRow + nextRow, playerCol + nextCol))
                {
                    
                    hasWon = true;
                }

                else
                {
                    playerRow += nextRow;
                    playerCol += nextCol;
                }

                if (matrix[playerRow, playerCol] == 'B')
                {
                    isDead = true;

                }
                else if (!hasWon)
                {
                    matrix[playerRow, playerCol] = 'P';
                }

                List<int[]> bunnies = new List<int[]>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
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
                if (isDead || hasWon)
                {
                    Print(matrix);
                }

                if (isDead)
                {
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
                else if (hasWon)
                {
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }
            }

        }

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
