using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles2.Contracts
{
    public interface IVehicle
    {
        public double FuelQty { get;  }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        string Drive(double distance, double fuelExtraQty);

        void Refuel(double litters);


    }
}
