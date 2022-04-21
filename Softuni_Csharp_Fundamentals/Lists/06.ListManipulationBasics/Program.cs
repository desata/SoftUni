using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a list of integers. Then until you receive "end", you will receive different commands:
            //•	Add { number}: add a number to the end of the list.
            //•	Remove { number}: remove a number from the list.
            //•	RemoveAt { index}: remove a number at a given index.
            //•	Insert { number}
            //{ index}: insert a number at a given index.
            //Note: All the indices will be valid!
            //When you receive the "end" command, print the final state of the list(separated by spaces).

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "end")
            {

                switch (command[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(command[1]));
                        break;
                    case "Remove":
                        numbers.Remove(int.Parse(command[1]));
                        break;
                    case "RemoveAt":
                        numbers.RemoveAt(int.Parse(command[1]));
                        break;
                    case "Insert":
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
