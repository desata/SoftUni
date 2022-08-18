using System;

namespace _02
{
    internal class Football
    {
        static void Main(string[] args)
        {
            double tshirtPrice = double.Parse(Console.ReadLine());
            double targetPrice = double.Parse(Console.ReadLine());
            double shortsPrice = tshirtPrice * 0.75;
            double socksPrice = shortsPrice * 0.2;
            double buttonsPrice = 2 * (tshirtPrice+shortsPrice);
            
            double totalPrice = (tshirtPrice + shortsPrice + socksPrice + buttonsPrice)*0.85;

            if (totalPrice >= targetPrice )
            {
                Console.WriteLine("Yes, he will earn the world-cup replica ball!");
                Console.WriteLine($"His sum is {totalPrice:F2} lv.");
            }
            else
            {
                Console.WriteLine("No, he will not earn the world-cup replica ball.");
                Console.WriteLine($"He needs {targetPrice-totalPrice:F2} lv. more.");
            }

        }
    }
}
