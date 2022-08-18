using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Cars = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Car> Cars { get; set; }

        //Field data – collection that holds added cars
        //Method Add(Car car) – adds an entity to the data if there is an empty cell for the car.
        public void Add(Car car)
        {
            if (this.Capacity >= Cars.Count)
            {
                Cars.Add(car);
            }
        }

        //Method Remove(string manufacturer, string model) – removes the car by given manufacturer and model, if such exists, and returns bool.
        public bool Remove(string manufacturer, string model)
        {
            foreach (Car car in Cars)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    Cars.Remove(car);
                    return true;
                }
            }
            return false;
        }

        //Method GetLatestCar() – returns the latest car (by year) or null if have no cars.
        public Car GetLatestCar()
        {
            if (this.Cars.Count == 0)
            {
                return null;
            }
            return this.Cars.OrderByDescending(x => x.Year).FirstOrDefault();
        }

        //Method GetCar(string manufacturer, string model) – returns the car with the given manufacturer and model or null if there is no such car.
        public Car GetCar(string manufacturer, string model)
        {
            foreach (Car car in Cars)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    return car;
                }
            }
            return null;
        }

        //Getter Count – returns the number of cars.

        public int Count
        { 
            get => this.Cars.Count;
        }


        //GetStatistics() – returns a string in the following format:
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (Car car in Cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();

        }

    }
}
