using _04.WildLife.Animal;
using _04.WildLife.Food;
using System;
using System.Collections.Generic;

namespace _04.WildLife
{
    public class StartUp
    {
        static void Main()
        {
            List<IAnimal> animals = new List<IAnimal>();
            string input = Console.ReadLine();

            while (input != "End")
            {


                string[] animalInfo = input.Split();
                string[] foodInfo = Console.ReadLine().Split();

                string type = animalInfo[0];
                string name = animalInfo[1];
                double weight = double.Parse(animalInfo[2]);

                string foodType = foodInfo[0];
                int foodQty = int.Parse(foodInfo[1]);

                try
                {
                    IAnimal currAnimal = null;

                    if (type == "Hen" || type == "Owl")
                    {

                        double wingSize = double.Parse(animalInfo[3]);
                        if (type == "Hen")
                        {
                            currAnimal = new Hen(name, weight, wingSize);
                        }
                        else
                        {
                            currAnimal = new Owl(name, weight, wingSize);

                        }

                    }
                    else if (type == "Mouse" || type == "Dog")
                    {
                        string livingRegion = animalInfo[3];
                        if (type == "Mouse")
                        {
                            currAnimal = new Mouse(name, weight, livingRegion);
                        }
                        else
                        {
                            currAnimal = new Dog(name, weight, livingRegion);

                        }

                    }
                    else if (type == "Cat" || type == "Tiger")
                    {
                        string livingRegion = animalInfo[3];
                        string breed = animalInfo[4];

                        if (type == "Cat")
                        {
                            currAnimal = new Cat(name, weight, livingRegion, breed);
                        }
                        else
                        {
                            currAnimal = new Tiger(name, weight, livingRegion, breed);
                        }
                    }
                    
                    Console.WriteLine(currAnimal.MakeSound());
                    animals.Add(currAnimal);

                    IFood food = null;

                    if (foodType == "Vegetable")
                    {
                        food = new Vegetable(foodQty);
                    }
                    else if (foodType == "Fruit")
                    {
                        food = new Fruit(foodQty);
                    }
                    else if (foodType == "Meat")
                    {
                        food = new Meat(foodQty);
                    }
                    else if (foodType == "Seeds")
                    {
                        food = new Seeds(foodQty);
                    }

                    currAnimal.Eat(food);

                    
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }

        }
    }
}
