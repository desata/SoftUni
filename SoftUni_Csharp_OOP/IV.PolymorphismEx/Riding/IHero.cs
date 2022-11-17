using System;
using System.Collections.Generic;
using System.Text;

namespace Riding
{
    public interface IHero
    {
        string Name { get; }

        string Type { get; }

        int Power { get; }

        string CastAbility();

    }
}
