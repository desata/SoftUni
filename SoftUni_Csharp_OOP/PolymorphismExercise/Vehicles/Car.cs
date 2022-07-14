using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsimption) : base(fuelQuantity, fuelConsimption)
        {
        }

        public override double FuelConsimptionPerKm => base.FuelConsimptionPerKm + 0.9;
    }
}
