using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //If the bullet has a smaller or equal size to the current lock, print "Bang!", then remove the lock. If not, print "Ping!", leaving the lock intact. The bullet is removed in both cases.
            //If Sam runs out of bullets in his barrel, print "Reloading!" on the console, then continue shooting.If there aren’t any bullets left, don’t print it.
            //The program ends when Sam either runs out of bullets, or the safe runs out of locks.

            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletsInput);
            int[] locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(locksInput);
            int valueOfIntelligence = int.Parse(Console.ReadLine());
            int shoots = 0;
            int bulletsShooted = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {

                
                    int currentBullet = bullets.Pop();
                    int currentLock = locks.Peek();
                    bulletsShooted ++;
                    if (currentBullet <= currentLock)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                        shoots++;
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                        shoots++;
                    }
                    if (bullets.Count > 0 && gunBarrelSize == shoots)
                    {
                        Console.WriteLine("Reloading!");
                        shoots = 0;
                    }               
            }
            if (bullets.Count == 0 && locks.Count >0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            if (bullets.Count >= 0 && locks.Count == 0)
            {
                int profit = valueOfIntelligence - (bulletsShooted*bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${profit}");
            }
            //•	 If Sam runs out of bullets before the safe runs out of locks, print:
            //"Couldn't get through. Locks left: {locksLeft}"
            //If Sam manages to open the safe, print:
            //"{bulletsLeft} bullets left. Earned ${moneyEarned}"
            //Make sure to account for the price of the bullets when calculating the money earned.


        }
    }
}
