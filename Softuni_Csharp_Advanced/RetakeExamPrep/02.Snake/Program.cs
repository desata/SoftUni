using System;

namespace _02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //12:21 - 12:56

            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            int currentRow = 0;
            int currentCol = 0;
            int nextRow = 0;
            int nextCol = 0;
            int countOfFood = 0;
            bool HasWin = false;

            FillMatrix(matrix, matrixSize);

            //Find position
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (true)
            {

                if (command == "up")
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

                matrix[currentRow, currentCol] = '.';

                if (IsInside(matrix, nextRow, nextCol))
                {
                    if (matrix[nextRow, nextCol] == '*')
                    {
                        currentRow = nextRow;
                        currentCol = nextCol;
                        countOfFood++;
                    }
                    else if (IsBurrow(matrix, nextRow, nextCol))
                    {
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'B')
                                {
                                    currentRow = row;
                                    currentCol = col;
                                    matrix[row, col] = '.';
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
                    break;
                }

                if (countOfFood >= 10)
                {
                    HasWin = true;
                    break;
                }

                command = Console.ReadLine();
            }

            if (!HasWin)
            {
                Console.WriteLine("Game over!");
            }
            else
            {
                matrix[currentRow, currentCol] = 'S';
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {countOfFood}");




            PrintMatrix(matrix);

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

            static void PrintMatrix(char[,] matrix)
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

            static bool IsBurrow(char[,] matrix, int givenRow, int givenCol)
            {
                if (matrix[givenRow, givenCol] == 'B')
                {
                    matrix[givenRow, givenCol] = '.';
                    return true;
                }
                return false;
            }

            static bool IsInside(char[,] matrix, int givenRow, int givenCol)
            {
                return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                       givenCol >= 0 && givenCol < matrix.GetLength(1);
            }
        }
    }
}
