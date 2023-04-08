using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            IBag Bag = new Backpack();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }

        public double Oxygen
        { 
            get => oxygen;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                oxygen = value;
            }
        }

        public bool CanBreath { get; set; }

        public IBag Bag { get; set; }

        public virtual void Breath()
        {
            oxygen -= 10;
            if (oxygen < 0)
            {
                CanBreath = false;
            }
            else
            {
                CanBreath = true;
            }
        }
    }
}
