using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //On the first line, you will be given the quantity of your food - an integer in the range [0, 1000]
            //On the second line, you will receive a sequence of integers, representing each order, separated by a single space

            // 348
            // 20 54 30 16 7 9

            // 499
            // 57 45 62 70 33 90 88 76


            int foodQty = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> foodOrders = new Queue<int>(orders);
            Console.WriteLine(orders.Max());

            while (foodOrders.Count > 0 && foodQty > 0)
            {
                int currentOrder = foodOrders.Peek();

                if (foodQty - currentOrder < 0)
                {
                    break;
                }
                
                foodQty -= currentOrder;
                foodOrders.Dequeue();
            }
            if (foodOrders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", foodOrders)}");  
               
            }
            else
            {
                 Console.WriteLine("Orders complete");
            }

        }
    }
}
