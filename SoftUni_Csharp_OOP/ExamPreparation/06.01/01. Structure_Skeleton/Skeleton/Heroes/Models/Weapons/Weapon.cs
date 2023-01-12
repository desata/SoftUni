using Heroes.Models.Contracts;
using Heroes.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Heroes.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private string name;
        private int durability;
        private int damage;

        protected Weapon(string name, int durability, int damage)
        {
            Name = name;
            Durability = durability;
            Damage = damage;
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

        public int Durability
        {
            get { return durability; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDurability);
                }
                durability = value;
            }
        }
         public int Damage
        {
            get { return damage; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidDamage);
                }
                damage = value;
            }
        }


        public int DoDamage()
        {
            this.Durability--;

            if (this.durability == 0)
            {
                return 0;
            }
            return this.Damage;
        }
    }
}
