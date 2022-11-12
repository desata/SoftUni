using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Contracts
{
    public interface IVehicle
    {
        public double FuelQty { get;  }

        public double FuelConsumption { get; }

        string Drive(double distance);

        void Refuel(double litters);


    }
}
