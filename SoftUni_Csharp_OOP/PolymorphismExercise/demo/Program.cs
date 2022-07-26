using System;

namespace demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputCar = Console.ReadLine().Split();
            double carFuelQuantity = double.Parse(inputCar[1]);
            double carConsumption = double.Parse(inputCar[2]);
            int carTankCapacity = int.Parse(inputCar[3]);

            if (carFuelQuantity > carTankCapacity)
            {
                carFuelQuantity = 0;

            }
            var car = new Car(carFuelQuantity, carConsumption, carTankCapacity);
            Console.WriteLine($"{carFuelQuantity} {carConsumption} {carTankCapacity}");
        }
    }
    public class Car
    {
        public Car(double fuelQuantity, double fuelConsimption, int tankCapacity) 
        {
        }

    }
}
