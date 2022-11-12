using System;

namespace Vehicles
{
    public class StartUP
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            double carFuelQty = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            Vehicle car = new Car(carFuelQty, carFuelConsumption);


            string[] truckInfo = Console.ReadLine().Split();
            double truckFuelQty = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            Vehicle truck = new Truck(truckFuelQty, truckFuelConsumption);

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
                        Console.WriteLine(car.Drive(amount));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(amount));
                    }
                }
                else
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(amount);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(amount);
                    }
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());

        }
    }
}
