using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program that reads a sequence of numbers and a special bomb number holding a certain power.
            //Your task is to detonate every occurrence of the special bomb number and according to its power the numbers to its left and right.
            //The bomb power refers to how many numbers to the left and right will be removed, no matter their values.
            //Detonations are performed from left to right and all the detonated numbers disappear.
            //Finally, print the sum of the remaining elements in the sequence.

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombAndPower = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                int bomb = bombAndPower[0];
                int power = bombAndPower[1];

                if (numbers[i] == bomb)
                {
                    int startPoint = (i - power);
                    int endPoint = power + 1;
                    if (i - power < 0)
                    {
                      numbers.RemoveRange(0, i + power);
                    }
                    else if ((i + power) > numbers.Count)
                    {
                        numbers.RemoveRange(startPoint, endPoint + (numbers.Count-1-i));
                    }
                    else
                    {

                        numbers.RemoveRange(startPoint, 2 * endPoint);
                    }
                    i = startPoint - 1;
                 }
                
            }

            for (int j = 0; j < numbers.Count; j++)
            {
                sum = sum + numbers[j];
            }
            Console.WriteLine(sum);

        }
    }
}
