using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private List<string> items;

        public Planet(string name)
        {
            this.Name = name;
            items = new List<string>();
        }

        public ICollection<string> Items => items;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }


    }
}
