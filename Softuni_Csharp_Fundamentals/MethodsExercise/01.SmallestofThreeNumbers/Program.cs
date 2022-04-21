using System;

namespace _01.SmallestofThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method that prints out the smallest of three integer numbers.

            int number = 0;
            int smallest = int.MaxValue;

            for (int i = 0; i < 3; i++)
            {
                number = int.Parse(Console.ReadLine());

                if (number <= smallest)
                {
                    smallest = number;
                }
            }
            Console.WriteLine(smallest);


        }
    }
}
