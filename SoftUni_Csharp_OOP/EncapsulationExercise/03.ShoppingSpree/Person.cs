using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
		private string name;
		private decimal money;
		private List<Product> products;

		public Person(string name, decimal money)
		{
			this.Name = name;
			this.Money = money;
			this.products = new List<Product>();
		}

		public IReadOnlyCollection<Product> Products => this.products;

		public string Name
		{
			get
			{ 
				return this.name; 
			}
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}
				name = value; 
			}
		}

		public decimal Money 
		{
			get 
			{ 
				return this.money; 
			}
			private set 
			{
				if (value < 0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				money = value; 
			}
		}

		public bool AddProduct(Product product)
		{
			if (this.money - product.Cost < 0)
			{
				return false;
				
			}
			this.products.Add(product);
			this.money -= product.Cost;

			return true;

        }


	}
}