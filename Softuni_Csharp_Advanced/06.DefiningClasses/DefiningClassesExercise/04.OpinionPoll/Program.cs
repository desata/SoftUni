using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split()[0];
                int age = int.Parse(data.Split()[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            List<Person> filteredPerson = people.Where(p => p.Age > 30)
                .OrderBy(x => x.Name)
                .ToList();

            foreach (Person item in filteredPerson)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
