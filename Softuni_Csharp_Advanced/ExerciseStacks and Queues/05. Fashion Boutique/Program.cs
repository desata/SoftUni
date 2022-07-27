using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothesInTheBox);
            
            int rackCapacity = int.Parse(Console.ReadLine());
            int tempRackCapacity = rackCapacity;
            int numberOfRacksNeeded = 1;

            while (stack.Count > 0)
            {
                if (rackCapacity - stack.Peek() >= 0)
                {
                    rackCapacity -= stack.Pop();
                }
                else
                {
                    numberOfRacksNeeded++;
                    rackCapacity = tempRackCapacity;
                }
            }

            Console.WriteLine(numberOfRacksNeeded);

        }
    }
}
