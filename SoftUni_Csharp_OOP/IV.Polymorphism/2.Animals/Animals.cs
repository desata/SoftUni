﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animals
    {
        public Animals(string name, string favoriteFood)
        {
            Name = name;
            FavoriteFood = favoriteFood;
        }

        public string Name { get; set; }
        public string FavoriteFood { get; set; }

        public virtual string ExplainSelf()
        {
            return $"I am {Name} and my fovourite food is {FavoriteFood}";
        }
    }
}
