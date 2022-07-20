using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Healer : BaseHero
    {
        public Healer(string name, string type, int power) : base(name, type, power)
        {
        }

        public override string CastAbility()
        {
            return $"{Type} - {Name} healed for {Power}";
        }
    }
}
