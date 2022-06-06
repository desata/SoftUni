using System;
using System.Linq;

namespace _4.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int[] matrixSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = matrixSize[0];
            int col = matrixSize[1];
            string[,] matrix = new string[row, col];

            for (int rows = 0; rows < matrix.GetLength(0); rows++)
            { 
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[rows, cols] = input[cols];
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string arg = command[0];

                if (arg == "END")
                {
                    Environment.Exit(0);
                   // break;
                }
                else if (arg == "swap" && command.Length == 5)
                {
                    int rowOne = int.Parse(command[1]);
                    int colOne = int.Parse(command[2]);
                    int rowTwo = int.Parse(command[3]);
                    int colTwo = int.Parse(command[4]);

                    if (rowOne >= 0 && rowOne < matrix.GetLength(0)
                        &&rowTwo >= 0 && rowTwo < matrix.GetLength(0)
                        &&colOne >= 0 && colOne < matrix.GetLength(1)
                        && colTwo >= 0 && colTwo < matrix.GetLength(1))
                    {
                        string currentValue = matrix[rowOne, colOne];
                        matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                        matrix[rowTwo, colTwo] = currentValue;

                        for (int rows = 0; rows < matrix.GetLength(0); rows++)
                        {
                            for (int cows = 0; cows < matrix.GetLength(1); cows++)
                            {
                                Console.Write(matrix[rows, cows] + " ");

                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }   
            }
        }
    }
}
