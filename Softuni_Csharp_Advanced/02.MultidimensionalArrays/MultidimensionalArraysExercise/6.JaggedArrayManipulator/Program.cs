using System;
using System.Linq;

namespace _6.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that populates, analyzes, and manipulates the elements of a matrix with an unequal length of its rows.

            int n = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[n][];

            //populate var 1
            for (int row = 0; row < n; row++)
            {
                double[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                jaggedArray[row] = input;
            }

            //populate var 2
            //for (int row = 0; row < n; row++)
            //{
            //    int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            //    matrix[row] = new int[input.Length];
            //    for (int col = 0; col < input.Length; col++)
            //    {
            //        matrix[row][col] = input[row];
            //    }
            //}

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row+1].Length; col++)
                    { 
                        jaggedArray[row+1][col] /= 2;
                    }
                }
            }

            string[] command = Console.ReadLine().Split();
            

            while (command[0] != "End")
            {
                string arg = command[0];
                int row = int.Parse(command[1]);
                int column = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (arg == "Add")
                {
                    if (row >= 0 && row <= n && column >= 0 && column <= jaggedArray[row].Length)
                    {
                        jaggedArray[row][column] += value;
                    }
                }
                else if (arg == "Subtract")
                {
                    if (row >= 0 && row <= n && column >= 0 && column <= jaggedArray[row].Length)
                    {
                        jaggedArray[row][column] -= value;
                    }
                }
                command = Console.ReadLine().Split();
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[i]));
                

            }
            
        }
    }
}
