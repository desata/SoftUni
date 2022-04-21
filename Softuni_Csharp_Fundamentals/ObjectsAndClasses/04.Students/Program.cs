using System;
using System.Collections.Generic;

namespace _04.Students
{

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string HomeTown { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] argument = command.Split(' ');

                string firstName = argument[0];
                string lastName = argument[1];
                int age = int.Parse(argument[2]);
                string town = argument[3];

                Student student = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    HomeTown = town
                };
                students.Add(student);
                command = Console.ReadLine();
            }

            string filterCity = Console.ReadLine();
            foreach (Student student in students)
            {
                if (student.HomeTown == filterCity)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }

            }
        }
    }
}
