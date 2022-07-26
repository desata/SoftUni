using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            Queue<string> cars = new Queue<string>();
            int counter = 0;

            while (command != "end")
            {
                if (command != "green")
                {
                    cars.Enqueue(command);
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {

                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }


                command = Console.ReadLine();
            }
            Console.WriteLine($"{counter} cars passed the crossroads.");

        }
    }
}
