using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Find all numbers in the range 1...N that is divisible by the numbers of a given sequence. On the first line, you will be given an integer N – which is the end of the range. On the second line, you will be given a sequence of integers which are the dividers. Use predicates/functions.
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = Enumerable.Range(1, n).ToList();
            int[] divs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            List<int> numbersForPrint = new List<int>();

            foreach (var number in numbers)
            {
                bool isDivisable = true;

                foreach (var div in divs)
                {
                    Predicate<int> disisable = num => num % div == 0;
                    if (!disisable(number))
                    {
                        isDivisable = false;
                        break;
                    }
                }
                if (isDivisable)
                {
                    numbersForPrint.Add(number);
                }

            }
            Console.WriteLine(String.Join(" ", numbersForPrint));
        }
    }
}
