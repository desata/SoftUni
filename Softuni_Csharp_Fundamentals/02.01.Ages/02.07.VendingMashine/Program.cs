using System;

namespace _02._07.VendingMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double money = 0;

            while (command != "Start")
            {
                //0.1, 0.2, 0.5, 1, and 2
                double inputMoney = double.Parse(command);

                if (inputMoney == 0.1 || inputMoney == 0.2 || inputMoney == 0.5 || inputMoney == 1 || inputMoney == 2)
                {
                    money += inputMoney;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {inputMoney}");
                }

                command = Console.ReadLine();
            }
            //Console.WriteLine(money);

            command = Console.ReadLine();

            while (command != "End")
            {
                string inputProduct = command;
                double productPrice = 0;

                if (inputProduct == "Nuts" && money >= 2)
                {
                    productPrice = 2;
                }
                else if (inputProduct == "Water" && money >= 0.7)
                {
                    productPrice = 0.7;
                }
                else if (inputProduct == "Crisps" && money >= 1.5)
                {
                    productPrice = 1.5;
                }
                else if (inputProduct == "Soda" && money >= 0.8)
                {
                    productPrice = 0.8;
                }
                else if (inputProduct == "Coke" && money >= 1)
                {
                    productPrice = 1;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    command = Console.ReadLine();
                    continue;
                }

                if (money >= productPrice)
                {
                    money -= productPrice;
                    Console.WriteLine($"Purchased {inputProduct.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                command = Console.ReadLine();


            }
            Console.WriteLine($"Change: {money:F2}");
        }
    }
}
