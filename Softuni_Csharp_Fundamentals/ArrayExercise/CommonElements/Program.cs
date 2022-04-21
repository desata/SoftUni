using System;

namespace CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that prints out all common elements in two arrays.
            //You have to compare the elements of the second array to the elements of the first.

            string[] arrayOne = Console.ReadLine().Split();
            string[] arrayTwo = Console.ReadLine().Split();

            foreach (string arrTwo in arrayTwo)
            {
                foreach (string arrOne in arrayOne)
                {
                    if (arrTwo == arrOne)
                    {
                        Console.Write($"{arrOne} ");
                        break;
                    }
                }
            }
        }
    }
}
