using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IRebel : IPerson
    {
        string Group { get;  }
    }
}
