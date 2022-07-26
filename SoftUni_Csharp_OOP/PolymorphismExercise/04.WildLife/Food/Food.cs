using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildLife.Food
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; set; }


    }
}
