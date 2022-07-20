using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name, string type, int power)
        {
            this.Name = name;
            this.Type = type;
            this.Power = power;

        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Power { get; set; }


        public virtual string CastAbility()
        {
            return $"{Name} healed for {Power}";
        }
    }
}
