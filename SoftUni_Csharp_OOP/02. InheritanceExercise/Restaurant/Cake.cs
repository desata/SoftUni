﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name) : base(name, 5m, 250, 1000)
        {
        }

        //Grams = 250
        //Calories = 1000
        //CakePrice = 5

    }
}
