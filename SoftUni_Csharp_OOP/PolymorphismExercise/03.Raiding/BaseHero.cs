using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }

        public virtual void CastAbility()
        {

            Console.WriteLine( $"{Type} - {Name} healed for");
        }
    }
}
