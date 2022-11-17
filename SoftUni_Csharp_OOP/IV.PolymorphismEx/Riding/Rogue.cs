using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public class Rogue : Hitter
    {
        private const int Power = 80;
        public Rogue(string name, string type) : base(name, type, Power)
        {
        }
    }
}
