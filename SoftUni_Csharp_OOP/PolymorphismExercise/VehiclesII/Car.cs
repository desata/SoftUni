using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtention
{
    public class Car : Vehicle
    {

        public Car(int tankCapacity, double fuelQuantity, double fuelConsimptionPerKm) : base(tankCapacity, fuelQuantity, fuelConsimptionPerKm)
        {
        }

        public override double FuelConsimptionPerKm => base.FuelConsimptionPerKm + 0.9;
    }
}
