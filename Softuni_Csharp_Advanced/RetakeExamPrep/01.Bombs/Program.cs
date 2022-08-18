using System;
using System.Collections.Generic;
using System.Linq;

namespace bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //11:25 - 12:14

            //You will be given a two sequence of integers, representing bomb effects and bomb casings.

            int[] effects = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //first
            int[] casings = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray(); //last

            Queue<int> bombEffects = new Queue<int>(effects);
            Stack<int> bombCasings = new Stack<int>(casings);

            var bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs", 0},
                {"Cherry Bombs", 0},
                {"Smoke Decoy Bombs", 0}
            };
            int decrease = 0;
            int datura = 40;
            int cherry = 60;
            int smoke = 120;
            
            bool HasSucceded = false;

            while (bombEffects.Any() && bombCasings.Any())
            {
                int currentEffect = bombEffects.Peek() - decrease;
                int currentCasing = bombCasings.Peek();
                int sum = currentEffect + currentCasing;

                if (sum == datura)
                {
                    bombs["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    decrease = 0;
                }
                else if (sum == cherry)
                {
                    bombs["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    decrease = 0;
                }
                else if (sum == smoke)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                    decrease = 0;
                }
                else
                {
                    decrease += 5;
                }

                if (bombs.Values.All(x => x >=3))
                {
                    HasSucceded = true;
                    break;
                }

            }
            if (HasSucceded)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (!bombEffects.Any())
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }


            if (!bombCasings.Any())
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }
    }
}
