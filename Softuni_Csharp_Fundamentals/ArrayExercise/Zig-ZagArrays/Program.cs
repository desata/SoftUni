using System;
using System.Linq;

namespace Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that creates 2 arrays.
            //You will be given an integer n.
            //On the next n lines, you will get 2 integers.
            //Form 2 new arrays in a zig-zag pattern as shown below.

            int n = int.Parse(Console.ReadLine());
            int[] arrayOne = new int[n];
            int[] arrayTwo = new int[n];


            for (int i = 0; i < n; i++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
                if (i % 2 == 0)
                {
                    arrayOne[i] = array[0];
                    arrayTwo[i] = array[1];
                }
                else
                {
                    arrayOne[i] = array[1];
                    arrayTwo[i] = array[0];
                }
            
            }

            Console.WriteLine(String.Join(" ", arrayOne));
            Console.WriteLine(String.Join(" ", arrayTwo));

        }
    }
}
