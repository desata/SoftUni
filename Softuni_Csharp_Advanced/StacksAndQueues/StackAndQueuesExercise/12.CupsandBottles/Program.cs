using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.CupsandBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            int[] cupsCapacityArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> cups = new Queue<int>(cupsCapacityArray);

            int[] bottlesCapacityArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bottles = new Stack<int>(bottlesCapacityArray);
            int wasted = 0;
            int currentCup = 0;


            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentBottle = bottles.Peek();
                if (currentCup == 0)
                {
                    currentCup = cups.Peek();
                }

                if (currentCup != 0)
                {
                    if (currentBottle >= currentCup)
                    {
                        wasted += (currentBottle - currentCup);
                        cups.Dequeue();
                        bottles.Pop();
                        currentCup = 0; 
                        continue;
                    }
                    else
                    {
                        currentCup -= currentBottle;
                        bottles.Pop();
                    }
                }
            }
            if (bottles.Count > 0 && cups.Count == 0)
            {

                Console.WriteLine($"Bottles: {String.Join(" ", bottles)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
            if (bottles.Count == 0 && cups.Count > 0)
            {

                Console.WriteLine($"Cups: {String.Join(" ", cups)}");
                Console.WriteLine($"Wasted litters of water: {wasted}");
            }
        }
    }
}
