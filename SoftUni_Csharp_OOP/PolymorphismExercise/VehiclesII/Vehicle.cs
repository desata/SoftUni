using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtention
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;

        protected Vehicle(int tankCapacity, double fuelQuantity, double fuelConsimptionPerKm )
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsimptionPerKm = fuelConsimptionPerKm;
            
        }

        public double FuelQuantity 
        { 
            get => fuelQuantity;
            private set
            {
                if (value > this.TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsimptionPerKm { get; set; }


        public int TankCapacity { get; set; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km)
        => this.FuelQuantity - (km * this.FuelConsimptionPerKm) >= 0;

      

        public void Drive(double km)
        {
            if (CanDrive(km))
            {
                this.FuelQuantity -= (km * this.FuelConsimptionPerKm);
               
            }
                        
        }

        public virtual void Refill(double amount)
        {
           
            if (this.FuelQuantity + amount <= this.TankCapacity)
            {
                this.FuelQuantity += amount;
                
            }
            else
            {

                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
        }
    }
}
