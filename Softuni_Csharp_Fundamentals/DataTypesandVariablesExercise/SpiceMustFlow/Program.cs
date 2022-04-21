using System;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int days = 0;
            int totalAmountSpice=0;

            while (n >= 100)
            {
                totalAmountSpice += n;
                days += 1;
                totalAmountSpice -= 26;
                n -= 10;

            }
            if (totalAmountSpice > 26)
            {
                totalAmountSpice -= 26;
            }
            
            Console.WriteLine(days);
            Console.WriteLine(totalAmountSpice);
        }
    }
}
