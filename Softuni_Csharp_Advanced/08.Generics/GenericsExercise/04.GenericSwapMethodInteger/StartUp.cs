using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main()
        {
            //Create a generic method that receives a list, containing any type of data and swaps the elements at two given indexes.

            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<int>(list);
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            box.Swap(list, indexes[0], indexes[1]);

            Console.WriteLine(box);
        }
    }
}
