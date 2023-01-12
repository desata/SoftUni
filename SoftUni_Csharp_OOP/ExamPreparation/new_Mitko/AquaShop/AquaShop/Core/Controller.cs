using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private ICollection<IAquarium> aquariums;
        private DecorationRepository decorations;


        public Controller()
        {
            this.aquariums = new HashSet<IAquarium>();
            this.decorations = new DecorationRepository();
        }


        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;

            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }

            this.aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType != "Ornament" && decorationType != "Plant")
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }

            this.decorations.Add(decoration);
            return $"Successfully added {decorationType}.";

        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IAquarium aquarium = aquariums.First(a => a.Name == aquariumName);
            string aquariumType = aquarium.GetType().Name;

            IFish currentFish;

            if (fishType == "SaltwaterFish" )
            {
                currentFish = new SaltwaterFish(fishName, fishSpecies, price);

            }
            else if (fishType == "FreshwaterFish" )
            {
                currentFish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            string output;

            if (fishType == "FreshwaterFish" && aquariumType != "FreshwaterAquarium")
            {
                output = string.Format(OutputMessages.UnsuitableWater);
                   

            }
            else if (fishType == "SaltwaterFish" && aquariumType != "SaltwaterAquarium")
            {
                output = string.Format(OutputMessages.UnsuitableWater);
            }
            else
            {
                aquarium.AddFish(currentFish);
                output = output = string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }

            return output;
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = aquariums.First(a => a.Name == aquariumName);

            var decorationCost = aquarium.Decorations.Sum(x => x.Price);
            var fishCost = aquarium.Fish.Sum(x => x.Price);

            var finalSum = decorationCost + fishCost;

            return $"The value of Aquarium {aquariumName} is {finalSum:F2}.";

        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.First(a => a.Name == aquariumName);
            aquarium?.Feed();

            return $"Fish fed: {aquarium?.Fish.Count}";

        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IAquarium aquarium = this.aquariums.First(a => a.Name == aquariumName);

            IDecoration decoration = this.decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium?.AddDecoration(decoration);
            this.decorations.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            var bs = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                bs.AppendLine(aquarium.GetInfo());
            }

            return bs.ToString().TrimEnd();
        }
    }
}
