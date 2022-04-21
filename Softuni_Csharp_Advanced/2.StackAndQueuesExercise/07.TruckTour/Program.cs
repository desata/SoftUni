using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The first line will contain the value of N
            //The next N lines will contain a pair of integers each,
            //i.e.the amount of petrol that petrol pump will give and the distance between that petrol pump and the next petrol pump

            int petrolPumpsCount = int.Parse(Console.ReadLine());
            Queue<int[]> pump = new Queue<int[]>();

            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] petrolPump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                pump.Enqueue(petrolPump);

            }

            int startIndex = 0;


            while (true)
            {
                bool isComplete = true;
                int totalAmountPetrol = 0;

                foreach (int[] item in pump)
                {
                    int amountPetrol = item[0];
                    int distance = item[1];
                    totalAmountPetrol += amountPetrol;

                    if (totalAmountPetrol - distance < 0)
                    {
                        int[] currentPump = pump.Dequeue();
                        pump.Enqueue(currentPump);
                        startIndex++;
                        isComplete = false;
                        break;

                    }
                    totalAmountPetrol -= distance;

                }
                if (isComplete)
                {
                    Console.WriteLine(startIndex);
                    break;
                }

            }

        }
    }
}
