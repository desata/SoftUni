using System;

namespace _07._Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //menus
            double chickenMenu = 10.35;
            double fishMenu = 12.40;
            double veggieMenu = 8.15;
            double delivery = 2.5;

            int chickenMenuCount = int.Parse(Console.ReadLine());
            int fishMenuCount = int.Parse(Console.ReadLine());
            int veggieMenuCount = int.Parse(Console.ReadLine());


            double bill = (chickenMenu * chickenMenuCount) + (fishMenu * fishMenuCount) + (veggieMenu * veggieMenuCount);
            double dessert = 0.2 * bill;

            double totalPrice = delivery + bill + dessert;

            Console.WriteLine(totalPrice);
        }
    }
}
