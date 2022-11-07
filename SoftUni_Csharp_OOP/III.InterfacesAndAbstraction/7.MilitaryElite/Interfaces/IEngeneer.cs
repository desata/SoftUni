using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IEngeneer : ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; set; }
    }
}
