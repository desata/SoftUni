using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string movieName = Console.ReadLine();
            int movieLasts = int.Parse(Console.ReadLine());
            int breakLasts = int.Parse(Console.ReadLine());

            var breakRemains = (breakLasts * 0.625);

            if (breakRemains >= movieLasts)
            {
                Console.WriteLine($"You have enough time to watch {movieName} and left with {Math.Ceiling(breakRemains - movieLasts)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {movieName}, you need {Math.Ceiling(movieLasts - breakRemains)} more minutes.");
            }

        }
    }
}
