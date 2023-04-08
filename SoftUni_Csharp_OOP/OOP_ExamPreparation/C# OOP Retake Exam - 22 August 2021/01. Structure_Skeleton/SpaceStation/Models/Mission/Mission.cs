using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {

        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            IAstronaut astronaut;

            while (astronauts.Count > 0)
            {
                astronaut = astronauts.First();

                if (astronaut.Oxygen <= 0)
                {
                    astronauts.Remove(astronaut);
                    return;
                }

                astronaut.Breath();

                astronauts.Remove(astronaut);

            }

        }
    }
}
