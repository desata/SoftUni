using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public class Warrior : Hitter
    {
        private const int Power = 100;
        public Warrior(string name, string type) : base(name, type, Power)
        {
        }
    }
}
