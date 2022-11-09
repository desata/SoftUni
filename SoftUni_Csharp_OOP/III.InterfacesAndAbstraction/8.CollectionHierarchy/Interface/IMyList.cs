using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Interface
{
    public interface IMyList : IAddRemoveCollection
    {
        public int Used { get; }
    }
}
