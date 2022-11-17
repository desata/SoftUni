using System;
using VehiclesExt.Implementations;

namespace VehiclesExt
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            double carIncreasedConsumption = 0.9;

            Vehicle car = new Car(carFuel, carConsumption, carTankCapacity);

            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            double truckIncreasedConsumption = 1.6;

            Vehicle truck = new Truck(truckFuel, truckConsumption, truckTankCapacity);

            double busFuel = double.Parse(busInfo[1]);
            double busConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            double busIncreasedConsumption = 1.4;
            double emptyBusIncreasedConsumption = 0;

            Vehicle bus = new Bus(busFuel, busConsumption, busTankCapacity);

            int lineNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineNumbers; i++)
            {
                string[] arguments = Console.ReadLine().Split();
                string command = arguments[0];
                string vehicleType = arguments[1];
                double amount = double.Parse(arguments[2]);

                if (command == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(amount, carIncreasedConsumption));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(amount, truckIncreasedConsumption));
                    }
                    else if (vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.Drive(amount, busIncreasedConsumption));
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Refuel(amount);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    if (vehicleType == "Bus")
                    {
                        Console.WriteLine(bus.Drive(amount, emptyBusIncreasedConsumption));
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}