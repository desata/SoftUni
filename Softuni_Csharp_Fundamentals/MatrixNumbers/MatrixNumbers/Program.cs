using System;

namespace MatrixNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            
            for (int row = 1; row <= N; row++)
            {
                int x = row;
                for (int col = 1; col <= N; col++)
                {

                    Console.Write($"{x} ");
                    x += 1;
                }
                Console.WriteLine();
                
            }
            
        }
    }
}
