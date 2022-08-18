using System;

namespace _02._Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            int currentRow = 0;
            int currentCol = 0;
            int nextRow = 0;
            int nextCol = 0;
            int CountOfFlowers = 0;
            bool HasWon = false;
            bool IsOutside = false;

            FillMatrix(matrix, matrixSize);

            //Find position
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
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
                    if (matrix[nextRow, nextCol] == 'f')
                    {
                        currentRow = nextRow;
                        currentCol = nextCol;
                        CountOfFlowers++;
                    }
                    else if (matrix[nextRow, nextCol] == 'O')
                    {
                        matrix[nextRow, nextCol] = '.';

                        if (command == "up")
                        {
                            nextRow -= 1;

                        }
                        else if (command == "down")
                        {  
                             nextRow += 1;
                            
                        }
                        else if (command == "left")
                        {
                             nextCol -= 1;
                        }
                        else if (command == "right")
                        {
                             nextCol += 1;
                        }
                        if (matrix[nextRow, nextCol] == 'f')
                        {
                            CountOfFlowers++;
                        }
                        currentRow = nextRow;
                        currentCol = nextCol;
                    }
                    else
                    {
                        currentRow = nextRow;
                        currentCol = nextCol;
                    }
                }
                else
                {
                    IsOutside = true;
                    break;
                }

                

                command = Console.ReadLine();
            }
            matrix[currentRow, currentCol] = 'B';

            if (CountOfFlowers >= 5)
            {
                HasWon = true;
                
            }


            if (IsOutside)
            {
                matrix[currentRow, currentCol] = '.';
                Console.WriteLine("The bee got lost!");
            }

            if (!HasWon)
            {
                
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - CountOfFlowers} flowers more");
            }
            else
            {
                
                Console.WriteLine($"Great job, the bee managed to pollinate {CountOfFlowers} flowers!");
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
