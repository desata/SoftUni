using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;

        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }

        public double Cost { get; private set; }

        public int EnduranceLevel { get; private set; } = 1;

        public void IncreaseEndurance()
        {
            this.EnduranceLevel++;
            if (EnduranceLevel > 20)
            {
                EnduranceLevel = 20;
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
