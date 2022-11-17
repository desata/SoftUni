using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public class Owl : Bird
    {
        //Owl - 0.25
        private const double weightIncrease = 0.25;

        public Owl(string type, string name, double weigth, double wingSize) : base(type, name, weigth, wingSize)
        {
        }

        public override string AskForFood()
        {
            return $"Hoot Hoot";
        }

        public override void Eat(string food, int quantity)
        {
          
            if (food.ToLower() == "meat")
            {
               this.Weigth += quantity * weightIncrease;
                this.FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
            }
        }
    }
}
