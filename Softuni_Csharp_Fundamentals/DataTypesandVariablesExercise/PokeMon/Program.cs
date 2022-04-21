using System;

namespace PokeMon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int power = int.Parse(Console.ReadLine());
            int N = power;
            int distance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int countPoked = 0;

            while (power >= distance)
            {

                power -= distance;
                countPoked += 1;

                if (N * 0.5 == power && exhaustionFactor > 0)
                {

                    power /= exhaustionFactor;


                }

            }

            Console.WriteLine(power);
            Console.WriteLine(countPoked);
        }
    }
}
