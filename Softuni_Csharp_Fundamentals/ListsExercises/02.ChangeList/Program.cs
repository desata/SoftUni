using System;
using System.Linq;
using System.Collections.Generic;


namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program, that reads a list of integers from the console and receives commands to manipulate the list.
            //Your program may receive the following commands:

            //•	Delete {element} – delete all elements in the array, which are equal to the given element.
            //•	Insert {element} {position} – insert the element at the given position.

            //You should exit the program when you receive the "end" command. Print all numbers in the array separated by a single whitespace.
            //ds a list of integers from the console and receives commands to manipulate the list.
            //            Your program may receive the following commands:
            //•	Delete { element} – delete all elements in the array, which are equal to the given element.
            //•	Insert { element} { position} – insert the element at the given position.
            //You should exit the program when you receive the "end" command.Print all numbers in the array separated by a single whitespace.


            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = "";

            while (command != "end")
            {
                string[] argument = command.Split(' ');
                if (argument[0] == "Insert")
                {
                    numbers.Insert(int.Parse(argument[2]), int.Parse(argument[1]));
                }
                else if (argument[0] == "Delete")
                {
                    int deleteArg = int.Parse(argument[1]);
                    numbers.RemoveAll(x => x == deleteArg);
                    
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
