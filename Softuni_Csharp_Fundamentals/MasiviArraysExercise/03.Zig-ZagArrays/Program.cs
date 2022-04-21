using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that creates 2 arrays.
            //You will be given an integer n. On the next n lines, you will get 2 integers.
            //Form 2 new arrays in a zig-zag pattern as shown below.

            int lines = int.Parse(Console.ReadLine());

            int[] arrayOne = new int[lines];
            int[] arrayTwo = new int[lines];

            for (int i = 0; i < lines ; i++)
            {
                int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                
                if (i % 2 == 0)
                {
                    arrayOne[i] = elements[0];
                    arrayTwo[i] = elements[1];
                }
                else
                {
                    arrayOne[i] = elements[1];
                    arrayTwo[i] = elements[0];
                }
            }
            Console.Write(String.Join(" ", arrayOne));
            Console.WriteLine("");
            Console.Write(String.Join(" ", arrayTwo));

        }
    }
}
