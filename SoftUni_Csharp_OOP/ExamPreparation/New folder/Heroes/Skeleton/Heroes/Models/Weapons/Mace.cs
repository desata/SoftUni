using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int damage = 25;

        public Mace(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            return base.DoDamage();
        }
    }
}
