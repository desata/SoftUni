using System;
using System.Linq;
using System.Collections.Generic;

namespace _05.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingLot = new Dictionary<string, string> ();

            for (int i = 1; i <= number; i++)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string username = command[1];
                

                if (command[0] == "register")
                {
                    string licensePlate = command[2];
                    if (parkingLot.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                    }
                    else
                    {

                        parkingLot.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");

                    }
                }
                else if (command[0] == "unregister")
                {
                    if (parkingLot.ContainsKey(username))
                    {
                        parkingLot.Remove(username);    
                        Console.WriteLine($"{username} unregistered successfully");

                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");

                    }
                }
            }

            foreach (var item in parkingLot)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }


        }
    }
}
