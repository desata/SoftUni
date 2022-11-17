using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public class Druid : Healer
    {
        private const int Power = 80;
        public Druid(string name, string type) : base(name, type, Power)
        {
        }

    }
}
