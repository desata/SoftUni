using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public class Tiger : Feline
    {


        public Tiger(string type, string name, double weigth, string livingRegion, string breed) : base(type, name, weigth, livingRegion, breed)
        {
        }             

        public override string AskForFood()
        {
            return $"ROAR!!!";
        }

        public override void Eat(string food, int quantity)
        {

            if (food.ToLower() == "meat")
            {
                this.Weigth += quantity;
                this.FoodEaten += quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food}!");
            }
        }
    }
}
