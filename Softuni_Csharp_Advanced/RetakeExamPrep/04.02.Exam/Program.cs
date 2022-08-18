using System;

namespace _04._02.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int nextRow = 0;
            int nextCol = 0;
            int currentRow = 0;
            int currentCol = 0;
            int points = 0;


            FillMatrix(matrix, matrixSize);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    matrix[nextRow, nextCol] = 'M';
                    break;
                }
                else if (command == "up")
                {
                    nextRow = currentRow - 1;
                    nextCol = currentCol;

                }
                else if (command == "down")
                {
                    nextRow = currentRow + 1;
                    nextCol = currentCol;
                }
                else if (command == "left")
                {
                    nextRow = currentRow;
                    nextCol = currentCol - 1;
                }
                else if (command == "right")
                {
                    nextRow = currentRow;
                    nextCol = currentCol + 1;
                }

                matrix[currentRow, currentCol] = '-';

                if (IsInside(matrix, nextRow, nextCol))
                {

                    if (IsPoints(matrix, nextRow, nextCol))
                    {
                        points += (matrix[nextRow, nextCol]) - 48;

                        currentRow = nextRow;
                        currentCol = nextCol;

                    }
                    else if (IsSpecial(matrix, nextRow, nextCol))
                    {
                        points -= 3;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'S')
                                {
                                    currentRow = row;
                                    currentCol = col;
                                    matrix[row, col] = '-';
                                }
                            }
                        }
                    }
                    else
                    {
                        currentRow = nextRow;
                        currentCol = nextCol;
                    }
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                }
                if (points >= 25)
                {
                    matrix[nextRow, nextCol] = 'M';
                    break;
                }             
            }

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            Print(matrix);

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
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(char[,] matrix, int givenRow, int givenCol)
        {
            return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                   givenCol >= 0 && givenCol < matrix.GetLength(1);
        }

        private static bool IsPoints(char[,] matrix, int givenRow, int givenCol)
        {
            if (Char.IsDigit(matrix[givenRow, givenCol]))
            {
                return true;
            }
            return false;
        }

        private static bool IsSpecial(char[,] matrix, int givenRow, int givenCol)
        {
            if (matrix[givenRow, givenCol] == 'S')
            {
                matrix[givenRow, givenCol] = '-';
                return true;
            }
            return false;
        }
    }
}
