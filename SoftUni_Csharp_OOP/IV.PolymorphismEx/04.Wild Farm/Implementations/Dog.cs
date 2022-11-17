using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public class Dog : Mammal
    {
        private const double weightIncrease = 0.4;
        public Dog(string type, string name, double weigth, string livingRegion) : base(type, name, weigth, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return $"Woof!";
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
