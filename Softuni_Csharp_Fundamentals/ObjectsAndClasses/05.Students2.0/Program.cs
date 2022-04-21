using System;
using System.Collections.Generic;

namespace _5.Student2._0
{
    class Program
    {

        class Student
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }
            public string HomeTown { get; set; }
        }
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] tokens = input.Split(" ");

                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string town = tokens[3];

                if (isStudentExisting(students, firstName, lastName))
                {
                    Student student = GetStudent(students, firstName, lastName);

                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.HomeTown = town;
                }
                else
                {
                    Student student = new Student();
                    {
                        student.FirstName = firstName;
                        student.LastName = lastName;
                        student.Age = age;
                        student.HomeTown = town;

                        students.Add(student);
                    };
                }

                input = Console.ReadLine();

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

        private static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }
            return existingStudent;
        }

        private static bool isStudentExisting(List<Student> students, string firstName, string lastName)
        {
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;
                }

            }
            return false;
        }
    }
}