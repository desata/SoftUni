using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main()
        {
            //Create a generic method that receives a list, containing any type of data and swaps the elements at two given indexes.

            int n = int.Parse(Console.ReadLine());
            var list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOfGreaterElement(list, elementToCompare);
          //  box.Swap(list, indexes[0], indexes[1]);

            Console.WriteLine(count);
        }
    }
}
