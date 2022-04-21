using System;
using System.Linq;
using System.Collections.Generic;



namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //On the first line, we will receive a list of wagons (integers).
            //Each integer represents the number of passengers that are currently in each wagon of a passenger train.
            //On the next line, you will receive the max capacity of a wagon represented as a single integer.
            //Until you receive the "end" command, you will be receiving two types of input:
            //•	Add { passengers} – add a wagon to the end of the train with the given number of passengers.
            //•	{ passengers} -find a single wagon to fit all the incoming passengers(starting from the first wagon).
            //In the end, print the final state of the train(all the wagons separated by a space).

            List<int> wagons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                
                string[] argument = command.Split(" ");

                if (argument[0] == "Add")
                {
                    wagons.Add(int.Parse(argument[1]));
                }
                else
                {
                    int numberArgument = int.Parse(argument[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {

                        if ((numberArgument + wagons[i]) <= capacity)
                        {
                            wagons[i] += numberArgument;
                            break;
                        }

                    }
                }
                command = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}
