using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interface
{
    public interface IAddRemoveCollection : IAddCollection
    {
        public string Remove();
    }
}
