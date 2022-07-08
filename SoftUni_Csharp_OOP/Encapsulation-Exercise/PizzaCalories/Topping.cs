using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            { "meat", 1.2},
            { "veggies", 0.8},
            { "cheese", 1.1},
            { "sauce", 0.9},


        };

        private string toppingType;
        private int toppingGrams;

        public Topping(string toppingType, int toppingGrams)
        {
            this.ToppingType = toppingType;
            this.ToppingGrams = toppingGrams;
        }
        public string ToppingType
        {
            get { return toppingType; }
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingType = value;
            }
        }

        public int ToppingGrams
        {
            get { return toppingGrams; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                toppingGrams = value;
            }
        }


        public double Calories 
            => 2 
            * ToppingGrams 
            * modifiers[ToppingType.ToLower()];

    }
}
