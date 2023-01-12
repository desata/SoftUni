using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory.Contracts

{
    public abstract class Bag : IBag
    {
        private int capacity;
         private readonly List<Item> items;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public virtual void AddItem(Item item)
        {
            
            if (this.capacity < Load + item.Weight)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.Items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag, name);
            }

           //TODO?  items.Remove(item);

            return item;
        }
    }
}
