using System;
using System.Linq;

namespace _3.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that finds the sum of matrix primary diagonal.
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            int sum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] rowArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row, col]; 
                    }
                }
            }
            Console.WriteLine(sum);

        }
    }
}
