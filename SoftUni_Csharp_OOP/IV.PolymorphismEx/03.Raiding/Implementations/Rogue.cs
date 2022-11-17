using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Implementations
{
    public class Rogue : BaseHero
    {
        protected const int Power = 80;
        public Rogue(string name) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {Power} damage";
        }
    }
}
