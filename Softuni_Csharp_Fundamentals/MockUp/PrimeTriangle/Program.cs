using System;

namespace PrimeTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int number = int.Parse(Console.ReadLine());
            int a = 1;

            for (int i = 1; i <= number; i++)
            {

                for (int divider = 2; divider < i; divider++)
                {
                    if (i % divider == 0)
                    {
                        a = 0;
                        break;
                    }
                    else
                    {
                        a = 1;
                    }
                }

                for (int row = 1; row <= number; row++)
                {
                    for (int col = 1; col <= row; col++)
                    {
                        Console.Write($"{a}");
                    }
                    Console.WriteLine();
                }
            }
        }       
    }
}