﻿using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string data = Console.ReadLine();
                string name = data.Split()[0];
                int age = int.Parse(data.Split()[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }


            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
        }
    }
}
