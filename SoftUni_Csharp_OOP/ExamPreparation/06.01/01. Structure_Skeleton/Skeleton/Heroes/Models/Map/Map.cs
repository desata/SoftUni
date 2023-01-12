using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {

            var knights = new List<Knight>();
            var barbarians = new List<Barbarian>();


            foreach (var player in players)
            {
                if (player is Knight knight)
                {
                    knights.Add(knight);
                }
                else if (player is Barbarian barbarian)
                {
                    barbarians.Add(barbarian);
                }
                else
                {
                    throw new InvalidOperationException("Invalid player type");
                }
            }
        }
    }
}
