﻿using System;
using System.Collections.Generic;
using System.Text;
using Vehicles2.Contracts;

namespace Vehicles2
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQty, double fuelConsumption, double tankCapacity)
        {
            FuelQty = fuelQty;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQty
        {
            get { return this.FuelQty; }
            private set
            {
                if (value > this.TankCapacity)
                {
                    FuelQty = 0;
                }
                else
                {
                    FuelQty = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }


        public string Drive(double distance, double fuelExtraQty)
        {
            FuelConsumption += fuelExtraQty;

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


            if (this.FuelQty + litters > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            else
            {
                this.FuelQty += litters;
            }
            
        }

        public override string ToString()
        {
             return $"{this.GetType().Name}: {this.FuelQty:f2}";
        }
    }
}