using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int max = int.MinValue;

            for (int i = 1; i <= N; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num >= max)
                {
                    max = num;
                }
            }
            Console.WriteLine(max);
        }
    }
}
