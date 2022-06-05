using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reverses a collection and removes elements that are divisible by a given integer n. Use predicates/functions.

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int divider = int.Parse(Console.ReadLine());
            Predicate<int> isDivideble = x => x % divider != 0;
            Action<List<int>> printNum = x => Console.WriteLine(String.Join(" ", x));

            List<int> result = numbers.Where(x => isDivideble(x)).ToList();
            printNum(result);
        }
    }
}
