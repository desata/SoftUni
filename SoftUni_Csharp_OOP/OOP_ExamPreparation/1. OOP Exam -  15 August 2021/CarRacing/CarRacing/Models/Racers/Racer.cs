using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        public string username;
        public string racingBehavior;
        public int drivingExperience;
        public ICar car;

        public Racer(string username, string racingBehavior, int drivingExperience, ICar car)
        {
            this.Username = username;
            this.RacingBehavior = racingBehavior;
            this.DrivingExperience = drivingExperience;
            this.Car = car;

        }

        public string Username
        { 
            get => username;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }

        public string RacingBehavior
        {
            get => racingBehavior;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
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
                drivingExperience = value;
            }
        }

        public ICar Car
        { 
            get => car;
            set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }

                car = value;
            }
        }

        public bool IsAvailable()
        {
            if (this.car.FuelAvailable < this.car.FuelConsumptionPerRace)
            {
               return false;
            }
            return true;
        }

        public virtual void Race()
        {
            Car.Drive();

        }
    }
}
