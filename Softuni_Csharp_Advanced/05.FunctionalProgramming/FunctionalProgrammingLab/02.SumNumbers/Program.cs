using System;
using System.Linq;

namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a line of integers separated by ", ". Print on two lines the count of numbers and their sum.


            int[] numbers = Console.ReadLine().Split(", ").Select(n => int.Parse(n)).ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
