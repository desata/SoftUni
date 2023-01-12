using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {

        private CarRepository cars;
        private RacerRepository Models;
        private IMap map;


        public Controller()
        {
            this.cars = new CarRepository();
            this.Models = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            ICar car;

            if (type == "SuperCar")
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }
            else if (type == "TunedCar")
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidCarType);
            }


            this.cars.Add(car);

            return $"Successfully added car {car.Make} {car.Model} ({VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            IRacer racer;

            ICar car = cars.FindBy(carVIN);

            if (car != null)
            {
                if (type == "ProfessionalRacer")
                {
                    racer = new ProfessionalRacer(username, car);
                }
                else if (type == "StreetRacer")
                {
                    racer = new StreetRacer(username, car);
                }
                else
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerType);
                }
            }
            else
            {

                throw new ArgumentException(ExceptionMessages.CarCannotBeFound);

            }
            this.Models.Add(racer);

            return String.Format(OutputMessages.SuccessfullyAddedRacer, racer.Username);


        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = Models.FindBy(racerOneUsername);
            IRacer racerTwo = Models.FindBy(racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }
            if (racerTwo == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            
            StringBuilder sb = new StringBuilder();

            var racers = this.Models.Models.OrderByDescending(x => x.DrivingExperience).ThenBy(x => x.Username);
            foreach (var racer in racers)
            {
                sb.AppendLine(racer.ToString()); 

            }

            return sb.ToString().TrimEnd();
        }
    }
}