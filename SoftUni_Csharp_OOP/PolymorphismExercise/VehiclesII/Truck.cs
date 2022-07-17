
using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtention
{
    public class Truck : Vehicle
    {
        public Truck(int tankCapacity, double fuelQuantity, double fuelConsimptionPerKm) : base(tankCapacity, fuelQuantity, fuelConsimptionPerKm)
        {
        }

        public override double FuelConsimptionPerKm => base.FuelConsimptionPerKm + 1.6;

        public override void Refill(double amount)
        {
            
            if (this.FuelQuantity + amount <= this.TankCapacity)
            {
                amount *= 0.95;
                base.Refill(amount);

            }
            else
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }


        }
    }
}
