using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts
{
    public class Satchel : Bag
    {

        public Satchel() : base(20)
        {
        }
    }
}
