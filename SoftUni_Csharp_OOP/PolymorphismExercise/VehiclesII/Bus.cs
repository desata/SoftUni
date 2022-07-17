using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtention
{
    internal class Bus : Vehicle
    {
        public Bus(int tankCapacity, double fuelQuantity, double fuelConsimptionPerKm) : base (tankCapacity, fuelQuantity, fuelConsimptionPerKm)
        {
        }

        public override double FuelConsimptionPerKm 
            => this.IsEmpty
            ? base.FuelConsimptionPerKm
            : base.FuelConsimptionPerKm + 1.4;


    }
}
