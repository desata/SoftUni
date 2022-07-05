using System;

namespace _06._Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //
            double nylonPrise = 1.5;
            double paintPrise = 14.5;
            double AMBPrise = 5;
            double bags = 0.4;

            // + 10% paint
            // + 2sqm nylon
            // + 0.4 bags
            // amountPerHour = 30% materials

            //input
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int AMB = int.Parse(Console.ReadLine());
            int hoursNeeded = int.Parse(Console.ReadLine());

            double Expences = 0;

            Expences = bags + ((nylon + 2) * 1.5) + ((paint * 1.1) * 14.5) + (AMB * AMBPrise);
            double totalHoursPrice = (Expences * 0.3) * hoursNeeded;
            double totalExpences = Expences + totalHoursPrice;

            Console.WriteLine($"{totalExpences:F2}");
        }
    }
}
