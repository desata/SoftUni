using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBoxSequence = Console.ReadLine().Split().Select(int.Parse).ToArray(); //first
            int[] secondLootBoxSequence = Console.ReadLine().Split().Select(int.Parse).ToArray(); //second
            int value = 0;

            Queue<int> firstLootBox = new Queue<int>(firstLootBoxSequence);
            Stack<int> secondLootBox = new Stack<int>(secondLootBoxSequence);

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int currentFirstLootBox = firstLootBox.Peek();
                int currentSecondLootBox = secondLootBox.Peek();
                int sum = currentFirstLootBox + currentSecondLootBox;

                if (sum % 2 == 0)
                {
                    firstLootBox.Dequeue();
                    secondLootBox.Pop();
                    value += sum;
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }

            }

            if (firstLootBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (secondLootBox.Count == 0) 
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (value >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {value}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {value}");
            }
            

        	


        }
    }
}
