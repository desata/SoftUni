using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
        }

        public override double Consumption
            => (double)base.Consumption + 1.6;

        public override void Refill(double fuelAmount)
        {
            fuelAmount *= 0.95;
            base.Refill(fuelAmount);
        }
    }
}
