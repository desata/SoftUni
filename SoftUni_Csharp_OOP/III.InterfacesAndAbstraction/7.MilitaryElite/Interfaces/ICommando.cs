using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando : ISpecialisedSoldier
    {
        public List<ICommando> Missions { get; set; }

        void CompleteMission(string codeName);
    }
}
