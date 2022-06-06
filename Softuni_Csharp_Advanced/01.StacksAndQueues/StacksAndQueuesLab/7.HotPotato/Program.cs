using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Hot potato is a game in which children form a circle and start passing a hot potato.
            //The counting starts with the first kid.
            //Every nth toss the child left with the potato leaves the game.
            //When a kid leaves the game, it passes the potato along.
            //This continues until there is only one kid left.
            //Create a program that simulates the game of Hot Potato.
            //Print every kid that is removed from the circle.
            //In the end, print the kid that is left last.

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
