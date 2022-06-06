using System;
using System.Linq;

namespace _6.Jagged_ArrayMod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a matrix from the console.
            //On the first line, you will get matrix rows. On the next rows lines, you will get elements for each column separated with space.
            //You will be receiving commands in the following format:
            //  3
            //  1 2 3
            //  4 5 6
            //  7 8 9
            //  Add 0 0 5
            //  Subtract 1 1 2
            //  END
            //•	Add {row} {col} {value} – Increase the number at the given coordinates with the value.
            //•	Subtract { row} { col} { value} – Decrease the number at the given coordinates by the value.
            //Coordinates might be invalid. In this case, you should print "Invalid coordinates".When you receive "END" you should print the matrix and stop the program.

            int row = int.Parse(Console.ReadLine());
            int[][] matrix = new int[row][];

            for (int i = 0; i < row; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                matrix[i] = data;
            }
            string[] input = Console.ReadLine().Split();
            while (input[0] != "END")
            {
                string command = input[0];
                int commandRow = int.Parse(input[1]);
                int commandCol = int.Parse(input[2]);
                int commandValue = int.Parse(input[3]);

                if (commandRow >= 0 && commandRow < matrix.GetLength(0) && commandCol >= 0 && commandCol < matrix[commandRow].Length)
                {
                    if (command == "Add")
                    {
                        matrix[commandRow][commandCol] += commandValue;
                    }
                    if (command == "Subtract")
                    {
                        matrix[commandRow][commandCol] -= commandValue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                    // break;
                }
                input = Console.ReadLine().Split();

            }
            if (input[0] == "END")
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.Write($"{matrix[i][j]} ");
                    }
                    Console.WriteLine();

                }
            }
        }
    }
}
