using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        public static void Main()
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (input[0] == "Tournament")
                {
                    break;
                }

                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Exists(x => x.Name == trainerName))
                {
                    var currentTrainerIndex = trainers.FindIndex(x => x.Name == trainerName);
                    trainers[currentTrainerIndex].CollectionOfPokemons.Add(pokemon);
                }
                else
                {
                    var trainer = new Trainer(trainerName, pokemon);
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.CollectionOfPokemons.Exists(x => x.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.CollectionOfPokemons.ForEach(x => x.Health -= 10);
                        trainer.CollectionOfPokemons.RemoveAll(x => x.Health <= 0);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.CollectionOfPokemons.Count}");
            }
        }
    }
}
