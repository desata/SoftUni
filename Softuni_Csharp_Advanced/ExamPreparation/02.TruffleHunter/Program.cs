using System;
using System.Linq;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Black truffle - 'B'
            //•	Summer truffle -'S'
            //•	White truffle - 'W'

            //On the first line, the size of the forest is given, which will be a matrix with a square shape.
            //Then for each row, you will receive the truffles. All of the empty positions will be marked with a '-' (dash).

            int matrixSize = int.Parse(Console.ReadLine());
            string[,] matrix = new string[matrixSize, matrixSize];
            int blackTruffles = 0;
            int summerTruffles = 0;
            int whiteTruffles = 0;
            int boarTruffles = 0;


            FillMatrix(matrix, matrixSize);

            //commands - commands

            while (true)
            {
                string command = Console.ReadLine();
                int row = 0;
                int col = 0;

                if (command.Split()[0] == "Collect")
                { //- Peter goes to the given place in the forest and collect the truffle if it exists.
                  //When he collects a truffle, the cell’s should be change to a dash ('-').
                    row = int.Parse(command.Split()[1]);
                    col = int.Parse(command.Split()[2]);
                    if (matrix[row, col] == "B")
                    {
                        blackTruffles++;
                    }
                    else if (matrix[row, col] == "S")
                    {
                        summerTruffles++;
                    }
                    else if (matrix[row, col] == "W")
                    {
                        whiteTruffles++;
                    }
                    matrix[row, col] = "-";

                }
                else if (command.Split()[0] == "Wild_Boar")
                {
                    row = int.Parse(command.Split()[1]);
                    col = int.Parse(command.Split()[2]);
                    string direction = command.Split()[3];

                    //"Wild_Boar {row} {col} {direction}" - a wild boar appeirs in the given coordinates (they will be always valid) in the forest and it goes all the way in that direction. Which means the wild boar, goes from the given cell to the last cell in the given direction. It eats the given cell, skips the next, and eats the next one, if there is a truffle there, and so on until it reaches the last cell in the given direction.
                    if (direction == "up")
                    {
                        for (int currRow = row; currRow >= 0; currRow -= 2)
                        {

                            if (IsTruffle(matrix, currRow, col))
                            {
                                boarTruffles++;
                            }
                            matrix[currRow, col] = "-";
                        }

                    }
                    else if (direction == "down")
                    {
                        for (int currRow = row; currRow < matrix.GetLength(0); currRow += 2)
                        {

                            if (IsTruffle(matrix, currRow, col))
                            {
                                boarTruffles++;
                            }
                            matrix[currRow, col] = "-";
                        }
                    }
                    
                    else if (direction == "left")
                    {
                        for (int currCol = col; currCol >= 0; currCol -= 2)
                        {

                            if (IsTruffle(matrix, row, currCol))
                            {
                                boarTruffles++;
                            }
                            matrix[row, currCol] = "-";
                        }
                    }

                    else if (direction == "right")
                    {
                        for (int currCol = col; currCol < matrix.GetLength(0); currCol += 2)
                        {

                            if (IsTruffle(matrix, row, currCol))
                            {
                                boarTruffles++;
                            }
                            matrix[row, currCol] = "-";
                        }
                    }

                }
                else if (command == "Stop the hunt")
                {
                    break;
                }

            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");
            Console.WriteLine($"The wild boar has eaten {boarTruffles} truffles.");
            Print(matrix);

        }
        static void FillMatrix(string[,] matrix, int matrixSise)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(' ');

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
        static void Print(string[,] matrix)
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
        static bool IsTruffle(string[,] matrix, int row, int col)
        {
            return matrix[row, col] == "S" || matrix[row, col] == "B" || matrix[row, col] == "W";
        }

    }
}
