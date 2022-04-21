using System;
using System.Linq;
using System.Collections.Generic;


namespace _06.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
           
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (input != "end")
            {
                string[] command = input.Split(" : ");
                string courseName = command[0];
                string studentName = command[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                    courses[courseName].Add(studentName);

                input = Console.ReadLine();
            }

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");

                foreach (var course in item.Value)
                {
                    Console.WriteLine($"-- {course}");
                }
       
}
        }
    }
}
