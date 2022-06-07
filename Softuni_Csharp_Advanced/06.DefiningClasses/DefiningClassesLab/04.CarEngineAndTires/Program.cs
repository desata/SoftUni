using System;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Car car = new Car();

            Tire[] tire = new Tire[4]
                {
                new Tire(1, 2.5),
                new Tire(1, 2.1),
                new Tire(2, 0.5),
                new Tire(2, 2.3),
                };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("Lamborgini", "Urus", 2020, 250, 9, engine, tire);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
