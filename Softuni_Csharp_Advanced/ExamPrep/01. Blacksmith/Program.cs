using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>()
            {
                ["Gladius"] = 0,
                ["Shamshir"] = 0,
                ["Katana"] = 0,
                ["Sabre"] = 0,
                ["Broadsword"] = 0,
            };


            int[] steelSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] carbonSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> steel = new Queue<int>(steelSequence);
            Stack<int> carbon = new Stack<int>(carbonSequence);
            int swordsForged = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currentSteel = steel.Dequeue();
                int currentCarbon = carbon.Pop();

                if (currentSteel + currentCarbon == 70)
                {
                    swords["Gladius"] += 1;
                }
                else if (currentSteel + currentCarbon == 80)
                {
                    swords["Shamshir"] += 1;
                }
                else if (currentSteel + currentCarbon == 90)
                {
                    swords["Katana"] += 1;
                }
                else if (currentSteel + currentCarbon == 110)
                {
                    swords["Sabre"] += 1;
                }
                else if (currentSteel + currentCarbon == 150)
                {
                    swords["Broadsword"] += 1;
                }
                else
                {
                    carbon.Push(currentCarbon + 5);
                    swordsForged -= 1;
                }
                swordsForged += 1;
            }

            if (swordsForged > 0)
            {
                Console.WriteLine($"You have forged {swordsForged} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");

            }

            if (steel.Count > 0)
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }

            if (carbon.Count > 0)
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }


            foreach (var sword in swords)
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
