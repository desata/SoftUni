﻿using System;

namespace _06
{
    internal class sumAndProduct
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool IsFound = false;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 9; b >= a; b--)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        for (int d = 9; d >= c; d--)
                        {
                            int sum = a + b + c + d;
                            int product = a * b * c * d;

                            if (sum == product && n % 10 == 5 )
                            {
                                Console.WriteLine($"{a}{b}{c}{d}");
                                IsFound = true;
                                return;
                            }
                            else if (product / sum == 3 && n % 3 == 0)
                            {
                                Console.WriteLine($"{d}{c}{b}{a}");
                                IsFound = true;
                                return;
                            }
                           
                        }
                    }
                }
            }
            if (!IsFound)
            {
                Console.WriteLine("Nothing found");
            }
        }
    }
}
