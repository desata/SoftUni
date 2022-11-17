using Contracts.WildFarm;
using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string type, string name, double weigth)
        {
            Type = type;
            Name = name;
            Weigth = weigth;
        }
        public string Type { get; private set; }

        public string Name { get; private set; }

        public double Weigth { get; protected set; }

        public int FoodEaten { get; protected set; }

       // public string LivingRegion { get; private set; }

       //public string Breed { get; private set; }

        public virtual string AskForFood()
        {
            return $"boo";
        }

        public virtual void Eat(string food, int quantity)
        {

            if (food == "food")
            {
                this.Weigth += quantity;
                this.FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}
