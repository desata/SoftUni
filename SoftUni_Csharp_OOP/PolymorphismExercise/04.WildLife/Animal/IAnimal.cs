using _04.WildLife.Food;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildLife.Animal
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        string MakeSound();

        void Eat(IFood food);
    }
}
