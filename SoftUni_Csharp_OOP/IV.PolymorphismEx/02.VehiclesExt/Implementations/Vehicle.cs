using VehiclesExt.Contracts;

namespace VehiclesExt.Implementations
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQty;

        protected Vehicle(double fuelQty, double fuelConsumption, double tankCapacity)
        {
            FuelQty = fuelQty;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQty
        {
            get
            {
                return fuelQty;
            }
            private set
            {
                if (fuelQty > TankCapacity)
                {
                    FuelQty = 0;
                }
                else
                {
                    fuelQty = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }


        public string Drive(double distance, double increasedConsumption)
        {
            this.FuelConsumption += increasedConsumption;

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
                System.Console.WriteLine($"Cannot fit {litters} fuel in the tank");
            }
            else if (litters <= 0)
            {
                System.Console.WriteLine("Fuel must be a positive number");
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
