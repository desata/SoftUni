using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
        }

        public override double Consumption
            => (double)base.Consumption + 0.9;
    }
}
