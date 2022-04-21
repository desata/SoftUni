using System;

namespace Refactoring
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < i; divider++)
                {
                    if (i % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                Console.WriteLine(($"{i} -> {isPrime}").ToLower());
            }
        }
    }
}