using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {

        private string name;
        private double health;
        private double armour;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;

            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name; 

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; private set; }

        public double Health
        {
            get => this.health;
            
            set
            {
                this.health = value;

                if (health < 0)
                {
                    health = 0;
                }
                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
        }

        public double BaseArmor { get; private set; }

        public double Armor
        {
            get => this.armour;
           
            private set
            {
                this.armour = value;

                if (armour < 0)
                {
                    armour = 0;
                }
            }
        }

        public double AbilityPoints { get; private set; }


        public IBag Bag { get; private set; }


        public bool IsAlive { get; set; } = true;

        public virtual void TakeDamage(double hitPoints)
        {
            if (!this.IsAlive)
            {
                return;
            }

            if (this.Armor - hitPoints >= 0)
            {
                this.Armor -= hitPoints;

            }
            else
            {
                double restPoints = hitPoints - this.Armor;

                this.Armor = 0;

                if (this.Health - restPoints > 0)
                {
                    this.Health -= hitPoints;
                }
                else
                {
                    this.Health = 0;
                    IsAlive = false;
                }
            }
        }

        public virtual void UseItem(Item item)
        {
            if (!this.IsAlive)
            {
                return;
            }
            item.AffectCharacter(this);


        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}