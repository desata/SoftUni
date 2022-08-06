using System;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];
            int goldCoins = 0;
            int officerRow = 0;
            int officerCol = 0;
            int nextRow = 0;
            int nextCol = 0;
            bool IsOutside = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'A')
                    {
                        officerRow = row;
                        officerCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (true)
            {

                if (command == "up")
                {
                    nextRow = officerRow - 1;
                    nextCol = officerCol;

                }
                else if (command == "down")
                {
                    nextRow = officerRow + 1;
                    nextCol = officerCol;
                }
                else if (command == "left")
                {
                    nextRow = officerRow;
                    nextCol = officerCol -1;
                }
                else if (command == "right")
                {
                    nextRow = officerRow;
                    nextCol = officerCol + 1;
                }

                matrix[officerRow, officerCol] = '-';

                if (IsInside(matrix, nextRow, nextCol))
                {

                    if (IsGold(matrix, nextRow, nextCol))
                    {
                        goldCoins += (matrix[nextRow, nextCol]) - 48;

                        officerRow = nextRow;
                        officerCol = nextCol;


                    }
                    else if (IsMirror(matrix, nextRow, nextCol))
                    {
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (matrix[row, col] == 'M')
                                {
                                    officerRow = row;
                                    officerCol = col;
                                    matrix[row, col] = '-';
                                }
                            }
                        }
                    }
                    else
                    {
                        officerRow = nextRow;
                        officerCol = nextCol;
                    }

                }
                else
                {

                    IsOutside = true;
                    break;
                }


                if (goldCoins >= 65)
                {
                    matrix[nextRow, nextCol] = 'A';
                    break;
                }

                command = Console.ReadLine();
            }

            if (IsOutside)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else if (goldCoins >= 65)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");

            }
            Console.WriteLine($"The king paid {goldCoins} gold coins.");


            Print(matrix);

        }

        private static bool IsMirror(char[,] matrix, int givenRow, int givenCol)
        {
            if (matrix[givenRow, givenCol] == 'M')
            {
                matrix[givenRow, givenCol] = '-';
                return true;
            }
            return false;
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

        private static bool IsGold(char[,] matrix, int givenRow, int givenCol)
        {
            if (Char.IsDigit(matrix[givenRow, givenCol]))
            {
                return true;
            }
            
                return false;
            
        }
    }
}

