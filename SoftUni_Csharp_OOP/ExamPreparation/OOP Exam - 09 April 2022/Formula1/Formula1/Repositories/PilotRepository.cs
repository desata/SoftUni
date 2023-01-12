using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private readonly ICollection<IPilot> models;

        public PilotRepository()
        {
            this.models = new List<IPilot>();
        }

        IReadOnlyCollection<IPilot> IRepository<IPilot>.Models => (IReadOnlyCollection<IPilot>)this.models;

        void IRepository<IPilot>.Add(IPilot model)
        {
           this.models.Add(model);
        }

        IPilot IRepository<IPilot>.FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.FullName == name);
        }

        bool IRepository<IPilot>.Remove(IPilot model)
        {
            return this.models.Remove(model);
        }
    }
}
