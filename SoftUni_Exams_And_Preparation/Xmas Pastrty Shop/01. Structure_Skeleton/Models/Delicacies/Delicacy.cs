using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using System.Drawing;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
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

        public double Price { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} - {Price:F2} lv");

            //??
            return sb.ToString().TrimEnd();
        }
    }

    
}
