using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BakeryOpenning
{
    internal class Bakery
    {
        private List<Employee> workers = new List<Employee>();

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Workers = workers;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Employee> Workers { get; set; }

        public void Add(Employee employee)
        {
            if (Capacity > workers.Count)
            {
                workers.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = workers.FirstOrDefault(x => x.Name == name);

            if (employee != null)
            {
                workers.Remove(employee);
                return true;
            }
            return false;
        }

        public Employee GetOldestEmployee()
        {
            return workers.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        { 
            return workers.FirstOrDefault(x => x.Name == name);
        }

        public int Count
        {
            get => Workers.Count;
        }

        public string Report()
        { 
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker}");
            }

            return stringBuilder.ToString().TrimEnd();


        }

    }
}
