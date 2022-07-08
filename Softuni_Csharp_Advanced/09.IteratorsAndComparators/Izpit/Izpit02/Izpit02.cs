using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Izpit02
{
    internal class Izpit02
    {
        static void Main(string[] args)
        {
            //02. Wall Destroyer
            int matrixSize = int.Parse(Console.ReadLine());
            char[,] wall = new char[matrixSize, matrixSize];
            bool IsElectrocuted = false;

            FillMatrix(wall, matrixSize);

            int VankoRow = 0;
            int VankoCol = 0;

            //find Vanko's position
            for (int i = 0; i < wall.GetLength(0); i++)
            {
                for (int j = 0; j < wall.GetLength(1); j++)
                {
                    if (wall[i, j] == 'V')
                    {
                        VankoRow = i;
                        VankoCol = j;
                    }
                }
            }

            string command = Console.ReadLine();
            wall[VankoRow, VankoCol] = '*';
            int createdHole = 1;
            int hitRod = 0;

            while (command != "End")
            {
                if (command == "up" && VankoRow - 1 >= 0)
                {
                    if (wall[VankoRow - 1, VankoCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRod++;
                    }
                    else if (wall[VankoRow - 1, VankoCol] == 'C')
                    {
                        wall[VankoRow - 1, VankoCol] = 'E';
                        wall[VankoRow, VankoCol] = '*';
                        IsElectrocuted = true;
                        createdHole++;
                        break;
                    }
                    else if (wall[VankoRow - 1, VankoCol] == '*')
                    {
                        wall[VankoRow, VankoCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow--}], [{VankoCol}]!");

                    }
                    else if (wall[VankoRow - 1, VankoCol] == '-')
                    {
                        wall[VankoRow, VankoCol] = '*';
                        VankoRow--;
                        wall[VankoRow, VankoCol] = 'V';
                        createdHole++;
                    }

                }
                else if (command == "down" && VankoRow + 1 < matrixSize)
                {
                    if (wall[VankoRow + 1, VankoCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRod++;
                    }
                    else if (wall[VankoRow + 1, VankoCol] == 'C')
                    {
                        wall[VankoRow + 1, VankoCol] = 'E';
                        wall[VankoRow, VankoCol] = '*';
                        createdHole++;
                        IsElectrocuted = true;
                        break;
                    }
                    else if (wall[VankoRow + 1, VankoCol] == '*')
                    {
                        wall[VankoRow, VankoCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow++}], [{VankoCol}]!");

                    }
                    else if (wall[VankoRow + 1, VankoCol] == '-')
                    {

                        wall[VankoRow, VankoCol] = '*';
                        VankoRow++;
                        wall[VankoRow, VankoCol] = 'V';
                        createdHole++;
                    }


                }
                else if (command == "left" && VankoCol - 1 >= 0)
                {
                    if (wall[VankoRow, VankoCol - 1] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRod++;
                    }
                    else if (wall[VankoRow, VankoCol - 1] == 'C')
                    {
                        wall[VankoRow, VankoCol - 1] = 'E';
                        wall[VankoRow, VankoCol] = '*';
                        createdHole++;
                        IsElectrocuted = true;
                        break;
                    }
                    else if (wall[VankoRow, VankoCol - 1] == '*')

                    {
                        wall[VankoRow, VankoCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow}], [{VankoCol--}]!");

                    }
                    else if (wall[VankoRow, VankoCol - 1] == '-')
                    {
                        wall[VankoRow, VankoCol] = '*';
                        VankoCol--;
                        wall[VankoRow, VankoCol] = 'V';
                        createdHole++;
                    }


                }
                else if (command == "right" && VankoCol + 1 < matrixSize)
                {
                    if (wall[VankoRow, VankoCol + 1] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        hitRod++;
                    }
                    else if (wall[VankoRow, VankoCol + 1] == 'C')
                    {
                        wall[VankoRow, VankoCol + 1] = 'E';
                        wall[VankoRow, VankoCol] = '*';
                        createdHole++;
                        IsElectrocuted = true;
                        break;
                    }
                    else if (wall[VankoRow, VankoCol + 1] == '*')
                    {
                        wall[VankoRow, VankoCol] = '*';
                        Console.WriteLine($"The wall is already destroyed at position [{VankoRow}], [{VankoCol++}]!");

                    }
                    else if (wall[VankoRow, VankoCol + 1] == '-')
                    {
                        wall[VankoRow, VankoCol] = '*';
                        VankoCol++;
                        wall[VankoRow, VankoCol] = 'V';
                        createdHole++;
                    }
                }

                command = Console.ReadLine();

            }

            if (IsElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {createdHole} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {createdHole} hole(s) and he hit only {hitRod} rod(s).");
            }

            Print(wall);

        }
        static void FillMatrix(char[,] matrix, int matrixSise)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        static void Print(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }

}
