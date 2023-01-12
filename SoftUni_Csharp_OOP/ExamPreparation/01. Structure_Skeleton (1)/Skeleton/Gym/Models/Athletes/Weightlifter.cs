using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public class Weightlifter : Athlete
    {
        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, 50)
        {
        }

        public override void Exercise()
        {
            //If total stamina exceeds 100, set the stamina to 100 and throw an ArgumentException with a message: "Stamina cannot exceed 100 points."

            this.Stamina += 10;
            
        }
    }
}
