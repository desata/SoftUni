namespace VehiclesExt.Implementations
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQty, double fuelConsumption, double tankCapacity) : base(fuelQty, fuelConsumption, tankCapacity)
        {
        }

        public override void Refuel(double litters)
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
                litters *= 0.95;
                base.Refuel(litters);
            }


        }
    }
}
