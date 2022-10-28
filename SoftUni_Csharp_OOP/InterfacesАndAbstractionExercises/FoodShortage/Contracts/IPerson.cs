using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage.Contracts
{
    public interface IPerson : IBuyer
    {
        string Name { get; }
        int Age { get; }
    }
}
