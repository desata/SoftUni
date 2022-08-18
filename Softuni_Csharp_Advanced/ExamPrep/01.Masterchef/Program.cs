using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ingridientsNumber = Console.ReadLine().Split().Select(int.Parse).ToArray(); //first
            int[] freshnessNumber = Console.ReadLine().Split().Select(int.Parse).ToArray();   //last

            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>();

            Queue<int> ingridients = new Queue<int>(ingridientsNumber);
            Stack<int> freshness = new Stack<int>(freshnessNumber);

            while (ingridients.Count > 0 && freshness.Count > 0)
            {
                int currentIngridient = ingridients.Dequeue();
                

                if (currentIngridient == 0)
                {
                    continue;
                }                

                int currentFreshness = freshness.Pop();
                int totalFreshness = (currentIngridient * currentFreshness);

                if (totalFreshness == 150)
                {
                    if (dishes.ContainsKey("Dipping sauce"))
                    {
                        dishes["Dipping sauce"] += 1;
                    }
                    dishes.Add("Dipping sauce", 1);
                }
                else if (totalFreshness == 250)
                {
                    if (dishes.ContainsKey("Green salad"))
                    {
                        dishes["Green salad"] += 1;
                    }

                    dishes.Add("Green salad", 1);
                }
                else if (totalFreshness == 300)
                {
                    if (dishes.ContainsKey("Chocolate cake"))
                    {
                        dishes["Chocolate cake"] += 1;
                    }

                    dishes.Add("Chocolate cake", 1);
                }
                else if (totalFreshness == 400)
                {
                    if (dishes.ContainsKey("Lobster"))
                    {
                        dishes["Lobster"] += 1;
                    }

                    dishes.Add("Lobster", 1);
                }
                else
                {
                    ingridients.Enqueue(currentIngridient + 5);
                }
            }

            if (dishes.Keys.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }


            if (ingridients.Count > 0)
            {
                int sumOfIngidients = 0;
                foreach (var ingridient in ingridients)
                {
                    sumOfIngidients += ingridient;
                }
                Console.WriteLine($"Ingredients left: {sumOfIngidients}");
            }

            foreach (var dish in dishes)
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }

        }
    }
}
