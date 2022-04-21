using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // List input by number of elements
            //-------------------
            //int numbersOfElements = int.Parse(Console.ReadLine());
            //List<int> elements = new List<int>();
            // for (int i = 0; i < numbersOfElements; i++)
            // { 
            // int currentElement = int.Parse(Console.ReadLine());
            //     elements.Add(currentElement);
            // }
            //---------------------

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int current = numbers[i] + numbers[numbers.Count - 1 - i];
                result.Add(current);

            }
            if (numbers.Count % 2 != 0)
            {
                result.Add(numbers[numbers.Count/2]);
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
