using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main()
        {

            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string input = Console.ReadLine();


            while (input != "END")
            {
                try
                {
                    string command = input.Split(";")[0];
                    string name = input.Split(";")[1];

                    if (command == "Team")
                    {
                        Team team = new Team(name);
                        teams.Add(name, team);
                    }
                    else if (command == "Add")
                    {
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        string playerName = input.Split(";")[2];
                        int endurance = int.Parse(input.Split(";")[3]);
                        int sprint = int.Parse(input.Split(";")[4]);
                        int dribble = int.Parse(input.Split(";")[5]);
                        int passing = int.Parse(input.Split(";")[6]);
                        int shooting = int.Parse(input.Split(";")[7]);

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[name].AddPlayer(player);

                    }
                    else if (command == "Remove")
                    {

                        string playerName = input.Split(";")[2];
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Player {playerName} is not in {name} team.");
                            input = Console.ReadLine();
                            continue;
                        }
                        bool removed = teams[name].RemovePlayer(playerName);

                        if (!removed)
                        {
                            Console.WriteLine($"Player {playerName} is not in {name} team.");
                        }
                    }
                    else if (command == "Rating")
                    {
                        if (!teams.ContainsKey(name))
                        {
                            Console.WriteLine($"Team {name} does not exist.");
                            input = Console.ReadLine();
                            continue;
                        }

                        Console.WriteLine($"{name} - {teams[name].Stats}");
                    }
                }
                catch (Exception exeption)
                {

                    Console.WriteLine(exeption.Message);
                }

                input = Console.ReadLine();

            }
        }
    }
}
