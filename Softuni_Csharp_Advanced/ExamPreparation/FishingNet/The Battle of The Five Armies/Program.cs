using System;

namespace The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int matrixSize = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixSize][];
            int currRow = 0;
            int currCol = 0;
            bool IsWining = false;
            FillMatrix(matrix, matrixSize);

            //until the army dies, or reaches the throne, you will receive a move command and spawn row and column.
            //“up”, “down”, “left”, “right”

            //FindArmy
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'A')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string direction = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                matrix[row][col] = 'O';
                armor -= 1;

                if (direction == "up" && (IsInside(matrix, currRow - 1, currCol)))
                {
                    matrix[currRow][currCol] = '-';

                    if (matrix[currRow - 1][currCol] == 'O')
                    {
                        currRow -= 1;
                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[currRow][currCol] = 'X';                            
                            IsWining = false;
                            break;
                        }
                        else
                        {
                            matrix[currRow][currCol] = 'A';
                        }
                    }
                    else if (matrix[currRow - 1][currCol] == 'M')
                    {
                        currRow -= 1;
                        matrix[currRow][currCol] = '-';
                        IsWining = true;
                        break;
                    }
                    else
                    {

                        currRow -= 1;
                        matrix[currRow][currCol] = 'A';
                    }

                }
                else if (direction == "down" && (IsInside(matrix, currRow+1, currCol)))
                {
                    matrix[currRow][currCol] = '-';

                    if (matrix[currRow + 1][currCol] == 'O')
                    {
                        currRow += 1;
                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[currRow][currCol] = 'X';
                            IsWining = false;
                            break;
                        }
                        else
                        {
                            matrix[currRow][currCol] = 'A';
                        }
                    }
                    else if (matrix[currRow + 1][currCol] == 'M')
                    {
                        currRow += 1;
                        matrix[currRow][currCol] = '-';
                        IsWining = true;
                        break;
                    }
                    else
                    {

                        currRow += 1;
                        matrix[currRow][currCol] = 'A';
                    }

                }
                else if (direction == "left" && (IsInside(matrix, currRow, currCol-1)))
                {
                    matrix[currRow][currCol] = '-';

                    if (matrix[currRow][currCol -1] == 'O')
                    {
                        currCol -= 1;
                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[currRow][currCol] = 'X';
                            IsWining = false;
                            break;
                        }
                        else
                        {
                            matrix[currRow][currCol] = 'A';
                        }
                    }
                    else if (matrix[currRow][currCol-1] == 'M')
                    {
                        currCol -= 1;
                        matrix[currRow][currCol] = '-';
                        IsWining = true;
                        break;
                    }
                    else
                    {

                        currCol -= 1;
                        matrix[currRow][currCol] = 'A';
                    }

                }
                else if (direction == "right" && (IsInside(matrix, currRow, currCol+1)))
                {
                    matrix[currRow][currCol] = '-';

                    if (matrix[currRow][currCol + 1] == 'O')
                    {
                        currCol += 1;
                        armor -= 2;
                        if (armor <= 0)
                        {
                            matrix[currRow][currCol] = 'X';
                            IsWining = false;
                            break;
                        }
                        else
                        {
                            matrix[currRow][currCol] = 'A';
                        }
                    }
                    else if (matrix[currRow][currCol + 1] == 'M')
                    {
                        currCol += 1;
                        matrix[currRow][currCol] = '-';
                        IsWining = true;
                        break;
                    }
                    else
                    {

                        currCol += 1;
                        matrix[currRow][currCol] = 'A';
                    }
                }
                if(!IsInside(matrix, currRow - 1, currCol) || !IsInside(matrix, currRow + 1, currCol)
                    || !IsInside(matrix, currRow, currCol -1) || !IsInside(matrix, currRow, currCol +1))
                {
                    continue;
                }
            }

            //Output
            if (!IsWining)
            {
                Console.WriteLine($"The army was defeated at {currRow};{currCol}.");
            }
            else
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }

            Print(matrix);

        }

        static void FillMatrix(char[][] matrix, int matrixSise)
        {
            for (int row = 0; row < matrixSise; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                matrix[row] = input;
            }
        }

        private static bool IsInside(char[][] matrix, int givenRow, int givenCol)
        {
            return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                   givenCol >= 0 && givenCol < matrix[givenRow].Length;
        }

        static void Print(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                {
                    Console.WriteLine(matrix[row]);
                }
               
            }
        }
    }
}
