using System;

namespace _02._07.VendingMashine
{
    class Program
    {
        static void Main(string[] args)
        {
            double currBalance = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double moneySpent = 0;


            while (command != "Game Time")
            {
                double gamePrice = 0;
                //string validGames = command.ToLower();
                

                if (command == "OutFall 4")
                {
                    gamePrice = 39.99;

                }
                else if (command == "CS: OG")
                {
                    gamePrice = 15.99;

                }
                else if (command == "Zplinter Zell")
                {
                    gamePrice = 19.99;

                }
                else if (command == "Honored 2")
                {
                    gamePrice = 59.99;

                }
                else if (command == "RoverWatch")
                {
                    gamePrice = 29.99;

                }
                else if (command == "RoverWatch Origins Edition")
                {
                    gamePrice = 39.99;

                }
                else
                {
                    Console.WriteLine("Not Found");
                    command = Console.ReadLine();
                    continue;

                }
                if (currBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                else if (currBalance < gamePrice)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    Console.WriteLine($"Bought {command}");
                    moneySpent += gamePrice;
                    currBalance -= gamePrice;
                }
                

                command = Console.ReadLine();
            }
            Console.Write($"Total spent: ${moneySpent:F2}. ");
            Console.WriteLine($"Remaining: ${currBalance:F2}");
            
        }
    }
}
