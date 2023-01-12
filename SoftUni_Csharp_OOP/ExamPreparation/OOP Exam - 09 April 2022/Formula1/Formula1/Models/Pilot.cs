using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;

        private ICollection<IFormulaOneCar> Cars;

        public Pilot(string fullName)
        {
            this.FullName = fullName; 
            this.Cars = new HashSet<IFormulaOneCar>();
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }

                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get => this.Car;
            private set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                this.Car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; } = false;

        public void AddCar(IFormulaOneCar car)
        {
            this.Cars.Add(car);

            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.fullName} has {this.NumberOfWins} wins.";
        }
    }
}
