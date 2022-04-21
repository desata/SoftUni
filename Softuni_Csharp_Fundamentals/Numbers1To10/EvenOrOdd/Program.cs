using System;

namespace EvenOrOdd
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
    }
}

/*
 Да се напише програма, която чете цяло число въведено от потребителя и отпечатва на конзолата, дали е четно или нечетно. 
 */