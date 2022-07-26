using _04.WildLife.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildLife.Animal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if ((food is Vegetable) || (food is Fruit))
            {

                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.10;
            }
            else
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }
        }

        public override string MakeSound()
        =>"Squeak";
        
    }
}
