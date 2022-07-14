using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsimption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsimptionPerKm = fuelConsimption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsimptionPerKm { get; set; }


        public bool CanDrive(double km)
        => this.FuelQuantity - (km * this.FuelConsimptionPerKm) > 0;
        

        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                this.FuelQuantity -= (km * this.FuelConsimptionPerKm);
               
            }
                        
        }

        public virtual void Refill(double amount)
        {
            this.FuelQuantity += amount;
        }
    }
}
