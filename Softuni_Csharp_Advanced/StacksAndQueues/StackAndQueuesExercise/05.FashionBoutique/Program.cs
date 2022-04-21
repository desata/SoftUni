using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] boxOfClothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stackOfClothes = new Stack<int>(boxOfClothes);
            int rackCapacity = int.Parse(Console.ReadLine());
            int newrackCapacity = rackCapacity;
            int rackCount = 1;

            while (stackOfClothes.Count > 0)
            {
                int currentClothe = stackOfClothes.Peek();

                if (rackCapacity - currentClothe < 0)
                {
                    rackCount++;
                    rackCapacity = newrackCapacity;
                }
                else
                {
                    rackCapacity -= currentClothe;
                    stackOfClothes.Pop();
                }
            }
            Console.WriteLine(rackCount);

        }
    }
}
