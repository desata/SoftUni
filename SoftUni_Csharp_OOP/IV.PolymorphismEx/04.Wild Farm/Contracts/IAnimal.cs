using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.WildFarm
{
    public interface IAnimal
    {
        public string Type { get; }

        public string Name { get;  }

        public double Weigth { get;  }

        public int FoodEaten { get;  }

        string AskForFood();

        public void Eat(string food, int quantity);
    }
}
