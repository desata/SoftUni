using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armor;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            this.Name = name;
            this.Health = health;
            this.Armour = armour;

        }

        public string Name
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public int Health
        {
            get => this.health;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                this.health = value;
            }
        }

        public int Armour {
            get => this.armor;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                this.armor = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                this.weapon = value;
            }
        }


        public bool IsAlive => this.Health > 0;

        public void AddWeapon(IWeapon weapon)
        {
            throw new NotImplementedException();
        }

        public void TakeDamage(int points)
        {
            throw new NotImplementedException();
        }
    }
}
