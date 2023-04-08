using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {


            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return "Race cannot be completed because both racers are not available!";
            }
            if (!racerTwo.IsAvailable())
            {
                return $"{racerOne.Username} wins the race! {racerTwo.Username} was not available to race!";
            }
            if (!racerOne.IsAvailable())
            {
                return $"{racerTwo.Username} wins the race! {racerOne.Username} was not available to race!";
            }

            IRacer winner;

            racerTwo.Race();
            racerOne.Race();

            double racingBehaviorMultiplierOne = 1;

            if (racerOne.RacingBehavior == "strict")
            {
                racingBehaviorMultiplierOne = 1.2;
            }
            else if (racerOne.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplierOne = 1.1;
            }

            double chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * racingBehaviorMultiplierOne;

            double racingBehaviorMultiplierTwo = 1;

            if (racerTwo.RacingBehavior == "strict")
            {
                racingBehaviorMultiplierTwo = 1.2;
            }
            else if (racerTwo.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplierTwo = 1.1;
            }

            double chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racingBehaviorMultiplierTwo;

            if (chanceOfWinningTwo > chanceOfWinningOne)
            {
                winner = racerTwo;
            }
            else
            {
                winner = racerOne;
            }

            return $"{racerOne.Username} has just raced against {racerTwo.Username}! {winner.Username} is the winner!";

        }
    }
}
