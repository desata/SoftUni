using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Mace : Weapon
    {
        private const int DAMAGE = 25;
        public Mace(string name, int durability, int damage) : base(name, durability, damage)
        {
        }

      
    }
}
