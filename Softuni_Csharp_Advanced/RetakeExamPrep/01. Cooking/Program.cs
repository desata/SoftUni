using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace _01._Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] liquidSeq = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); // first
            int[] ingridientSeq = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //last

            Queue<int> liquds = new Queue<int>(liquidSeq);
            Stack<int> ingridients = new Stack<int>(ingridientSeq);

            Dictionary<string, int> foods = new Dictionary<string, int>()
            {
                {"Bread", 0 },
                {"Cake", 0},
                {"Pastry", 0},
                {"Fruit Pie", 0}
            };

            while (liquds.Any() && ingridients.Any())
            {
                int currentLiquid = liquds.Dequeue();
                int currenIngridient = ingridients.Pop();

                int sum = currenIngridient + currentLiquid;

                if (sum == 25)
                {
                    foods["Bread"] += 1;
                }
                else if (sum == 50)
                {
                    foods["Cake"] += 1;
                }
                else if (sum == 75)
                {
                    foods["Pastry"] += 1;
                }
                else if (sum == 100)
                {
                    foods["Fruit Pie"] += 1;
                }
                else
                {
                    ingridients.Push(currenIngridient+3);

                }
            }

            bool IsSuccess = false;

            foreach (var food in foods)
            {
                if (food.Value > 0)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                        break;
                }

            }

            if (IsSuccess == true)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquds.Any())
            {
                Console.WriteLine($"Liquids left: {String.Join(", ", liquds)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingridients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingridients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in foods.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
