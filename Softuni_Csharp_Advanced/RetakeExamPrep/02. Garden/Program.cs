using System;
using System.Linq;

namespace _02._Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            int[,] matrix = new int[n, m];

            //fill
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            string command = Console.ReadLine();

            while (command != "Bloom Bloom Plow")
            {
                int row = int.Parse(command.Split()[0]);
                int col = int.Parse(command.Split()[1]);

                if (IsInside(matrix, row, col))
                {
                    
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < m; j++)
                        {
                            if (i == row || j == col)
                            {
                                matrix[i, j] += 1;
                            }
                            
                        }
                    }
                    matrix[row, col] = 1;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                command = Console.ReadLine();

            }

            //print
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            static bool IsInside(int[,] matrix, int givenRow, int givenCol)
            {
                return givenRow >= 0 && givenRow < matrix.GetLength(0) &&
                       givenCol >= 0 && givenCol < matrix.GetLength(1);
            }

        }
    }
}
