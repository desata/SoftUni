using System;

namespace _02._10RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardtPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    total += headsetPrice;
                }
                if (i % 3 == 0)
                {
                    total += mousePrice;
                }
                if (i % 6 == 0)
                {
                    total += keyboardtPrice;
                }
                if (i % 12 == 0)
                {
                    total += displayPrice;
                }

            }
            //int trashedDisplay = lostGames / 12;
            //int trashedKeyboard = lostGames / 6;
            //int trashedMouse = lostGames / 3;
            //int trashedHeadset = lostGames / 2;
            //double total = ((trashedHeadset* headsetPrice) + (displayPrice*trashedDisplay) + (keyboardtPrice*trashedKeyboard) + (mousePrice*trashedMouse));

            Console.WriteLine($"Rage expenses: {total:F2} lv.");
        }
    }
}
