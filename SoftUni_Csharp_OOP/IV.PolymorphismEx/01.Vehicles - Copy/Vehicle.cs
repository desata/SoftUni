using System;
using System.Collections.Generic;
using System.Text;
using Vehicles.Contracts;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQty, double fuelConsumption, double fuelExtraQty)
        {
            FuelQty = fuelQty;
            FuelConsumption = fuelConsumption + fuelExtraQty;
        }

        public double FuelQty { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            if (this.FuelQty - distance * this.FuelConsumption >= 0)
            {
                this.FuelQty -= distance * this.FuelConsumption;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double litters)
        {
            this.FuelQty += litters;
        }

        public override string ToString()
        {
             return $"{this.GetType().Name}: {this.FuelQty:f2}";
        }
    }
}