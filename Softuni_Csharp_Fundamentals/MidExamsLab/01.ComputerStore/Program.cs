using System;

namespace _01.ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Write a program that prints you a receipt for your new computer.
            //You will receive the parts' prices (without tax)
            //until you receive what type of customer this is - special or regular.
            //Once you receive the type of customer you should print the receipt.;

            string command = Console.ReadLine();
            double totalPriceWOTaxes = 0;
            double totalTaxes = 0;
            double total = 0;
            

            while (command != "special" || command != "regular")
            {
                if (command == "special")
                {

                    total = (totalPriceWOTaxes + totalTaxes) * 0.9;
                    break;

                }
                if (command == "regular")
                {
                    break;
                }
                else
                {
                    double partPrise = double.Parse(command);
                    //If a given price is not a positive number, you should print "Invalid price!" on the console and continue with the next price.
                    if (partPrise < 0)
                    {
                        Console.WriteLine("Invalid price!");
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        totalPriceWOTaxes += partPrise;
                        totalTaxes = totalPriceWOTaxes * 0.2d;
                    }
                    total = totalPriceWOTaxes + totalTaxes;
                }
                command = Console.ReadLine();

            }

            if (totalPriceWOTaxes == 0)
            {
                //If the total price is equal to zero, you should print "Invalid order!" on the console.
                Console.WriteLine("Invalid order!");
                return;
            }


            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalPriceWOTaxes:f2}$");
            Console.WriteLine($"Taxes: {totalTaxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:f2}$");

        }
    }
}
