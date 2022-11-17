using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public class Healer : BasicHero
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
