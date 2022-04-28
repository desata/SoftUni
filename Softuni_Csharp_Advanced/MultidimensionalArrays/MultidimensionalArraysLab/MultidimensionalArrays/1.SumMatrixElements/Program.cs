using System;
using System.Linq;

namespace _1.SumMatrixElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int sum = 0;
            int[,] matrix = new int[size[0],size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] rowArray = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row,col] = rowArray[col];
                }
            }
            foreach (int el in matrix)
            {
                sum += el;
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }
    }
}
