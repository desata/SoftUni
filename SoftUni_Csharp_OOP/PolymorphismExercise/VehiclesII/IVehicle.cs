using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtention
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        
        public  double FuelConsimptionPerKm { get; set; }

        public int TankCapacity { get; set; }

        public bool IsEmpty { get; set; }

        public bool CanDrive(double km);

        public void Drive(double km);

        public  void Refill(double amount);


    }
}
