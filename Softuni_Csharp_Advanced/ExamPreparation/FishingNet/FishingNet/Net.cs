using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            //eventualen problem s imeto
            Fish = new List<Fish>();
        }

        //The name of the collection should be Fish, which could not be modified.

        public string Material { get; set; }
        public int Capacity { get; set; }
        public List<Fish> Fish { get; set; }

        //methods
        // Getter Count - returns the total count of the fish in the net.
        public int Count() => Fish.Count;

        public string AddFish(Fish fish)
        {

            if (Capacity == Fish.Count)
            {
                return "Fishing net is full.";
            }
            if (fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            if (string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            else
            {
                Fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }

        }

        public bool ReleaseFish(double weight) 
        {

            if (Fish.Any(f => f.Weight == weight))
            {
                Fish.FirstOrDefault(f => f.Weight == weight);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fish GetFish(string fishType)
        {
            //– search and returns a fish by given fish type.
            return Fish.FirstOrDefault(f => f.FishType == fishType);

        }

        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(f => f.Weight).FirstOrDefault();

        }

        public string Report()
        {
            Fish = Fish.OrderByDescending(x => x.Length).ToList();

            StringBuilder output = new StringBuilder();

            output.AppendLine($"Into the {Material}:");

            foreach (var fishes in Fish)
            {
                output.AppendLine(fishes.ToString().TrimEnd());
            }

            return output.ToString().TrimEnd();

        }

    }
}
