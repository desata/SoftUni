﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuel, double consumption)
        {
            Fuel = fuel;
            Consumption = consumption;
        }

        public double Fuel { get; set; }
        public virtual double Consumption { get; set; }

        public bool CanBeDriven(double distance)
        {
            if (Fuel - Consumption * distance < 0)
            {
                return false;
            }
            return true;
        }

        public void Drive(double distance)
        {
            if (CanBeDriven(distance))
            {
                Fuel -= Consumption * distance;
            }
        }

        public virtual void Refill(double fuelAmount)
        {
            Fuel += fuelAmount;
        }

    }
}
