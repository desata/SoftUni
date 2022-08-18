using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {

        public Clinic(int capacity)
        {
            Capacity = capacity;
            Pets = new List<Pet>();
        }

        public int Capacity { get; set; }
        public List<Pet> Pets { get; set; }

        public void Add(Pet pet)
        {
            if (this.Capacity >= Pets.Count)
            {
                Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pets = Pets.FirstOrDefault(x => x.Name == name);

            if (pets != null)
            {
               return Pets.Remove(pets);
               // return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pets = Pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);

            if (pets == null)
            {
                return null;
            }
            return pets;
        }

        public Pet GetOldestPet()
        {
            return this.Pets.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public int Count
        {
            get => this.Pets.Count();
        }

        public string GetStatistics()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("The clinic has the following patients:");
            foreach (var pet in Pets)
            {
                stringBuilder.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
