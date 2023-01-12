using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private double price;
        private int destructionLevel;
        protected Weapon(double price, int destructionLevel)
        {
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }

        public double Price  {get; private set;}

        public int DestructionLevel
        {
            get => this.destructionLevel;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
                }
                if (value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
                }

                this.destructionLevel = value;
            }
        }
    }
}
