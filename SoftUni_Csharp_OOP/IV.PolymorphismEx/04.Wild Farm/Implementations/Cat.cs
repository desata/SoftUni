using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public class Cat : Feline
    {
        private const double weightIncrease = 0.30;
        public Cat(string type, string name, double weigth, string livingRegion, string breed) : base(type, name, weigth, livingRegion, breed)
        {
        }

        public override string AskForFood()
        {
            return $"Meow";
        }

        public override void Eat(string food, int quantity)
        {

            if (food.ToLower() == "meat" || food.ToLower() == "vegetable")
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
