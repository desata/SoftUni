using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public abstract class BasicHero : IHero
    {
        protected BasicHero(string name, string type, int power)
        {
            Name = name;
            Type = type;
            Power = power;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Power { get; set; }

        public virtual string CastAbility()
        {
            return " ";
        }
    }
}
