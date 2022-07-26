using _04.WildLife.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildLife.Animal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight,  livingRegion, breed)
        {
        }

        public override void Eat(IFood food)
        {
            if ((food is Meat) || (food is Vegetable))
            {
                this.FoodEaten += food.Quantity;
                this.Weight += food.Quantity * 0.30;
            }
            else
            {
                ThrowInvalidOperationExceptionForFood(this, food);
            }

        }

        public override string MakeSound()
        =>"Meow";
        
    }
}
