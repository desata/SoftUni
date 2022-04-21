using System;

namespace FirstPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prime Factors
            //Write a program that finds the prime factors of a given non-prime number.List the factors in ascending order.
            //12 = 2 * 2 * 3
            //100 = 2 * 2 * 5 * 5
            //Input
            //On the first line you will receive one number -N
            //Output
            //Output each prime factor on a newline.
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i <= n; i++)
            {

               if (n % 2 == 0)
                {
                    Console.WriteLine(2);
                    n /= 2;
                }
                else if (n % 3 == 0)
                {
                    Console.WriteLine(3);
                    n /= (3);
                }
                else if (n % 5 == 0)
                {
                    Console.WriteLine(5);
                    n /= (5);
                }
                else if (n % 7 == 0)
                {
                    Console.WriteLine(7);
                    n /= (7);
                }
                else if (n>1)
                {
                    Console.WriteLine(n);
                    break;
                }
            }
        }
    }
}
