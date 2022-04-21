using System;
using System.Linq;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //You will be given a sequence of strings, each on a new line
            //Every odd line on the console is representing a resource
            //(e.g. Gold, Silver, Copper, and so on) and every even - quantity
            //Your task is to collect the resources and print them each on a new line
            //Print the resources and their quantities in the following format:
            //"{resource} –> {quantity}"
            //The quantities will be in the range[1 … 2 000 000 000]

            string input = Console.ReadLine();
            int number;
            Dictionary<string, int> metals = new Dictionary<string, int>();

            while (input != "stop")
            {
                number = int.Parse(Console.ReadLine());

                if (metals.ContainsKey(input))
                {
                    metals[input] += number;
                }
                else 
                {
                   metals.Add(input, number);
                }

                input = Console.ReadLine(); 
            }

            foreach (var metal in metals)
            {
                Console.WriteLine($"{metal.Key} -> {metal.Value}");
            }

        }
    }
}
