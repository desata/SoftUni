using System;

namespace _02._Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int nextRow  = 0;
            int nextCol = 0;
            int currentRow = 0;
            int currentCol = 0;
            int moneyCollected = 0;
            bool HasEnoughMoney = false;

            //Clients -> digits
            //pillars -> O

            FillMatrix(matrix, matrixSize);

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

            while (true)
            {
                string command = Console.ReadLine();

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

                matrix[currentRow, currentCol] = '-';

                if (IsInside(matrix, nextRow, nextCol))
                {

                    if (IsClient(matrix, nextRow, nextCol))
                    {
                        moneyCollected += (matrix[nextRow, nextCol]) - 48;

                        currentRow = nextRow;
                        currentCol = nextCol;


                    }
                    else if (IsPillar(matrix, nextRow, nextCol))
                    {
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'O')
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
                    break;
                }
                
                if (moneyCollected >= 50)
                {
                    HasEnoughMoney = true;
                    break;
                }
            }

            if (HasEnoughMoney)
            {
                matrix[currentRow, currentCol] = 'S';
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {moneyCollected}");

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

        private static bool IsPillar(char[,] matrix, int givenRow, int givenCol)
        {
            if (matrix[givenRow, givenCol] == 'O')
            {
                matrix[givenRow, givenCol] = '-';
                return true;
            }
            return false;
        }

        private static bool IsClient(char[,] matrix, int givenRow, int givenCol)
        {
            if (Char.IsDigit(matrix[givenRow, givenCol]))
            {
                return true;
            }

            return false;

        }


    }
}
