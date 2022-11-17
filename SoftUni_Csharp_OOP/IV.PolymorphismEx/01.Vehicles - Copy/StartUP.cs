using System;

namespace Vehicles2
{
    public class StartUP
    {
        static void Main(string[] args)
        {

            string[] carInfo = Console.ReadLine().Split();
            double carFuelQty = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);
            Vehicle car = new Car(carFuelQty, carFuelConsumption, carTankCapacity);

            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQty = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);
            Vehicle truck = new Truck(truckFuelQty, truckFuelConsumption, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split();
            double busFuelQty = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);
            Vehicle bus = new Bus(busFuelQty, busFuelConsumption, busTankCapacity);


            int lineNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineNumbers; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                string vehicleType = command[1];
                double amount = double.Parse(command[2]);

                if (action == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(amount, 0.9));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(amount, 1.6));
                    }
                    else
                    {
                        Console.WriteLine(bus.Drive(amount, 1.4));
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                    else
                    {
                        bus.Refuel(amount);
                    }
                }
                else if (action == "DriveEmpty")
                {
                    Console.WriteLine(bus.Drive(amount, 0));
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());

        }
    }
}
