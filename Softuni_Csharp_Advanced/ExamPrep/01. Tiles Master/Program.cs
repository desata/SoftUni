using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //01. Tiles Master

            int sinkArea = 40;
            int ovenArea = 50;
            int countertopArea = 60;
            int wallArea = 70;

            Dictionary<string, int> kitchen = new Dictionary<string, int>()
            {
                ["Countertop"] = 0,
                ["Floor"] = 0,
                ["Oven"] = 0,
                ["Sink"] = 0,
                ["Wall"] = 0,
            };


            int[] whiteTilesArea = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] grayTilesArea = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> grayTiles = new Queue<int>(grayTilesArea);
            Stack<int> whiteTiles = new Stack<int>(whiteTilesArea);


            while (grayTiles.Count > 0 && whiteTiles.Count > 0)
            {
                if (grayTiles.Peek() == whiteTiles.Peek())
                {
                    if (grayTiles.Peek() + whiteTiles.Peek() == sinkArea)
                    {
                        kitchen["Sink"] += 1;

                    }
                    else if (grayTiles.Peek() + whiteTiles.Peek() == countertopArea)
                    {
                        kitchen["Countertop"] += 1;

                    }
                    else if (grayTiles.Peek() + whiteTiles.Peek() == ovenArea)
                    {
                        kitchen["Oven"] += 1;

                    }
                    else if (grayTiles.Peek() + whiteTiles.Peek() == wallArea)
                    {
                        kitchen["Wall"] += 1;

                    }
                    else
                    {
                        kitchen["Floor"] += 1;
                    }
                    grayTiles.Dequeue();
                    whiteTiles.Pop();
                }
                else
                {
                    whiteTiles.Push(whiteTiles.Pop() / 2);
                    grayTiles.Enqueue(grayTiles.Dequeue());
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.Write("White tiles left: ");
                Console.WriteLine(String.Join(", ", whiteTiles));
            }

            if (grayTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.Write("Grey tiles left: ");
                Console.WriteLine(String.Join(", ", grayTiles));
            }

           

            foreach (var location in kitchen.OrderByDescending(k => k.Value))
            {
                if (location.Value > 0)
                {

                    Console.WriteLine($"{location.Key}: {location.Value}");
                }
            }
        }
    }
}
