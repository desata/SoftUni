using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You are going to receive two lists of numbers.
            //Create a list that contains the numbers from both of the lists.
            //The first element should be from the first list, the second from the second list, and so on.
            //If the length of the two lists is not equal, just add the remaining elements at the end of the list.

            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int longerList = Math.Max(firstList.Count, secondList.Count);
            List<int> summaryList = new List<int>();

            for (int i = 0; i < longerList; i++)
            {
                if (i < firstList.Count)
                {
                    summaryList.Add(firstList[i]);
                }
                if (i < secondList.Count)
                {
                    summaryList.Add(secondList[i]);
                }
            }
            Console.WriteLine(string.Join(" ",summaryList));

        }
    }
}
