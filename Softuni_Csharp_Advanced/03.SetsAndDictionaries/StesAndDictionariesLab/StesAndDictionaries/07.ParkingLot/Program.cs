using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The input will be a string in the format: "direction, carNumber". You will be receiving commands until the "END" command is given.

            //add, remove, search

            string[] input = Console.ReadLine().Split(", ");
            HashSet<string> parkingLot = new HashSet<string>();

            while (input[0] != "END")
            {
                string direction = input[0];
                string plateNumber = input[1];

                if (direction == "IN")
                {
                    parkingLot.Add(plateNumber);
                }
                else if (direction == "OUT")
                { 
                parkingLot.Remove(plateNumber);
                
                }

                input = Console.ReadLine().Split(", ");
            }

            if (parkingLot.Count > 0)
            {
                foreach (var car in parkingLot)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }

        }
    }
}
