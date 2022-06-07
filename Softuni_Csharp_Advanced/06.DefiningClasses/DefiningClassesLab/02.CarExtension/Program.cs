using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "Passat";
            car.Year = 2022;
            car.FuelQuantity = 200;
            car.FuelConsumption = 200;

            car.Drive(0.2);
            Console.WriteLine(car.WhoAmI());

        }
    }
}
