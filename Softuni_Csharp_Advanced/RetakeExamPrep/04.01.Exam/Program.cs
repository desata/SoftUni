using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._01.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] coffeeSq = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); // first
            int[] milcSeq = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //last

            Queue<int> coffee = new Queue<int>(coffeeSq);
            Stack<int> milk = new Stack<int>(milcSeq);

            Dictionary<string, int> beverage = new Dictionary<string, int>()
            {
                {"Cortado", 0 },
                {"Espresso", 0},
                {"Capuccino", 0},
                {"Americano", 0},
                {"Latte", 0}
            };

            while (coffee.Any() && milk.Any())
            {
                int currentCoffee = coffee.Dequeue();
                int correntMilk = milk.Pop();

                int sum = correntMilk + currentCoffee;

                if (sum == 50)
                {
                    beverage["Cortado"] += 1;
                }
                else if (sum == 75)
                {
                    beverage["Espresso"] += 1;
                }
                else if (sum == 100)
                {
                    beverage["Capuccino"] += 1;
                }
                else if (sum == 150)
                {
                    beverage["Americano"] += 1;
                }
                else if (sum == 200)
                {
                    beverage["Latte"] += 1;
                }
                else
                {
                    milk.Push(correntMilk - 5);

                }
            }                    

            if (coffee.Count <= 0 && milk.Count <= 0)
            { 
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            if (coffee.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milk.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var item in beverage.OrderBy(x => x.Value).ThenByDescending(x => x.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                
            }

        }
    }
}
