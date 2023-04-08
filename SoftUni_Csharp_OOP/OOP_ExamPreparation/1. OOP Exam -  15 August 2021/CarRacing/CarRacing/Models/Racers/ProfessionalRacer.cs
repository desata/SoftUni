using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username, ICar car) 
            : base(username, "strict", 30, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.drivingExperience += 10;
        }
    }
}
