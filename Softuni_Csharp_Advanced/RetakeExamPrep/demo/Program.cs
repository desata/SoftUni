using System;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            for (int i = 0; i <= n; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }

            }

            Console.WriteLine();

            for (int i = 0; i <= n; i++)
            {
                if (i / 2 == 0)
                {
                    Console.WriteLine(true);
                }
                else
                {
                    Console.WriteLine(false);
                }


            }


        }
    }
}
