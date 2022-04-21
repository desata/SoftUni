using System;

namespace Paased
{
    class Program
    {
        static void Main(string[] args)
        {
            float grade = float.Parse(Console.ReadLine());

            if (grade >= 3.00)
            {
                Console.WriteLine("Passed!");
            }
            else
            {
                Console.WriteLine("Failed!");
            }
            
        }
    }
}
/*
Write a program, which takes as an input a grade and prints "Passed!" if the grade is equal or more than 3.00.
Input
The input comes as a single floating-point number.
Output
The output is either "Passed!" if the grade is equal or more than 3.00, otherwise you should print nothing.

 */
