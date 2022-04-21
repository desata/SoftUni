using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo
{
    class Program
    {
        static void Main()
        {

            double n = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double sum = 1;
            double numerator = 1;

            for (double i = 1, denominator = x; i <= n; i++, denominator *= x)
            {
                numerator *= i;
                double currentFraction = numerator / denominator;
                sum += currentFraction;
            }

            Console.WriteLine("{0:f5}", sum);
        }
    }
}

/*
 Write a program that, for a given two numbers N and x, calculates the sum S = 1 + 1!/x + 2!/x2 + … + N!/xN.

Use only one loop. Print the result with 5 digits after the decimal point.
Input
On the first line you will receive one number - N.
On the second line you will receive another number - x.
Output
Output only one number - the sum of the sequence for the given N and x.
Constraints
N will always be a valid integer between 2 and 10, inclusive.
X will always be a valid floating-point number between 0.5 and 100

 | Input | Output | 
|----------------|----------------|
 | 3 2 | 2.75000 |
 | 4 3 | 2.07407 | 
| 5 -4 | 0.75781 |

while (num > 0)
{
    n = num;
    for (int i = n - 1; i > 0; i--)
    {
        n *= i;
    }
    Console.WriteLine("Factorial of {0}! = {1}\n", num, n);
    num--;
}


 */