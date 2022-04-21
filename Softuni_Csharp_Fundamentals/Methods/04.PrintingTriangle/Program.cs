using System;

namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a method for printing triangles as shown below:
            //3
            //1
            //1 2
            //1 2 3
            //1 2
            //1

            int n = int.Parse(Console.ReadLine());
            PrintTriangle(n);
        }
        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }


        static void PrintTriangle(int n)
        {
            for (int line = 1; line <= n; line++)
            {
                PrintLine(1, line);

            }



            for (int line = n - 1; line >= 1; line--)
            {
                PrintLine(1, line);

            }
        }
    }
}
