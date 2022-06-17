using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumption;
            TravelledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }
        
        //methods
        public void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumptionPerKilometer;

            if (FuelAmount >= neededFuel)
            {
                FuelAmount -= neededFuel;
                TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
