using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        protected Delicacy(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);

                }
                this.name = value;
            }

        }

        public double Price
        {
            get => this.price;
            private set
            {
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Price:F2} lv";

        }


    }
}
