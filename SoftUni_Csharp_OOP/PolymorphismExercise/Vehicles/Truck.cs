
using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsimption) : base(fuelQuantity, fuelConsimption)
        {
        }

        public override double FuelConsimptionPerKm => base.FuelConsimptionPerKm + 1.6;

        public override void Refill(double amount)
        {
            amount *= 0.95;
            base.Refill(amount);
        }
    }
}
