using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        ICar car;


        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;

        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                this.username = value;
            }
        }

        public string RacingBehavior 
        {
            get => this.racingBehavior;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                this.racingBehavior = value;
            }
        }
        public int DrivingExperience
        {
            get => drivingExperience;
            set 
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                this.drivingExperience = value;
            }
        }

        public ICar Car
        {
            get => car;
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                this.car = value;
            }
        }

        public bool IsAvailable()
        {
            return (this.car.FuelAvailable >= this.car.FuelConsumptionPerRace);

        }

        public virtual void Race()
        {
            this.car.Drive();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}");
            sb.AppendLine($"--Driving behavior: {this.RacingBehavior}");
            sb.AppendLine($"--Driving experience: {this.DrivingExperience}");
            sb.AppendLine($"--Car: {this.Car.Make} {this.Car.Model} ({this.Car.VIN})");

            return sb.ToString().TrimEnd();
        }

    }
}
