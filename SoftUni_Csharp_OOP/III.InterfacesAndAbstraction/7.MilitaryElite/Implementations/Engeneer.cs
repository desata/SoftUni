using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Implementations
{
    public class Engeneer : SpecialisedSoldier, IEngeneer
    {
        public Engeneer(string id, string firstName, string lastName, decimal salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
        }

        public List<IRepair> Repairs { get; set; }
    }
}
