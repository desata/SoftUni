﻿using CollectionHierarchy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Implementations
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private readonly List<string> data;
        public AddRemoveCollection()
        {
            this.data = new List<string>();
        }
        public int Add(string item)
        {
            this.data.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string lastElement = this.data.LastOrDefault();
            if (lastElement != null)
            {
                this.data.Remove(lastElement);
            }
            return lastElement;
        }
    }
}
