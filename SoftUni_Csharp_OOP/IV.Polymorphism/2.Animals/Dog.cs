using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favoriteFood) : base(name, favoriteFood)
        {
        }

        public override string ExplainSelf()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(base.ExplainSelf());
            builder.AppendLine("DJAAF");

            return builder.ToString().TrimEnd();

        }
    }
}
