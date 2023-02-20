using System;
using System.Collections.Specialized;

namespace matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 1, 2, 3, 4 }, { 1, 2, 3, 4 } };
            //, {1, 2, 3, 4 }, { 1, 2, 3, 4 } };

            int sum = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrix[i,j]%2!=0 && i!=j)
                    {
                        sum += matrix[i, j];
                    }
                    Console.WriteLine($"i {i}, J {j}, sum {sum} matr {matrix[i,j]}");
                }

            }

             

        }
    }
}
