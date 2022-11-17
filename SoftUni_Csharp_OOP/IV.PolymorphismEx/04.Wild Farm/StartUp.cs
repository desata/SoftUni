using System;
using System.Collections;
using System.Collections.Generic;
using Contracts.WildFarm;
using WildFarm.Implementations;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;

            Dictionary<string, IAnimal> animals = new Dictionary<string, IAnimal>();

            string command = Console.ReadLine();

            while (command != "End")
            {

                string[] arg = command.Split();

                string type = arg[0];
                string name = arg[1];
                double weight = double.Parse(arg[2]);

                if (type == "Hen")
                {
                    double wingSize = double.Parse(arg[3]);

                    animal = new Hen(type, name, weight, wingSize);

                }
                else if (type == "Owl")
                {
                    double wingSize = double.Parse(arg[3]);

                    animal = new Owl(type, name, weight, wingSize);
                }
                else if (type == "Mouse")
                {
                    string livindRegion = arg[3];

                    animal = new Mouse(type, name, weight, livindRegion);
                }
                else if (type == "Dog")
                {
                    string livindRegion = arg[3];

                    animal = new Dog(type, name, weight, livindRegion);
                }
                else if (type == "Cat")
                {
                    string livindRegion = arg[3];
                    string breed = arg[4];

                    animal = new Cat(type, name, weight, livindRegion, breed);
                }
                else if (type == "Tiger")
                {
                    string livindRegion = arg[3];
                    string breed = arg[4];

                    animal = new Tiger(type, name, weight, livindRegion, breed);
                }

                Console.WriteLine(animal.AskForFood());

                string[] foodInfo = Console.ReadLine().Split();
                string food = foodInfo[0];
                int qty = int.Parse(foodInfo[1]);

                animal.Eat(food, qty);

                animals.Add(type, animal);

                command = Console.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item.Value.ToString());
            }

        }
    }
}
