using System;
using System.Collections.Generic;
using System.Linq;


namespace _05.Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> x = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(String.Join(", ", x.Select(x => x + 10)));


        }
    }
}
