using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();


            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]); 

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);


            }
            Console.WriteLine();

            string command = Console.ReadLine();
            while (command != "End")
            {
                //"drive {carModel} {amountOfKm}"
                string carModel = command.Split()[1];
                double amountOfKm = double.Parse(command.Split()[2]);

                Car CarToDrive = cars.First(cars => cars.Model == carModel);
                CarToDrive.Drive(amountOfKm);


                command = Console.ReadLine();
            }
            //After the "End" command is received, print each car and its current fuel amount and the traveled distance in the format:
            //"{model} {fuelAmount} {distanceTraveled}"
            //Print the fuel amount formatted two digits after the decimal separator.

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}
