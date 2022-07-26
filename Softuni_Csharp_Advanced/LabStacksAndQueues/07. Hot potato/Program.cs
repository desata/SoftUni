using System;
using System.Collections.Generic;

namespace _07._Hot_potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> kids = new Queue<string>(input);
            int tosses = 0;

            while (kids.Count > 1)
            {
                tosses++;
                string kid = kids.Dequeue();

                if (tosses == n)
                {
                    tosses = 0;
                    Console.WriteLine($"Removed " + kid);


                }
                else
                {
                    kids.Enqueue(kid);
                }

            }

            Console.WriteLine($"Last is " + kids.Dequeue());
        }
    }
}
