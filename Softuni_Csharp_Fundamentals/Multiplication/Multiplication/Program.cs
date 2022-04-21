using System;

namespace Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            if (x<=10)
            {
                for (int i = x; i <= 10; i++)
                {
                    Console.WriteLine($"{n} X {i} = {n * i}");
                }
            }
            else
            {
                Console.WriteLine($"{n} X {x} = {n * x}");
            }
            
        }
    }
}
