using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer
    {
        public string Name { get; set; }
        public int Food { get; set; }
        public void BuyFood();
    }
}
