using System;

namespace DataTypesandVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters * 0.001;

            Console.WriteLine($"{kilometers:F2}");


        }
    }
}
