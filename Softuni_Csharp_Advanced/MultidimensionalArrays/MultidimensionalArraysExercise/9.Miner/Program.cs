using System;
using System.Linq;

namespace _9.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int rowIndex = 0;
            int colIndex = 0;
            int collectedCoals = 0;
            int totalCoals = 0;
            string[] command = Console.ReadLine().Split();

            FillMatrix(matrix, matrixSize);


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        rowIndex = row;
                        colIndex = col;
                    }
                    if (matrix[row, col] == 'c')
                    {
                        totalCoals++;
                    }
                }
            }

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == "left")
                {
                    if (IsInside(matrix, rowIndex, colIndex - 1))
                    {
                        if (matrix[rowIndex, colIndex - 1] == '*' || matrix[rowIndex, colIndex - 1] == 's')
                        {
                            colIndex = colIndex - 1;
                            continue;
                        }
                        else if (matrix[rowIndex, colIndex - 1] == 'c')
                        {
                            colIndex = colIndex - 1;
                            collectedCoals++;
                            matrix[rowIndex, colIndex] = '*';
                            if (totalCoals == collectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        else if (matrix[rowIndex, colIndex - 1] == 'e')
                        {
                            colIndex = colIndex - 1;
                            Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (command[i] == "right")
                {
                    if (IsInside(matrix, rowIndex, colIndex + 1))
                    {
                        if (matrix[rowIndex, colIndex + 1] == '*' || matrix[rowIndex, colIndex + 1] == 's')
                        {
                            colIndex = colIndex + 1;
                            continue;
                        }
                        else if (matrix[rowIndex, colIndex + 1] == 'c')
                        {
                            colIndex = colIndex + 1;
                            collectedCoals++;
                            matrix[rowIndex, colIndex] = '*';
                            if (totalCoals == collectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        else if (matrix[rowIndex, colIndex + 1] == 'e')
                        {
                            colIndex = colIndex + 1;
                            Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (command[i] == "up")
                {
                    if (IsInside(matrix, rowIndex - 1, colIndex))
                    {
                        if (matrix[rowIndex - 1, colIndex] == '*' || matrix[rowIndex - 1, colIndex] == 's')
                        {
                            rowIndex = rowIndex - 1;
                            continue;
                        }
                        else if (matrix[rowIndex - 1, colIndex] == 'c')
                        {
                            rowIndex = rowIndex - 1;
                            collectedCoals++;
                            matrix[rowIndex, colIndex] = '*';
                            if (totalCoals == collectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        else if (matrix[rowIndex - 1, colIndex] == 'e')
                        {
                            rowIndex = rowIndex - 1;
                            Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }

                if (command[i] == "down")
                {
                    if (IsInside(matrix, rowIndex + 1, colIndex))
                    {
                        if (matrix[rowIndex + 1, colIndex] == '*' || matrix[rowIndex + 1, colIndex] == 's')
                        {
                            rowIndex = rowIndex + 1;
                            continue;
                        }
                        else if (matrix[rowIndex + 1, colIndex] == 'c')
                        {
                            rowIndex = rowIndex + 1;
                            collectedCoals++;
                            matrix[rowIndex, colIndex] = '*';
                            if (totalCoals == collectedCoals)
                            {
                                Console.WriteLine($"You collected all coals! ({rowIndex}, {colIndex})");
                                Environment.Exit(0);
                            }
                        }
                        else if (matrix[rowIndex + 1, colIndex] == 'e')
                        {
                            rowIndex = rowIndex + 1;
                            Console.WriteLine($"Game over! ({rowIndex}, {colIndex})");
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine($"{totalCoals-collectedCoals} coals left. ({rowIndex}, {colIndex})");

            static void FillMatrix(char[,] matrix, int matrixSise)
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
        }
    }
}
