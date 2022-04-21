using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The first input line will hold a list of integers. Until we receive the "End" command, we will be given operations we have to apply to the list.
            //            The possible commands are:
            //•	Add { number} – add the given number to the end of the list
            //•	Insert { number}
            //            {index} – insert the number at the given index
            //•	Remove { index} – remove the number at the given index
            //•	Shift left { count} – first number becomes last. This has to be repeated the specified number of times
            //•	Shift right { count} – last number becomes first. To be repeated the specified number of times
            //Note: the index given may be outside of the bounds of the array. In that case print: "Invalid index".

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";

            while (command != "End")
            {

                command = Console.ReadLine();
                string[] argument = command.Split();
                if (argument[0] == "Add")
                {
                    numbers.Add(int.Parse(argument[1]));
                }
                else if (argument[0] == "Insert")
                {
                    if (int.Parse(argument[2]) < 0 || int.Parse(argument[2]) > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        
                    }
                    else
                    {
                        numbers.Insert(int.Parse(argument[2]), int.Parse(argument[1]));
                    }
                }
                else if (argument[0] == "Remove")
                {
                    if (int.Parse(argument[1]) < 0 || int.Parse(argument[1]) > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                        
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(argument[1]));
                    }
                }
                else if (argument[0] == "Shift")
                {
                    int rotation = int.Parse(argument[2]);
                    if (argument[1] == "left")
                    {

                        for (int i = 0; i < rotation; i++)
                        {
                            int firstElement = numbers[0];

                            for (int j = 0; j < numbers.Count - 1; j++)
                            {
                                numbers[j] = numbers[j + 1];
                            }
                            numbers[numbers.Count - 1] = firstElement;
                        }
                    }
                    else
                    {

                        for (int i = 0; i < rotation; i++)
                        {
                            int lastElement = numbers[numbers.Count - 1];

                            for (int j = numbers.Count - 1; j > 0; j--)
                            {
                                numbers[j] = numbers[j - 1];
                            }
                            numbers[0] = lastElement;
                        }
                    }

                }

            }
            Console.WriteLine(String.Join(" ", numbers));

        }

    }
}
