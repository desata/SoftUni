using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are given a lower and an upper bound for a range of integer numbers. Then a command specifies if you need to list all even or odd numbers in the given range. Use Predicate<T>.
            //bool

            Predicate<int> isEven = x => x % 2 == 0;
            Predicate<int> isOdd = x => x % 2 != 0;
            int[] intInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            int firstNum = intInput[0];
            int lastNum = intInput[1];

            string command = Console.ReadLine();

            for (int i = firstNum; i <= lastNum; i++)
            {
                numbers.Add(i);
            }
            
            if (command == "even")
            {
               numbers = numbers.FindAll(isEven);
                
            }
            else if (command == "odd")
            {
                numbers = numbers.FindAll(isOdd);
                
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
