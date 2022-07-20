using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    internal interface IHero
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Power { get; set; }


        public string CastAbility();
    }
}
