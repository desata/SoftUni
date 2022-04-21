using System;
using System.Linq;

namespace SumEven
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Read an array from the console and sum only its even values

            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                //int number = array[i];

                if (array[i] % 2 == 0)
                {
                    sum += array[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
