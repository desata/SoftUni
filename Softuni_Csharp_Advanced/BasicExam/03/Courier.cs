using System;

namespace _03_
{
    internal class Courier
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int distance = int.Parse(Console.ReadLine());
            double prisePerKm = 0;
            double cost = 0;

            if (weight < 1)
            {
                prisePerKm = 3;
            }
            else if (weight >= 1 && weight < 10)
            {
                prisePerKm = 5;
            }
            else if (weight >= 10 && weight < 40)
            {
                prisePerKm = 10;
            }
            else if (weight >= 40 && weight < 90)
            {
                prisePerKm = 15;
            }
            else if (weight >= 90 && weight < 150)
            {
                prisePerKm = 20;
            }


            if (type == "standard")
            {
                cost = distance * prisePerKm / 100;
            }
            else if (type == "express")
            {
                double add = 1;

                if (weight < 1)
                {
                    add = (prisePerKm * weight * 0.8) * distance / 100;
                }
                else if (weight >= 1 && weight < 10)
                {
                    add = (prisePerKm * weight * 0.4) * distance / 100;
                }
                else if (weight >= 10 && weight < 40)
                {
                    add = (prisePerKm * weight * 0.05) * distance / 100;
                }
                else if (weight >= 40 && weight < 90)
                {
                    add = (prisePerKm * weight * 0.02) * distance / 100;
                }
                else if (weight >= 90 && weight < 150)
                {
                    add = (prisePerKm * weight * 0.01) * distance / 100;
                }

                cost = (distance * prisePerKm) / 100 + add;
            }
            Console.WriteLine($"The delivery of your shipment with weight of {weight:F3} kg. would cost {cost:F2} lv.");
        }
    }
}
