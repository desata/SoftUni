using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private WeaponRepository weapons;
        private UnitRepository army;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.weapons = new WeaponRepository();
            this.army = new UnitRepository();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                this.name = value;
            }
        }

        public double Budget 
        { get => this.budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => Math.Round(this.MilitaryPowerCalculator(), 3);

        private double MilitaryPowerCalculator()
        {
            double result = this.army.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.army.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }

        public IReadOnlyCollection<IMilitaryUnit> Army => this.army.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.army.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            if (this.Budget < amount)
            {
                throw new ArgumentException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();

            string militaryUnitName;
            if (Army.Count == 0)
            {
                militaryUnitName = "No units";
            }
            else
            {
                militaryUnitName = (string.Join(", ", Army.GetType().Name));
            }

            string weaponName;
            if (Weapons.Count == 0)
            {
                weaponName = "No weapons";
            }
            else
            {
                weaponName = (string.Join(", ", Weapons.GetType().Name));
            }

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.budget} billion QUID");
            sb.AppendLine($"--Forces: {militaryUnitName}");
            sb.AppendLine($"--Combat equipment: {weaponName}");
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");


            return sb.ToString().TrimEnd();
        }
    }
}
