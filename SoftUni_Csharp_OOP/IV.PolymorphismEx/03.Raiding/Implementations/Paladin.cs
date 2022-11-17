using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Implementations
{
    public class Paladin : BaseHero
    {
        protected const int Power = 100;
        public Paladin(string name) : base(name, Power)
        {           
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {Power}";
        }
    }
}
