using System;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //01. The Biscuit Factory
            //every 3rd day 75% less, 

            int biscuitPerDay = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int biscuitCompete = int.Parse(Console.ReadLine());
            double countBiscuits = 0;
            double percentage = 0;
            string result = ""; 

            for (int day = 1; day <= 30; day++)
            {
                double totalBiscuits = 0;
                if (day % 3 == 0)
                {
                    totalBiscuits = Math.Floor((biscuitPerDay * workersCount)*0.75);
                }
                else
                {
                    totalBiscuits = biscuitPerDay * workersCount;
                }
                countBiscuits += totalBiscuits;

            }
            if (countBiscuits > biscuitCompete)
            {

                percentage = (countBiscuits - biscuitCompete) / biscuitCompete * 100;
                result = ($"You produce {percentage:f2} percent more biscuits.");

            }
            else
            {
                percentage = (biscuitCompete - countBiscuits) / biscuitCompete * 100;
                result = ($"You produce {percentage:f2} percent less biscuits.");
            }


            Console.WriteLine($"You have produced {countBiscuits:f0} biscuits for the past month.");
            Console.WriteLine($"{result}");


        }
    }
}
