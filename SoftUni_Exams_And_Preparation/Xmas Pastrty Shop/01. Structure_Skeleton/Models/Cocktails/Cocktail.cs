using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
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
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.name = value;
            }
        }

        public string Size
        {
            get => this.size;
            private set
            {
                this.size = value;
            }


        }

        public double Price
        {
            get => this.price;
            private set
            {
                if (this.Size == "Middle")
                {
                    value = value * 2 / 3;
                }
                else if (this.Size == "Small")
                {
                    value = value * 1 / 3;
                }
                
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} ({size}) - {Price:F2} lv");

            //??
            return sb.ToString().TrimEnd();
        }

    }
}
