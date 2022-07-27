using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQty = int.Parse(Console.ReadLine());
            List<int> foodList = Console.ReadLine().Split().Select(int.Parse).ToList();
            Queue<int> food = new Queue<int>(foodList);

            Console.WriteLine(food.Max());

            while (food.Count > 0 && foodQty > 0)
            {
                if (foodQty >= food.Peek())
                {
                    foodQty -= food.Dequeue();
                }
                else
                {
                    Console.Write("Orders left: ");
                    Console.Write(String.Join(" ", food));
                    break;
                }
            }

            if (food.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
