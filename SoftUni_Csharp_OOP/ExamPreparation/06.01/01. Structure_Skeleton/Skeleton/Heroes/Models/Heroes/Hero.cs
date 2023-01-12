using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWeaponName);
                }
                name = value;
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHeroHealth);
                }
                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHeroArmour);
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get => this.weapon;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidWeaponNull);
                }
                this.weapon = value;
            }

        }

        public bool IsAlive => this.Health > 0;


        public void AddWeapon(IWeapon weapon) => this.Weapon = weapon;

        public void TakeDamage(int points)
        {
            var armourLeft = this.Armour - points;

            if (armourLeft >= 0)
            {
                this.Armour = armourLeft;
            }
            else
            {
                this.Armour = 0;

                var damage = -armourLeft;

                var healthLeft = this.Health - damage;

                if (healthLeft < 0)
                {
                    this.Health = 0;
                    
                }
                else
                {
                    this.Health = healthLeft;
                }
            }


        }
    }
}
