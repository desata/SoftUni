using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public class Mouse : Mammal
    {
        private const double weightIncrease = 0.1;
        public Mouse(string type, string name, double weigth, string livingRegion) : base(type, name, weigth, livingRegion)
        {
        }

        public override string AskForFood()
        {
            return $"Squeak";
        }

        public override void Eat(string food, int quantity)
        {

            if (food.ToLower() == "vegetable" || food.ToLower() == "fruit")
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
