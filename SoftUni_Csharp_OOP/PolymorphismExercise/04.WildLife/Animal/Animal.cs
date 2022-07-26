using _04.WildLife.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildLife.Animal
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract void Eat(IFood food);

        public abstract string MakeSound();

        protected void ThrowInvalidOperationExceptionForFood(IAnimal animal, IFood food)
        {
            throw new InvalidOperationException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
    }
}
