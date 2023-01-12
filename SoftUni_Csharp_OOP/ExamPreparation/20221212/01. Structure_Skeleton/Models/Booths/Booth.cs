using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;

        }

        //private readonly


        public int BoothId { get; private set; }

        public int Capacity
        { get => this.capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.CapacityLessThanOne);
                }
                this.capacity = value;
            }

        }

        public IRepository<IDelicacy> DelicacyMenu  {get; set;}

        public IRepository<ICocktail> CocktailMenu { get; set; }

        public double CurrentBill { get; set; } = 0;

        public double Turnover { get; set; } = 0;

        public bool IsReserved { get; set; } = false;

        public void ChangeStatus()
        {
            if (IsReserved == true)
            {
                IsReserved = false;
            }
            else
            {
                IsReserved = true;
            }
        }

        public void Charge()
        {
            this.Turnover = this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine($"-Cocktail menu:");
           sb.AppendLine($"--");
            
            
            return sb.ToString();
        }
    }
}
