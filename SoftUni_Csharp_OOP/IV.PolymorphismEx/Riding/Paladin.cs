using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public class Paladin : Healer
    {
        private const int Power = 100;
        public Paladin(string name, string type) : base(name, type, Power)
        {
        }

    }
}
