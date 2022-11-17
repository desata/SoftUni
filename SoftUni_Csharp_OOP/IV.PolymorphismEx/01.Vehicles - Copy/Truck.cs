namespace Vehicles2
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQty, double fuelConsumption, double tankCapacity) : base(fuelQty, fuelConsumption, tankCapacity)
        {
        }

        public override void Refuel(double litters)
        {
            base.Refuel(litters * 0.95);
        }
    }
}
