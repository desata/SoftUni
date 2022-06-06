using System;

namespace PartyProfit_Pyhon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int companions_count = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int coins = (days * 50);

            for (int i = 1; i <= days; i++)
            {            
            if (i % 15 == 0)
            {
                companions_count += 5;
            }
            if (i % 10 == 0)
            {
                companions_count -= 2;
            }
            if (i % 5 == 0)
            {
                coins += (companions_count * 20);
                    if (i % 3 == 0)
                    {
                        coins -= (companions_count * 2);
                    }
            }
            if (i % 3 == 0)
            {
                coins -= (companions_count * 3);
            }
            if (i % 1 == 0)
            {
                coins -= (companions_count * 2);
            }
            }

            Console.WriteLine($"{companions_count} companions received {coins/(companions_count)} coins each.");
        }
    }
}
