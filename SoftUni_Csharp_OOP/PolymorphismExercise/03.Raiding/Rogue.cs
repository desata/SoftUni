using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        int power = 80;
        public Rogue(string name, string type) : base(name, type)
        {
        }

        public override void CastAbility()
        {
            Console.WriteLine( $"{Type} - {Name} hit for {power} damage");
        }
    }
}
