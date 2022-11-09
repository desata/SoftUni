using CollectionHierarchy.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Implementations
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> data;
        public AddCollection()
        {
            this.data = new List<string>();
        }
        public int Add(string item)
        {
            this.data.Add(item);
            return this.data.Count - 1;
        }
    }
}
