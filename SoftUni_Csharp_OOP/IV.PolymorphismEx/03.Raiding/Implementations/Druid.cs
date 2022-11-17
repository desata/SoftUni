using Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Implementations
{
    public class Druid : BaseHero
    {
        protected const int Power = 80;
        public Druid(string name) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} healed for {Power}";
        }
    }
}
