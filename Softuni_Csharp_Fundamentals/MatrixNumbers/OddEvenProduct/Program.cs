using System;

namespace OddEvenProduct
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int odd = 1;
            int even = 1;

            for (int i = 1; i <= N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    even *= num;
                }
                else
                {
                    odd *= num;
                }
            }
            if (even == odd)
            {
                Console.WriteLine($"yes {even}");
            }
            else
            {
                Console.WriteLine($"no {odd} {even}");
            }
        }
    }
}
