using System;

namespace _02.WallDestroyer
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            int currentRow = 0;
            int currentCol = 0;
            int countOfHoles = 0;
            int countOfRods = 0;
            bool isElectrocuted = false;

            FillMatrix(matrix, matrixSize);

            //Find position
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        currentRow = row;
                        currentCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "up")
                {
                    if (IsInside(matrix, currentRow - 1, currentCol))
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow -= 1;
                        countOfHoles++;

                    }
                }
                else if (command == "down")
                {
                    if (IsInside(matrix, currentRow + 1, currentCol))
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentRow += 1;
                        countOfHoles++;
                    }
                }
                else if (command == "left")
                {
                    if (IsInside(matrix, currentRow, currentCol - 1))
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol -= 1;
                        countOfHoles++;
                    }
                }
                else if (command == "right")
                {
                    if (IsInside(matrix, currentRow, currentCol + 1))
                    {
                        matrix[currentRow, currentCol] = '*';
                        currentCol += 1;
                        countOfHoles++;
                    }
                }
                //fields
                if (matrix[currentRow, currentCol] == '*')
                {
                    Console.WriteLine($"The wall is already destroyed at position [{currentRow}, {currentCol}]!");
                    countOfHoles--;
                }
                else if (matrix[currentRow, currentCol] == 'R')
                {
                    Console.WriteLine("Vanko hit a rod!");
                    countOfRods++;
                    countOfHoles--;
                    if (command == "up")
                    {
                        currentRow++;
                    }
                    else if (command == "down")
                    {
                        currentRow -= 1;
                    }
                    else if (command == "left")
                    {
                        currentCol++;
                    }
                    else if (command == "right")
                    {
                        currentCol -= 1;
                    }
                    
                }
                else if (matrix[currentRow, currentCol] == 'C')
                {
                    
                    isElectrocuted = true;
                    break;
                }

                command = Console.ReadLine();
            }

            countOfHoles++;
            matrix[currentRow, currentCol] = 'V';

            if (isElectrocuted)
            {
                matrix[currentRow, currentCol] = 'E';
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countOfHoles} hole(s) and he hit only {countOfRods} rod(s).");
            }


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

            static bool IsInside(char[,] matrix, int givenRow, int givenCol)
            {
                return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                       givenCol >= 0 && givenCol < matrix.GetLength(1);
            }

        }


    }
}
