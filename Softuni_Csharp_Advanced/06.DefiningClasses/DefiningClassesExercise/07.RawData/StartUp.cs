using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                //CarName
                string model = input[0];
                //Engine
                Engine engine = new Engine
                (
                    int.Parse(input[1]),//speed
                    int.Parse(input[2]) //power
                );

                //Cargo
                Cargo cargo = new Cargo
                    (
                    int.Parse(input[3]), //weight
                    input[4] // type
                    );
                
                //Tires
                Tire[] tire = new Tire[4]
                    {
                new Tire(double.Parse(input[5]), int.Parse(input[6])),
                new Tire(double.Parse(input[7]), int.Parse(input[8])),
                new Tire(double.Parse(input[9]), int.Parse(input[10])),
                new Tire(double.Parse(input[11]), int.Parse(input[12])),


            };


                Car car = new Car(model, engine, cargo, tire);
                cars.Add(car);

            }

            string carFilter = Console.ReadLine();
            var carToPrint = new List<Car>();

            if (carFilter == "fragile")
            {
                carToPrint = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p => p.Pressure < 1)).ToList();
            }
            else if (carFilter == "flammable")
            {
                carToPrint = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250).ToList(); //engine power > 250
            }



            foreach (var car in carToPrint)
            {
                Console.WriteLine($"{car.Model}");
            }
            
        }
    }
}
