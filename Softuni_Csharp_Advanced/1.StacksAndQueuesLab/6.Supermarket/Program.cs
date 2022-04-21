using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reads an input consisting of a name and adds it to a queue until "End" is received.
            //If you receive "Paid", print every customer name and empty the queue,
            //otherwise, we receive a client and we have to add him to the queue.
            //When we receive "End" we have to print the count of the
            //remaining people in the queue in the format: "{count} people remaining.".

            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            while (input != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else if (input == "Paid")
                {
                    while (queue.Count != 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
