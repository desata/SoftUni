using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks.Dataflow;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly List<Character> characters;
		private readonly Stack<Item> items;

		public WarController()
		{
			characters = new List<Character>();
			items = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			Character character = null;

			if (characterType == nameof(Warrior))
			{
				character = new Warrior(name);
			}
			else if (characterType == nameof(Priest))
			{
				character = new Priest(name);
			}
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidCharacterType, characterType);
			}

			this.characters.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);

		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item = null;

			if (itemName == nameof(HealthPotion))
			{
				item = new HealthPotion();

            }
			else if (itemName == nameof(FirePotion))
			{
				item = new FirePotion();

            }
			else
			{
				throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
			}
			this.items.Push(item);

			return string.Format(SuccessMessages.AddItemToPool, itemName);

        }

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

            Character currentCharacter = characters.FirstOrDefault(x => x.Name == characterName);

            if (currentCharacter == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);

            }

			if (!items.Any())
			{
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}



            Item itemToAdd = items.Pop();

            currentCharacter.Bag.AddItem(itemToAdd);

			return $"{characterName} picked up {nameof(itemToAdd)}!";
        }

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

            Character currentCharacter = characters.FirstOrDefault(x => x.Name == characterName);

            if (currentCharacter == null)
            {
                throw new ArgumentException(ExceptionMessages.CharacterNotInParty, characterName);

            }
			Item item = currentCharacter.Bag.GetItem(itemName);

			currentCharacter.UseItem(item);

            return String.Format(SuccessMessages.UsedItem, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var character in this.characters.OrderByDescending(x => x.IsAlive).ThenByDescending(y => y.Health))
			{
				sb.AppendLine(String.Format(SuccessMessages.CharacterStats, character.Name, character.Health, character.BaseHealth, character.Armor, character.BaseArmor, character.IsAlive ? "Alive" : "Dead"));


            }
			return sb.ToString().TrimEnd();

            //"{name} - HP: {health}/{baseHealth}, AP: {armor}/{baseArmor}, Status: {Alive/Dead}"
            throw new NotImplementedException();
		}

		public string Attack(string[] args)
		{
			throw new NotImplementedException();
		}

		public string Heal(string[] args)
		{
			throw new NotImplementedException();
		}
	}
}