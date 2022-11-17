using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public class Hen : Bird
    {
        private const double weightIncrease = 0.35;

        public Hen(string type, string name, double weigth, double wingSize) : base(type, name, weigth, wingSize)
        {
        }

        public override string AskForFood()
        {
            return $"Cluck";
        }

        public override void Eat(string food, int quantity)
        {

                this.Weigth += quantity * weightIncrease;
                this.FoodEaten += quantity;

        }
    }
}
