using System;

namespace _03.TravelAgencyPB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //•	Когато потребителят е въвел всички данни правилно, отпечатваме: 
            //"The price is {цената, форматирана до втория знак}lv! Have a nice time!"
            //•	Когато при въвеждането на града или вида на пакета се въведат невалидни данни, отпечатваме: "Invalid input!"
            //"noEquipment",  "withEquipment",
            //"noBreakfast" или "withBreakfast"

            string town = Console.ReadLine();
            string bundle = Console.ReadLine();
            string vip = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            double price = 0;

            if (days < 1)
            {
                Console.WriteLine("Days must be positive number!");
                return;
            }
            else
            {
                if (town == "Bansko" || town == "Borovets")
                {
                    if (bundle == "noEquipment")
                    {
                        if (vip == "yes")
                        {
                            price = 80*0.95;
                        }
                        else
                        {
                            price = 80;
                        }

                    }
                    else if (bundle == "withEquipment")
                    {
                        if (vip == "yes")
                        {
                            price = 100 * 0.90;
                        }
                        else
                        {
                            price = 100;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                }
                else if (town == "Varna" || town == "Burgas")
                {
                    if (bundle == "noBreakfast")
                    {
                        if (vip == "yes")
                        {
                            price = 100 * 0.93;
                        }
                        else
                        {
                            price = 100;
                        }
                    }
                    else if (bundle == "withBreakfast")
                    {
                        if (vip == "yes")
                        {
                            price = 130 * 0.88;
                        }
                        else
                        {
                            price = 130;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    return;
                }
                if (days > 7)
                {
                    days -= 1;
                }
                double totalPrice = days * price;
                Console.WriteLine($"The price is {totalPrice:F2}lv! Have a nice time!");
            }
        }
    }
}
