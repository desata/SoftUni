using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] hatsSeq = Console.ReadLine().Split().Select(int.Parse).ToArray(); //last
            int[] scarfsSeq = Console.ReadLine().Split().Select(int.Parse).ToArray(); //first

            Stack<int> hats = new Stack<int>(hatsSeq);
            Queue<int> scarfs = new Queue<int>(scarfsSeq);
            List<int> sets = new List<int>();

            while (hats.Any() && scarfs.Any())
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();
                if (currentHat > currentScarf)
                {
                    sets.Add(currentHat + currentScarf);
                    hats.Pop();
                    scarfs.Dequeue();
                }
            }

        }
    }
}
