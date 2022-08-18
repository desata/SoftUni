using System;
using System.Collections.Generic;

namespace _02._Beaver_at_Work
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            List<char> branches = new List<char>();
            int beaverRow = 0;
            int beaverCol = 0;
            int nextRow = 0;
            int nextCol = 0;
            int numberOfbranches = 0;
            int totalBranches = 0;
            bool isCollected = false;

            FillMatrix(matrix, matrixSize);
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        totalBranches++;
                    }
                }
            }


            string command = Console.ReadLine();


            while (command != "end")
            {
                if (command == "up")
                {
                    nextRow = beaverRow - 1;
                    nextCol = beaverCol;

                }
                else if (command == "down")
                {
                    nextRow = beaverRow + 1;
                    nextCol = beaverCol;
                }
                else if (command == "left")
                {
                    nextRow = beaverRow;
                    nextCol = beaverCol - 1;
                }
                else if (command == "right")
                {
                    nextRow = beaverRow;
                    nextCol = beaverCol + 1;
                }

                if (IsInside(matrix, nextRow, nextCol))
                {
                    matrix[beaverRow, beaverCol] = '-';

                    if (char.IsLower(matrix[nextRow, nextCol]))
                    {
                        branches.Add(matrix[nextRow, nextCol]);
                        matrix[nextRow, nextCol] = '-';
                        numberOfbranches++;
                        beaverRow = nextRow;
                        beaverCol = nextCol;

                    }
                    else if (matrix[nextRow, nextCol] == 'F')
                    {
                        matrix[nextRow, nextCol] = '-';

                        if (command == "up")
                        {
                            if (nextRow == 0)
                            {
                                beaverRow = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                beaverRow = 0;
                            }

                        }
                        else if (command == "down")
                        {
                            if (nextRow == matrix.GetLength(0) - 1)
                            {
                                beaverRow = 0;
                            }
                            else
                            {
                                beaverRow = matrix.GetLength(0) - 1;
                            }
                        }
                        else if (command == "left")
                        {
                            if (nextCol == 0)
                            {
                                beaverCol = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                beaverCol = 0;
                            }
                        }
                        else if (command == "right")
                        {
                            if (nextCol == matrix.GetLength(1) - 1)
                            {
                                beaverCol = 0;
                            }
                            else
                            {
                                beaverCol = matrix.GetLength(1) - 1;
                            }
                        }

                        if (char.IsLower(matrix[beaverRow, beaverCol]))
                        {
                            branches.Add(matrix[beaverRow, beaverCol]);
                            matrix[beaverRow, beaverCol] = '-';
                            numberOfbranches++;
                        }
                    }

                }
                else
                {
                    if (branches.Count > 0)
                    {
                        branches.RemoveAt(branches.Count - 1);
                        numberOfbranches--;
                        totalBranches--;
                    }
                }

                if (totalBranches == numberOfbranches && totalBranches > 0)
                {
                    isCollected = true;
                    break;
                }


                command = Console.ReadLine();
            }

            matrix[beaverRow, beaverCol] = 'B';

            if (isCollected)
            {

                Console.Write($"The Beaver successfully collect {totalBranches} wood branches: {string.Join(", ", branches)}.");
                Console.WriteLine();
            }
            else if (command == "end")
            {

                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranches - numberOfbranches} branches left.");
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
