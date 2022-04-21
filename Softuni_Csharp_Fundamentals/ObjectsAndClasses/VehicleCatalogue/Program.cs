using System;
using System.Collections.Generic;
using System.Linq;

namespace VehicleCatalogue
{
    class Car
    {
        //Brand, Model, and Horse Power
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Weight { get; set; }
    }
    class Catalog
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
        public Catalog()
        {
            Cars = new List<Car>();

            Trucks = new List<Truck>();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("/");
            Catalog catalog = new Catalog();

            while (input[0] != "end")
            {

                Truck trucks = new Truck();

                if (input[0] == "Car")
                {
                    Car cars = new Car();
                    cars.Brand = input[1];
                    cars.Model = input[2];
                    cars.HorsePower = int.Parse(input[3]);
                    catalog.Cars.Add(cars);

                }
                else if (input[0] == "Truck")
                {
                    trucks.Brand = input[1];
                    trucks.Model = input[2];
                    trucks.Weight = int.Parse(input[3]);
                    catalog.Trucks.Add(trucks);

                }
                input = Console.ReadLine().Split("/");

            }

            if (catalog.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in catalog.Cars.OrderBy(car => car.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalog.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalog.Trucks.OrderBy(truck => truck.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }
}
