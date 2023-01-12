using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            this.planets = new PlanetRepository();
        }

        string IController.AddUnit(string unitTypeName, string planetName)
        {
            IPlanet planet;
            IMilitaryUnit militaryUnit;

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                planet = planets.FindByName(planetName);
            }
            

            if (unitTypeName == "AnonymousImpactUnit")
            {
                militaryUnit = new AnonymousImpactUnit();
            }
            else if (unitTypeName == "SpaceForces")
            {
                militaryUnit = new SpaceForces();
            }
            else if (unitTypeName == "StormTroopers")
            {
                militaryUnit = new StormTroopers();
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            
            if (planet.Army.Any(u => u.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            else
            {
                planet.AddUnit(militaryUnit);
                planet.Spend(militaryUnit.Cost);
                return $"{unitTypeName} added successfully to the Army of {planetName}!";
            }

        }

        string IController.AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            IPlanet planet;
            IWeapon weapon;

            if (planets.FindByName(planetName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            else
            {
                planet = planets.FindByName(planetName);
            }

            if (weaponTypeName == "BioChemicalWeapon")
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == "NuclearWeapon")
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == "SpaceMissiles")
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            else
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, weaponTypeName, planetName));
            }
            else
            {
                planet.AddWeapon(weapon);
                planet.Spend(weapon.Price);
                return $"{planetName} purchased {weaponTypeName}!";
            }

        }

        string IController.CreatePlanet(string name, double budget)
        {
            IPlanet planet = new Planet(name, budget);
            if (planets.FindByName(planet.Name) == null)
            {
                planets.AddItem(planet);
                return $"Successfully added Planet: {planet.Name}";
            }
            else
            {
                return $"Planet {planet.Name} is already added!";
            }
        }

        string IController.ForcesReport()
        {
            throw new NotImplementedException();
        }

        string IController.SpaceCombat(string planetOne, string planetTwo)
        {
            throw new NotImplementedException();
        }

        string IController.SpecializeForces(string planetName)
        {
            throw new NotImplementedException();
        }
    }
}
