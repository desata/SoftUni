using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string type, string name, double weigth, string livingRegion) : base(type, name, weigth)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.Weigth}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}