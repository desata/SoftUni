using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that calculates the ratio between water and flour for predefined bakery products.

            decimal[] waterQty = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            decimal[] flourQty = Console.ReadLine().Split().Select(decimal.Parse).ToArray();

            Queue<decimal> water = new Queue<decimal>(waterQty); //opawka
            Stack<decimal> flour = new Stack<decimal>(flourQty); //stack

            Dictionary<string, int> bakeryProduct = new Dictionary<string, int>()
            {
                { "Croissant", 0},
                { "Muffin", 0 },
                { "Baguette", 0},
                { "Bagel", 0},

            };

            while (water.Count > 0 && flour.Count > 0)
            {
                decimal currWater = water.Peek();
                decimal currFlour = flour.Peek();

                if (currWater == currFlour)
                {
                    bakeryProduct["Croissant"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if ((6*currWater) == (4*currFlour))
                {
                    bakeryProduct["Muffin"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if ((7 * currWater) == (3 * currFlour))
                {
                    bakeryProduct["Baguette"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else if ((8 * currWater) == (2 * currFlour))
                {
                    bakeryProduct["Bagel"] += 1;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    bakeryProduct["Croissant"] += 1;
                    water.Dequeue();
                    flour.Push(flour.Pop() - currWater);
                }

                if (water.Count == 0 || flour.Count == 0)
                {
                    break;
                }
            }

            foreach (var product in bakeryProduct.OrderByDescending(r => r.Value)
                .ThenBy(r => r.Key))
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key}: {product.Value}");
                }
            }

            if (water.Count > 0)
            {
                Console.WriteLine($"Water left: {String.Join(", ", water)}");
            }
            else
            {
                Console.WriteLine("Water left: None");
            }

            if (flour.Count > 0)
            {
                Console.WriteLine($"Flour left: {String.Join(", ", flour)}");
            }
            else
            {
                Console.WriteLine("Flour left: None");
            }
        }
    }
}
