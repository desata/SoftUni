using Heroes.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private int maceDamage = 25;

        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            throw new NotImplementedException();
        }
    }
}
