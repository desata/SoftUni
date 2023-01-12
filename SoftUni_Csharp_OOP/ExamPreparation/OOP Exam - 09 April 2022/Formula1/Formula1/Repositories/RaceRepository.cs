using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly ICollection<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }


        IReadOnlyCollection<IRace> IRepository<IRace>.Models => (IReadOnlyCollection<IRace>)this.models;

        void IRepository<IRace>.Add(IRace model)
        {
            this.models.Add(model);
        }

        IRace IRepository<IRace>.FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.RaceName == name);
        }

        bool IRepository<IRace>.Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}
