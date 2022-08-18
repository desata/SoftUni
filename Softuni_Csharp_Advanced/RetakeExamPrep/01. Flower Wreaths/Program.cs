using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //16:16  17:11
            int[] liliesSequense = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); // last
            int[] rosesSequense = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //first

            Queue<int> roses = new Queue<int>(rosesSequense);
            Stack<int> lilies = new Stack<int>(liliesSequense);

            int countOfWreaths = 0;
            int decrease = 0;
            int storedFlowers = 0;

            while (roses.Any() && lilies.Any())
            {
                int currentRose = roses.Peek();
                int currentLillie = lilies.Peek() - decrease;
                int sum = currentLillie + currentRose;

                if (sum == 15)
                {
                    roses.Dequeue();
                    lilies.Pop();
                    decrease = 0;

                    countOfWreaths++;
                }
                else if (sum > 15)
                {

                    decrease += 2;
                }
                else if(sum < 15)
                {
                    storedFlowers += sum;
                    roses.Dequeue();
                    lilies.Pop();
                    decrease = 0;

                }
            }

            if (storedFlowers > 0 && storedFlowers / 15 > 0)
            {
                int add = storedFlowers / 15;
                countOfWreaths += add;
            }


            if (countOfWreaths < 5)
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
            else
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }

        }
    }
}