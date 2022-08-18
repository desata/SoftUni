using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        List<Player> players = new List<Player>();
        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            Players = players;
        }

        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }


        public int Count { get { return Players.Count; } }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrWhiteSpace(player.Name) || string.IsNullOrWhiteSpace(player.Position))
            {
                return "Invalid player's information.";
            }
            if (OpenPositions <= 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            OpenPositions -= 1;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player player = Players.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                OpenPositions += 1;
                return Players.Remove(player);
                
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int countOfRemovedPlayers = Players.RemoveAll(x => x.Position == position);

            if (countOfRemovedPlayers != 0)
            {
                OpenPositions += countOfRemovedPlayers; //-=
                return countOfRemovedPlayers;
            }
            return 0;
        }

        public Player RetirePlayer(string name)
        {
            foreach (Player person in Players)
            {
                if (person.Name == name)
                {
                    person.Retired = true;
                    return person;
                }
            }
            return null;
        }

        public List<Player> AwardPlayers(int games) // AwardPlayer in StartUp
        {
            List<Player> awardedPlayers = new List<Player>();

            foreach (Player person in Players)
            {
                if (person.Games >= games)
                {
                    awardedPlayers.Add(person);
                }
            }
            return awardedPlayers;
        }

        public string Report()
        { 
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Active players competing for Team " + Name + " from Group " + Group + ":");

            foreach (Player person in Players)
            {
                if (person.Retired != true)
                {
                    stringBuilder.AppendLine(person.ToString());
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

    }
}
