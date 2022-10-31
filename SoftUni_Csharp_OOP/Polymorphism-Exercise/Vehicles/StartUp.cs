using System;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            double carFuel = double.Parse(carInfo[1]);
            double carConsumption = double.Parse(carInfo[2]); 
            
            double truckFuel = double.Parse(truckInfo[1]);
            double truckConsumption = double.Parse(truckInfo[2]);

            Car car = new Car(carFuel, carConsumption);
            Truck truck = new Truck(truckFuel, truckConsumption);

            int n = int.Parse(Console.ReadLine());
                       

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                string action = command[0];
                string vehicle = command[1];
                double amount = double.Parse(command[2]);


                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        if (car.CanBeDriven(amount))
                        {
                            car.Drive(amount);
                            Console.WriteLine($"{vehicle} travelled {amount} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }

                    }
                    else if (vehicle == "Truck")
                    {
                        if (truck.CanBeDriven(amount))
                        {
                            truck.Drive(amount);
                            Console.WriteLine($"{vehicle} travelled {amount} km");
                        }
                        else
                        {
                            Console.WriteLine($"{vehicle} needs refueling");
                        }

                    }

                }
                else if (action == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refill(amount);
                    }
                    else
                    {
                        truck.Refill(amount);
                    }
                }
            }
            Console.WriteLine($"Car: {car.Fuel:F2}");
            Console.WriteLine($"Truck: {truck.Fuel:F2}");
        }
    }
}
