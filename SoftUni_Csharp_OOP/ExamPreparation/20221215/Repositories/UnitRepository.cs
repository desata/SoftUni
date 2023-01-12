﻿using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        protected List<IMilitaryUnit> models;

        public UnitRepository()
        {
            this.models = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.models;

        public void AddItem(IMilitaryUnit model)
        {
            this.models.Add(model);
        }

        public IMilitaryUnit FindByName(string name) => models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IMilitaryUnit unit = this.models.FirstOrDefault(x => x.GetType().Name == name);

            return models.Remove(unit);
        }
    }
}
