using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; set; }


        //methods
        public string AddAnimal(Animal animal)
        {
            //If the animal species is null or whitespace, return "Invalid animal species."

            if (animal.Species == " " || animal.Species == null)
            {
                return "Invalid animal species.";
            }
            //If the animal’s diet is different from "herbivore" or "carnivore", return "Invalid animal diet."
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count >= this.Capacity )
            {
                return "The zoo is full.";
            }
            
            Animals.Add(animal);
            return "Successfully added {animal species} to the zoo.";
            
        }
        public int RemoveAnimals(string species) //– removes all animals by given species, as a result, return the count of the animals which were removed.
        {
            int count = Animals.RemoveAll(animal => animal.Species == species);
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet) // search and returns a list of animals by given diet.
        { 
            List<Animal> animalByDiet = new List<Animal>();
            animalByDiet = Animals.Where(a => a.Diet == diet).ToList();
            return animalByDiet;
        }

        public Animal GetAnimalByWeight(double weight) //return the first animal, with the given weight.
        {
            return Animals.FirstOrDefault(a => a.Weigth == weight);

        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int animalByLength = Animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength);

            return $"There are {animalByLength} animals with a length between {minimumLength} and {maximumLength} meters.";

        }

    }
}
