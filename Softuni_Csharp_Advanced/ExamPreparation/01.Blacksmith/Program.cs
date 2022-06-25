using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] steelQty = Console.ReadLine().Split().Select(int.Parse).ToArray(); // queue
            int[] carbonQty = Console.ReadLine().Split().Select(int.Parse).ToArray(); //stack

            Queue<int> steel = new Queue<int>(steelQty);
            Stack<int> carbon = new Stack<int>(carbonQty);
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>()
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0},
                { "Sabre", 0},
                { "Broadsword", 0 }
            };
            
            while (carbon.Count != 0 || steel.Count != 0)
            {
                //Console.WriteLine(steel.Peek());
                //Console.WriteLine(carbon.Peek());

                int currentSteel = steel.Peek();
                int currentCarbon = carbon.Peek();

                if (currentCarbon + currentSteel == 70)
                {
                    swords["Gladius"] += 1;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (currentCarbon + currentSteel == 80)
                {
                    swords["Shamshir"] += 1;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (currentCarbon + currentSteel == 90)
                {
                    swords["Katana"] += 1;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (currentCarbon + currentSteel == 110)
                {
                    swords["Sabre"] += 1;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else if (currentCarbon + currentSteel == 150)
                {
                    swords["Broadsword"] += 1;
                    steel.Dequeue();
                    carbon.Pop();
                }
                else
                {
                    steel.Dequeue();
                    carbon.Push(carbon.Pop()+5);
                }

                if (carbon.Count == 0 || steel.Count == 0)
                {
                    break;
                }

            }

            int forgedSwords = 0;
            //If at least one sword was forged: "You have forged {totalNumberOfSwords} swords."
            foreach (var sword in swords)
            {
                
                if (sword.Value > 0)
                {
                    forgedSwords+= sword.Value;
                }
 
            }
            if (forgedSwords > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords} swords.");
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
