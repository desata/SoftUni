using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Hitter : BaseHero
    {
        public Hitter(string name, string type, int power) : base(name, type, power)
        {
        }

        public override string CastAbility()
        {
            return $"{Type} - {Name} hit for {Power} damage";
        }
    }
}
