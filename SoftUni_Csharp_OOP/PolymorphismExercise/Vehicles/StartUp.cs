using System;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string[] inputCar = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(inputCar[1]);
            double carConsumption = double.Parse(inputCar[2]);

            string[] inputTruck = Console.ReadLine().Split();
            double truckFuelQuantity = double.Parse(inputTruck[1]);
            double truckConsumption = double.Parse(inputTruck[2]);

            Car car = new Car(carFuelQuantity, carConsumption);
            Truck truck = new Truck(truckFuelQuantity, truckConsumption);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            { 
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Drive")
                {
                    double distance = double.Parse(input[2]);
                    if (input[1] == "Car")
                    {
                        if (car.CanDrive(distance))
                        {
                            car.Drive(distance);
                            Console.WriteLine($"Car travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else
                    {
                        if (truck.CanDrive(distance))
                        {
                            truck.Drive(distance);
                            Console.WriteLine($"Truck travelled {distance} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }

                }
                else if (input[0] == "Refuel")
                {
                    double litters = double.Parse(input[2]);
                    if (input[1] == "Car")
                    {

                        car.Refill(litters);
                    }
                    else
                    {
                        truck.Refill(litters);
                    }
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
