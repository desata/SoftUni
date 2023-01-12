using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private ICollection<IPilot> pilots;
        //private ICollection<IFormulaOneCar> cars;
        private string raceName;
        private int numberOfLaps;

        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
           // this.cars = new List<IFormulaOneCar>();
        }

        public string RaceName
        {
            get => this.raceName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get => this.numberOfLaps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
                    }

        public bool TookPlace { get; set; } = false;

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {

            this.Pilots.Add(pilot);

        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            string took;
            if (this.TookPlace == true)
            {
                took = "Yes";
            }
            else
            {
                took = "No"; 
            }

            sb.AppendLine($"The {this.raceName} race has:");
            sb.AppendLine($"Participants: {this.pilots.Count}");
            sb.AppendLine($"Number of laps: {this.numberOfLaps}");
            sb.AppendLine($"Took place: {took}");


            return sb.ToString().TrimEnd();
        }
    }
}
