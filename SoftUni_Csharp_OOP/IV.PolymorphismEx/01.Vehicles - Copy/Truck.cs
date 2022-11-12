using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double FuelExtraQty = 1.6;

        public Truck(double fuelQty, double fuelConsumption) : base(fuelQty, fuelConsumption, FuelExtraQty)
        {

        }

        public override void Refuel(double litters)
        {
            base.Refuel(litters * 0.95);
        }
    }
}
