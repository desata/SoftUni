using System;
using System.Linq;

namespace ArrayToNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int origLength = numbers.Length;
            int[] condensed = new int[numbers.Length - 1];

            for (int j = 0; j < origLength - 1; j++)
            {

                for (int i = 0; i < numbers.Length - 1; i++)
                {

                    condensed[i] = numbers[i] + numbers[i + 1];

                }
                numbers = condensed;
            }

            Console.WriteLine(numbers[0]);
        }

    }
}
