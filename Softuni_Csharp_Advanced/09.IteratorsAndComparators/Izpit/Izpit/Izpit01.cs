using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace Izpit01
{       //01. Tiles Master
    internal class Izpit01
    {
        static void Main(string[] args)
        {

            //First, you will be given a sequence of numbers, representing the areas of the white tiles. Afterward, you will be given another sequence, representing the areas of the grey tiles.
            int[] whiteTilesArea = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); // queue
            int[] greyTilesArea = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //stack


            Stack<int> whiteTiles = new Stack<int>(whiteTilesArea);
            Queue<int> greyTiles = new Queue<int>(greyTilesArea);
            //You start from the first grey tile and compare its area to the area of the last white tile.

            Dictionary<string, int> locations = new Dictionary<string, int>()
            {
                { "Countertop", 0 },
                { "Floor", 0 },
                { "Oven", 0},
                { "Sink", 0},
                { "Wall", 0 }
            };

            while (whiteTiles.Count !=0 && greyTiles.Count != 0)
            {
                int currentWhite = whiteTiles.Peek();
                int currentGray = greyTiles.Peek();
                int tileSum = currentWhite + currentGray;

                if (currentWhite == currentGray)
                {
                    if (tileSum == 40)
                    {
                        locations["Sink"] += 1;
                    }
                    else if (tileSum == 50)
                    {
                        locations["Oven"] += 1;
                    }
                    else if (tileSum == 60)
                    {
                        locations["Countertop"] += 1;
                    }
                    else if (tileSum == 70)
                    {
                        locations["Wall"] += 1;
                    }
                    else
                    {
                        locations["Floor"] += 1;
                    }
                    whiteTiles.Pop();
                    greyTiles.Dequeue();

                }
                else
                {

                    whiteTiles.Push(whiteTiles.Pop()/2);
                    greyTiles.Enqueue(greyTiles.Dequeue());
                }

                if (whiteTiles.Count == 0 || greyTiles.Count == 0)
                {
                    break;
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            var sortedlocations = new Dictionary<string, int>
                (locations.OrderByDescending(x => x.Value).ThenBy(x => x.Key));

            foreach (var location in sortedlocations)
            {
                if (location.Value == 0) continue;
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
