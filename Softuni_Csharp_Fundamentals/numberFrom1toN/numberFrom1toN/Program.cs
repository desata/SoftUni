using System;

namespace numberFrom1toN
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.Write(i + " ");
            }

        }
    }
}
/*
    Numbers From 1 to N
Write a program that enters from the console a positive integer n and prints all the numbers from 1 to N inclusive, on a single line, separated by a whitespace.

Input
The input will consist of a single line - the number N
Output
The output should consist of a single line - the numbers from 1 to N, separated by a whitespace
Constraints
N will be a valid positive 32-bit integer
Sample tests
| Input | Output | |----------------|----------------| | 5 | 1 2 3 4 5 | | 1 | 1 |
*/