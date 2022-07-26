using _04.WildLife.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildLife.Animal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if (!(food is Meat))
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity;

        }

        public override string MakeSound()
       => "ROAR!!!";

    }
}
