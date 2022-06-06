using System;
using System.Linq;

namespace _7.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int n = int.Parse(Console.ReadLine());

            char[,] board = new char[n, n];

            for (int rows = 0; rows < board.GetLength(0); rows++)
            {
                string input = Console.ReadLine();

                for (int cols = 0; cols < board.GetLength(1); cols++)
                {
                    board[rows, cols] = input[cols];
                }
            }

            int removed = 0;

            while (true)
            {
                int maxAttacs = 0;
                int kRow = 0;
                int kCol = 0;

                for (int rows = 0; rows < board.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < board.GetLength(1); cols++)
                    {
                        if (board[rows, cols] != 'K')
                        {
                            continue;
                        }
                        int currentAttacs = 0;
                        if (IsInside(board, rows - 2, cols + 1) && board[rows - 2, cols + 1] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows - 2, cols - 1) && board[rows - 2, cols - 1] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows - 1, cols + 2) && board[rows - 1, cols + 2] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows - 1, cols - 2) && board[rows - 1, cols - 2] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows + 2, cols + 1) && board[rows + 2, cols + 1] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows + 2, cols - 1) && board[rows + 2, cols - 1] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows + 1, cols + 2) && board[rows + 1, cols + 2] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (IsInside(board, rows + 1, cols - 2) && board[rows + 1, cols - 2] == 'K')
                        {
                            currentAttacs++;
                        }
                        if (currentAttacs > maxAttacs)
                        {
                            maxAttacs = currentAttacs;
                            kRow = rows;
                            kCol = cols;
                        }
                    }
                }
                if (maxAttacs == 0)
                {
                    Console.WriteLine(removed);
                    break;
                }
                else
                {
                    board[kRow, kCol] = '0';
                    removed++;
                }
            }

        }

        private static bool IsInside(char[,] board, int row, int col)
        {
            return row >= 0 && col >= 0 && row < board.GetLength(0) && col < board.GetLength(1);
        }
    }
}
