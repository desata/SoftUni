using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Athletes = new List<IAthlete>();
            Equipment = new List<IEquipment>();

        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }

        }

        public int Capacity { get; private set; }

        public double EquipmentWeight
        {
            get
            {
                return Equipment.Select(e => e.Weight).Sum();
            }

        }

        public ICollection<IEquipment> Equipment { get; private set; }

        public ICollection<IAthlete> Athletes { get; private set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count >= Capacity)
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughSize);
            }
            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            string athletes;

            if (Athletes.Count > 0)
            {
                athletes = string.Join(", ", Athletes.Select(a => a.FullName));
            }
            else
            {
                athletes = "No athletes";
            }
            sb.AppendLine($"Athletes: {athletes}");

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.Append($"Equipment total weight: {this.EquipmentWeight:F2} grams");

            return sb.ToString();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
