using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models = new List<IAstronaut>();


        public IReadOnlyCollection<IAstronaut> Models => models;

        public void Add(IAstronaut model)
        {
            models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
           return models.FirstOrDefault(m => m.Name == name);
        }

        public bool Remove(IAstronaut model)
        {
           return models.Remove(model);
        }
    }
}
