using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program to append several arrays of numbers one after another.
            //Arrays are separated by '|'
            //Their Values are separated by spaces(' ', one or several)
            //Take all arrays starting from the rightmost and going to the left and place them in a new array in that order

            List<string> list = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
            list.Reverse();
            // string temp = list.Replace(" ", "");

            List<string> finalList = new List<string>();//empty for the final result

            foreach (string items in list)//going through the list
            {
                string[] removeSpaces = items.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();//array for removing spaces

                foreach (string numbersToAdd in removeSpaces)//adding numbers to finalList
                {
                    finalList.Add(numbersToAdd);
                }
            }
            Console.WriteLine(string.Join(" ", finalList));
        }
    }
}
