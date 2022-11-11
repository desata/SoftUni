using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animals
    {
        public Cat(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ExplainSelf());
            builder.AppendLine("MEEOW");

            return builder.ToString().Trim();
            
        }
    }
}
