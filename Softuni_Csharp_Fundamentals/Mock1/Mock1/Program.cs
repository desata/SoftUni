using System;
using System.Linq;

namespace Mock1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Crooked Digits

            decimal N = int.Parse(Console.ReadLine());
            decimal sum = 0;

            if (N > 0 || N < 10)
            {
                Console.WriteLine(N);

            }
            else
            {
                while (N > 9)
                {
                    sum += N % 10;
                    N /= 10;
                }

            }
            Console.WriteLine(sum);

        }
    }
}
