namespace VehiclesExt.Contracts
{
    public interface IVehicle
    {
        public double FuelQty { get; }

        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        string Drive(double distance, double increasedConsumption);

        void Refuel(double litters);
    }
}
