using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads one line of integers separated by ", ". Then prints the even numbers of that sequence sorted in increasing order.
            //Hint: It is up to you what type of data structures you will use to solve this problem. Use a functional programming filter and sort the collection of numbers.


            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            
            numbers = numbers.Where(x => x % 2 == 0).OrderBy(x => x).ToList();


            Console.WriteLine(String.Join(", ", numbers));

        }
    }
}
