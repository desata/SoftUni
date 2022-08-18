using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int playerOneShips = 0;
            int playerTwoShips = 0;
            int totalShips = 0;
            int currentRow = 0;
            int currentCol = 0;

            string[] command = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            FillMatrix(matrix, matrixSize);
            //count ships
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '>') //second player
                    {
                        playerTwoShips++;
                    }
                    else if (matrix[row, col] == '<')
                    {
                        playerOneShips++;
                    }
                }
            }
            totalShips = playerOneShips + playerTwoShips;

            for (int i = 0; i < command.Length; i++)
            {
                int[] arg = command[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                currentRow = arg[0];
                currentCol = arg[1];

                if (IsInside(matrix, currentRow, currentCol))
                {
                    if (matrix[currentRow, currentCol] == '>')
                    {
                        matrix[currentRow, currentCol] = 'X';
                        playerTwoShips--;
                    }
                    else if (matrix[currentRow, currentCol] == '<')
                    {
                        matrix[currentRow, currentCol] = 'X';
                        playerOneShips--;
                    }
                    else if (matrix[currentRow, currentCol] == '#')
                    {
                        matrix[currentRow, currentCol] = 'X';

                        for (int row = currentRow - 1; row <= currentRow + 1; row++)
                        {
                            for (int col = currentCol - 1; col <= currentCol + 1; col++)
                            {
                                if (IsInside(matrix, row, col))
                                {

                                    if (matrix[row, col] == '>')
                                    {
                                        playerTwoShips--;

                                    }
                                    else if (matrix[row, col] == '<')
                                    {
                                        playerOneShips--;
                                    }
                                    if (matrix[row, col] == '>' || matrix[row, col] == '<')
                                    {
                                        matrix[row, col] = 'X';
                                    }

                                }
                            }
                        }

                    }
                    if (playerOneShips <= 0)
                    {
                        break;
                    }
                    else if (playerTwoShips <= 0)
                    {
                        break;
                    }

                }
            }

            if (playerOneShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalShips - playerTwoShips} ships have been sunk in the battle.");
            }
            else if (playerTwoShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalShips - playerOneShips} ships have been sunk in the battle.");

            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }


        }
        static void FillMatrix(char[,] matrix, int matrixSize)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                }
            }
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


        private static bool IsInside(char[,] matrix, int givenRow, int givenCol)
        {
            return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                   givenCol >= 0 && givenCol < matrix.GetLength(1);
        }
    }
}
