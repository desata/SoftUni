using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<string>> engines = new Dictionary<string, List<string>>();
            for (int i = 1; i <= n; i++)
            {
                string engineCommand = Console.ReadLine();
                string[] splitted = engineCommand.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = splitted[0];
                int power = int.Parse(splitted[1]);
                Engine engine = new Engine();
                engine.Model = model;
                engine.Power = power;
                engine.Displacement = "n/a";
                engine.Efficiency = "n/a";

                if (splitted.Length == 3)
                {
                    if (char.IsDigit(splitted[2][0]))
                    {
                        engine.Displacement = splitted[2];
                    }
                    else
                    {
                        engine.Efficiency = splitted[2];
                    }
                }
                else if (splitted.Length == 4)
                {
                    engine.Displacement = splitted[2];
                    engine.Efficiency = splitted[3];
                }

                engines.Add(engine.Model, new List<string> { engine.Power.ToString(),
                    engine.Displacement, engine.Efficiency });
            }
            int m = int.Parse(Console.ReadLine());
            List<Car> listCars = new List<Car>();
            for (int i = 1; i <= m; i++)
            {
                string carCommand = Console.ReadLine();

                string[] splitted = carCommand.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = splitted[0];
                string engine = splitted[1];
                string weight = "n/a";
                string color = "n/a";
                if (splitted.Length == 3)
                {
                    if (char.IsDigit(splitted[2][0]))
                    {
                        weight = splitted[2];
                    }
                    else
                    {
                        color = splitted[2];
                    }
                }
                else if (splitted.Length == 4)
                {
                    weight = splitted[2];
                    color = splitted[3];
                }
                Car car = new Car(model, engine, engines[engine][0], engines[engine][1], engines[engine][2],
                    weight, color);
                listCars.Add(car);
            }

            for (int i = 0; i < listCars.Count; i++)
            {
                Car car = listCars[i];
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine}:");
                Console.WriteLine($"    Power: {car.EnginePower}");
                Console.WriteLine($"    Displacement: {car.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
