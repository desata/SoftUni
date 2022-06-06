using System;
using System.Linq;

namespace _4.SymbolinMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads N, a number representing rows and cols of a matrix. On the next N lines, you will receive rows of the matrix. Each row consists of ASCII characters. After that, you will receive a symbol. Find the first occurrence of that symbol in the matrix and print its position in the format: "({row}, {col})". If there is no such symbol print an error message 
            // "{symbol} does not occur in the matrix "


            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            bool isContainSymbol = false;

            for (int row = 0; row < n; row++)
            {
                char[] rowArray = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowArray[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isContainSymbol = true;
                        break;
                    }
                }
                if (isContainSymbol)
                {
                    break;
                }
            }
            if (!isContainSymbol)
            {

                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }


        }
    }
}
