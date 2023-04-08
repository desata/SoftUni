using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> models = new List<IPlanet>();

        public IReadOnlyCollection<IPlanet> Models => models;

        public void Add(IPlanet model)
        {
           models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            return models.Remove(model);
        }
    }
}