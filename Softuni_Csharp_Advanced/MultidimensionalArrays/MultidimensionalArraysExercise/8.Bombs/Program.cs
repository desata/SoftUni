using System;
using System.Linq;

namespace _8.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            FillMatrix(matrix, matrixSize);
            string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            //1,2 2,1 2,0 - coordinates
            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] bomb = coordinates[i].Split(',').Select(int.Parse).ToArray();
                int bombRow = bomb[0];
                int bombCol = bomb[1];

                if (matrix[bombRow, bombCol] > 0)
                {

                    if (IsInRange(matrix, bombRow - 1, bombCol))
                    {
                        if (IsAlive(matrix[bombRow - 1, bombCol]))
                        {
                            matrix[bombRow - 1, bombCol] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow - 1, bombCol + 1))
                    {
                        if (IsAlive(matrix[bombRow - 1, bombCol + 1]))
                        {
                            matrix[bombRow - 1, bombCol + 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow, bombCol + 1))
                    {
                        if (IsAlive(matrix[bombRow, bombCol + 1]))
                        {
                            matrix[bombRow, bombCol + 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow + 1, bombCol + 1))
                    {
                        if (IsAlive(matrix[bombRow + 1, bombCol + 1]))

                        {
                            matrix[bombRow + 1, bombCol + 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow + 1, bombCol))
                    {
                        if (IsAlive(matrix[bombRow + 1, bombCol]))
                        {
                            matrix[bombRow + 1, bombCol] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow + 1, bombCol - 1))
                    {
                        if (IsAlive(matrix[bombRow + 1, bombCol - 1]))
                        {
                            matrix[bombRow + 1, bombCol - 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow, bombCol - 1))
                    {
                        if (IsAlive(matrix[bombRow, bombCol - 1]))
                        {
                            matrix[bombRow, bombCol - 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    if (IsInRange(matrix, bombRow - 1, bombCol - 1))
                    {
                        if (IsAlive(matrix[bombRow - 1, bombCol - 1]))
                        {
                            matrix[bombRow - 1, bombCol - 1] -= matrix[bombRow, bombCol];
                        }
                    }
                    matrix[bombRow, bombCol] = 0;
                }
            }

            //"Alive cells: {aliveCells}"
            //"Sum: {sumOfCells}"
            int aliveCells = 0;
            int sumOfCells = 0;
            foreach (var element in matrix)
            {
                if (IsAlive(element))
                {
                    aliveCells++;
                    sumOfCells += element;
                }
                
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");

            Print(matrix);

        }
        static void FillMatrix(int[,] matrix, int matrixSise)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void Print(int[,] matrix)
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

        private static bool IsInRange(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
        private static bool IsAlive(int value)
        {
            return value > 0;
        }

    }
}
