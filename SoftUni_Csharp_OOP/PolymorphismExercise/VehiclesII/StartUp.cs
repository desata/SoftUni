using System;

namespace VehiclesExtention
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string[] inputCar = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(inputCar[1]);
            double carConsumption = double.Parse(inputCar[2]);
            int carTankCapacity = int.Parse(inputCar[3]);

            string[] inputTruck = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(inputTruck[1]);
            double truckConsumption = double.Parse(inputTruck[2]);
            int truckTankCapacity = int.Parse(inputTruck[3]);

            string[] inputBus = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(inputBus[1]);
            double busConsumption = double.Parse(inputBus[2]);
            int busTankCapacity = int.Parse(inputBus[3]);

            Car car = new Car(carTankCapacity, carFuelQuantity, carConsumption);

            Truck truck = new Truck(truckTankCapacity, truckFuelQuantity, truckConsumption);

            Bus bus = new Bus(busTankCapacity, busFuelQuantity, busConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string vehicle = input[1];
                double value = double.Parse(input[2]);

                IVehicle currentVehicle = null;

                if (vehicle == "Car")
                {
                    currentVehicle = car;
                }
                else if (vehicle == "Bus")
                {
                    currentVehicle = bus;
                }
                else
                {
                    currentVehicle = truck;
                }

                if (command == "Drive")
                {
                    if (currentVehicle.CanDrive(value))
                    {
                        currentVehicle.Drive(value);
                        Console.WriteLine($"{vehicle} travelled {value} km");
                    }
                    else
                    {
                        Console.WriteLine($"{vehicle} needs refueling");
                    }
                }
                else if (command == "Refuel")
                {
                    if (value <= 0)
                    {
                        Console.WriteLine("Fuel must be a positive number");
                        continue;
                    }
                    
                        currentVehicle.Refill(value);
                    
                }
                else if (command == "DriveEmpty")
                {
                    currentVehicle.IsEmpty = true;

                    if (currentVehicle.CanDrive(value))
                    {
                        currentVehicle.Drive(value);
                        Console.WriteLine($"{vehicle} travelled {value} km");
                    }
                    else
                    {
                        Console.WriteLine($"{vehicle} needs refueling");
                    }

                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
