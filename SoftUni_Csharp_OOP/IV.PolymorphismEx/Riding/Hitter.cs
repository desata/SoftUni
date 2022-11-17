using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public class Hitter : BasicHero
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
