using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Racers = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Racer> Racers { get; set; }

        public void Add(Racer Racer)
        {
            if (Capacity > Racers.Count)
            {
                Racers.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            int rasers = Racers.RemoveAll(x => x.Name == name);

            if (rasers > 0)
            {
               
                return true;
            }
            return false;
        }

        public Racer GetOldestRacer()
        {
            Racer racer = Racers.OrderByDescending(x => x.Age).FirstOrDefault();

            return racer;
        }

        public Racer GetRacer(string name)
        {
            Racer racer = Racers.FirstOrDefault(x => x.Name == name);

            return racer;
        }

        public Racer GetFastestRacer()
        {
            Racer racer = Racers.OrderByDescending(x => x.Car.Speed).First();

            return racer;
        }

        public int Count { get { return Racers.Count; } }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Racers participating at {this.Name}:");
            foreach (Racer racer in Racers)
            {
                stringBuilder.AppendLine(racer.ToString());
            }
            return stringBuilder.ToString().TrimEnd();


        }
    }
}
