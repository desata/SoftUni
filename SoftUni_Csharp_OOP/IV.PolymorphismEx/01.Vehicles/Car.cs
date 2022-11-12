using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double FuelExtraQty = 0.9;

        public Car(double fuelQty, double fuelConsumption) : base(fuelQty, fuelConsumption, FuelExtraQty)
        {
            
        }
    }
}
