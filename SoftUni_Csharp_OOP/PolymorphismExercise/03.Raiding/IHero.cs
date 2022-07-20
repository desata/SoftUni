using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public interface IHero
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public void CastAbility();
    }
}
