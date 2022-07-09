using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IBuyer
    {
        public Citizen(string name, int age, string id, string date)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Date = date;
            
        }

        //Citizen Peter 22 9010101122 10/10/1990

        public string Name { get; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Date { get; set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10; 
        }
    }
}
