using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IBuyer
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
