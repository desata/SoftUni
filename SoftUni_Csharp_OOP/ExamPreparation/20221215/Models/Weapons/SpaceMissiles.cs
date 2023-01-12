using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class SpaceMissiles : Weapon
    {
        public SpaceMissiles(int destructionLevel) : base(8.75, destructionLevel)
        {
        }
    }
}
