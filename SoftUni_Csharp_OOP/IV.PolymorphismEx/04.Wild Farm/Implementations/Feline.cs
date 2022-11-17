using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Implementations
{
    public abstract class Feline : Mammal
    {
        protected Feline(string type, string name, double weigth, string livingRegion, string breed) : base(type, name, weigth, livingRegion)
        {
            Breed = breed;
        }
        public string Breed { get; private set; }


        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weigth}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
