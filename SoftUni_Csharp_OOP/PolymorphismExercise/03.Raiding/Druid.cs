using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        int power = 80;
        public Druid(string name, string type) : base(name, type)
        {
            
        }

        public override void CastAbility()
        {
            Console.WriteLine($"{Type} - {Name} healed for {power}");
        }
    }
}
