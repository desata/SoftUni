using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        int power = 100;
        public Paladin(string name, string type) : base(name, type)
        {
        }
        public override void CastAbility()
        {
            Console.WriteLine($"{Type} - {Name} healed for {power}");
        }

    }
}
