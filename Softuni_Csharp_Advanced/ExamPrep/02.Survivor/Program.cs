using System;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixSize][];
            int collectedCoinsByYou = 0;
            int collectedCoinsByOpponent = 0;

            int nextRow = 0;
            int nextCol = 0;

            FillMatrix(matrix, matrixSize);

            string[] command = Console.ReadLine().Split();

            while (command[0] != "Gong")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);

                if (command[0] == "Find")
                {
                    if (IsInside(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedCoinsByYou++;
                            matrix[row][col] = '-';
                        }
                    }

                }
                else if (command[0] == "Opponent")
                {
                    string direction = command[3];

                    if (IsInside(matrix, row, col))
                    {
                        if (matrix[row][col] == 'T')
                        {
                            collectedCoinsByOpponent++;
                            matrix[row][col] = '-';

                        }
                        for (int i = 0; i < 3; i++)
                        {
                            
                            if (direction == "up")
                            {
                                nextRow = row - 1;
                                nextCol = col;

                            }
                            else if (direction == "down")
                            {
                                nextRow = row + 1;
                                nextCol = col;
                            }
                            else if (direction == "left")
                            {
                                nextRow = row;
                                nextCol = col - 1;
                            }
                            else if (direction == "right")
                            {
                                nextRow = row;
                                nextCol = col + 1;
                            }
                            if (IsInside(matrix, nextRow, nextCol))
                            {
                                row = nextRow;
                                col = nextCol;

                                if (matrix[row][col] == 'T')
                                {
                                    collectedCoinsByOpponent++;
                                    matrix[row][col] = '-';
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }


                command = Console.ReadLine().Split();
            }


            Print(matrix);

            Console.WriteLine($"Collected tokens: {collectedCoinsByYou}");
            Console.WriteLine($"Opponent's tokens: {collectedCoinsByOpponent}");


            static void FillMatrix(char[][] matrix, int matrixSise)
            {
                for (int row = 0; row < matrixSise; row++)
                {
                    char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();

                    matrix[row] = input;
                }
            }

            static bool IsInside(char[][] matrix, int givenRow, int givenCol)
            {
                return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                       givenCol >= 0 && givenCol < matrix[givenRow].Length;
            }

            static void Print(char[][] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    {
                        //Console.WriteLine(matrix[row]);
                        Console.WriteLine(String.Join(" ", matrix[row]));
                    }

                }
            }
        }
    }
}
