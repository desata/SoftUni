using System;
using System.Collections.Generic;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that keeps track of the guests that are going to a house party.
            //On the first line of input, you are going to receive the number of commands that will follow.
            //On the next lines, you are going to receive some of the following:  "{name} is going!"
            //•	You have to add the person if they are not on the guestlist already.
            //•	If the person is on the list print the following to the console: "{name} is already in the list!"
            //"{name} is not going!"
            //•	You have to remove the person if they are on the list. 
            //•	If not, print out: "{name} is not in the list!"
            //Finally, print all of the guests, each on a new line.

            int numberOfCommands = int.Parse(Console.ReadLine());
            string[] command = new string[numberOfCommands];
            List<string> guestList = new List<string>();

            for (int i = 0; i < numberOfCommands; i++)
            {
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];

                if (command.Length > 3)
                {
                    if (guestList.Contains(name))
                    {
                        guestList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
                else
                {
                    if (!guestList.Contains(name))
                    {
                        guestList.Add(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                }
            }
            Console.WriteLine(string.Join("\n", guestList));
        }
    }
}
