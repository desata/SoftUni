using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {

        private string name;
        private string size;
        private double price;

        public Cocktail(string name, string size, double price)
        {
            this.Name = name;
            this.Size = size;
            this.Price = price;

        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.name = value;
            }
        }


        public string Size { get; private set; }


        public double Price
        {
            get => this.price;

            private set
            {
                this.price = value;

                if (this.size == "Middle")
                {
                    this.price = (2 * value) / 3;
                }
                if (this.size == "Small")
                {
                    this.price = (1 * value) / 3;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.name} ({size}) - {this.price:F2} lv";
        }




    }
}
