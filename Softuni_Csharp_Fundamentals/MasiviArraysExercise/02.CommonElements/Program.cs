using System;

namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that prints out all common elements in two arrays.
            //You have to compare the elements of the second array to the elements of the first.

            string[] arrayOne = Console.ReadLine().Split(' ');
            string[] arrayTwo = Console.ReadLine().Split(' ');

            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    if (arrayTwo[j]==arrayOne[i])
                    {
                        Console.Write($"{arrayOne[i]} ");
                    }
                }         


            }
        }
    }
}
