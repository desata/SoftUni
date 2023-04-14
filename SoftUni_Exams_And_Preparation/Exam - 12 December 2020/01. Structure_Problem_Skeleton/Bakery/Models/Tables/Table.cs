using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberOfPeople;
        private decimal sumOrder;
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();

        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }


        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get => PricePerPerson * NumberOfPeople; //calculated prop
        }

        public void Clear()
        {
            drinkOrders.Clear();
            foodOrders.Clear();
           // NumberOfPeople = 0;
            IsReserved = false;
        }

        public decimal GetBill()
        {

            foreach (var drink in drinkOrders)
            {
                sumOrder += drink.Price;
            }
            foreach (var food in foodOrders)
            {
                sumOrder += food.Price;
            }
            return sumOrder;
        }

        public string GetFreeTableInfo()
        {
           StringBuilder sb  = new StringBuilder();

            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().TrimEnd();

        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            if (capacity >= numberOfPeople)
            {
                NumberOfPeople = numberOfPeople;
                IsReserved = true;
            } 
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
