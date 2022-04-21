using System;
using System.Linq;

namespace EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumLeft = 0;
            int sumRight = 0;

            for (int i = 0; i <= number.Length - 1; i++)
            {
                if (number.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                sumLeft = 0;
                for (int iLeft = i; iLeft > 0; iLeft--)
                {
                    int nextPosition = iLeft - 1;
                    if (iLeft > 0)
                    {
                        sumLeft += number[nextPosition];
                    }
                }

                sumRight = 0;
                for (int iRight = i; iRight < number.Length; iRight++)
                {
                    int nextPosition = (iRight + 1);
                    if (iRight < number.Length - 1)
                    {
                        sumRight += number[nextPosition];
                    }
                }

                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }

            }
            Console.WriteLine("no");
        }
    }
}
