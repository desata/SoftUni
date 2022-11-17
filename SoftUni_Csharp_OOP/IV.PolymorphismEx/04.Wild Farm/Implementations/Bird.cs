using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public abstract class Bird : Animal
    {
        protected Bird(string type, string name, double weigth, double wingSize) : base(type, name, weigth)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{this.WingSize}, {this.Weigth}, { this.FoodEaten}]";
        }

    }
}
