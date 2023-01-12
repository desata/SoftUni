using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory.Contracts;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name) 
            : base(name, 100, 50, 40, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            if (this.IsAlive && character.IsAlive)
            {
                if (this == character )
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);

                }
                character.TakeDamage(this.AbilityPoints);
            }
        }
    }
}
