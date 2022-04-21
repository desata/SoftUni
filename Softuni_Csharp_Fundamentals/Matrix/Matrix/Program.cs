using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            int BiggestN = N * N;
            int columns = N * N;

            for (int i = 1; i <= N; i++)
            {
                Console.Write(i + " ");
            }

            //Console.WriteLine("Hello World!");
        }
    }
}
/*
 Matrix Numbers
Write a program that reads from the console a positive integer number N and prints a matrix like in the examples below. Use two nested loops.

Input
The input will always consist of a single line, which contains the number N
 */
