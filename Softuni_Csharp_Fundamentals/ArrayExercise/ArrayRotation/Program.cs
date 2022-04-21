using System;
using System.Linq;

namespace ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that receives an array and several rotations that you have to perform.
            //The rotations are done by moving the first element of the array from the front to the back.
            //Print the resulting array.

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int temp = array[0];

                for (int operations = 0; operations < array.Length - 1; operations++)
                {
                    array[operations] = array[operations + 1];
                }
                array[array.Length - 1] = temp;
            }
            Console.WriteLine(String.Join(" ", array));

        }
    }
}
