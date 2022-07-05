using System;

namespace _05._Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пакет химикали - 5.80 лв. 
            //Пакет маркери - 7.20 лв.
            //Препарат - 1.20 лв(за литър)



            //Брой пакети химикали - цяло число в интервала[0...100]
            //Брой пакети маркери - цяло число в интервала[0...100]
            //Литри препарат за почистване на дъска -цяло число в интервала[0…50]
            //Процент намаление -цяло число в интервала[0...100]

            int penPackage = int.Parse(Console.ReadLine());
            int textMarkerPackage = int.Parse(Console.ReadLine());
            int boardCleanningLiquid = int.Parse(Console.ReadLine());
            double discount = int.Parse(Console.ReadLine());
            double totalSum = (penPackage * 5.8) + (textMarkerPackage * 7.2) + (boardCleanningLiquid * 1.2);
            totalSum -= totalSum * (discount/100);
            //Да се отпечата на конзолата колко пари ще са нужни, за да си плати сметката.

            Console.WriteLine(totalSum);
        }
    }
}
