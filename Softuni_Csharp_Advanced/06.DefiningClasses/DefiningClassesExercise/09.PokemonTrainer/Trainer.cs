using System;
using System.Collections.Generic;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, Pokemon collectionOfPokemon)
        {
            this.Name = name;
            this.CollectionOfPokemons.Add(collectionOfPokemon);
        }

        public string Name { get; set; }

        public int Badges { get; set; } = 0;

        public List<Pokemon> CollectionOfPokemons { get; set; } = new List<Pokemon>();
    }
}