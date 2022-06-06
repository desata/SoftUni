using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create a program, which reads a name of a student and his/her grades and adds them to the student record, then prints the students' names with their grades and their average grade.

            int studentNumber = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentNumber; i++)
            {
                string[] input = Console.ReadLine().Split();
                string studentName = input[0];
                decimal studentGrade = decimal.Parse(input[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                }
                students[studentName].Add(studentGrade);

            }
            foreach (var student in students)
            {
                var grades = student.Value;
                var average = grades.Average();
                Console.Write($"{student.Key} -> ");
                foreach (var grade in grades)
                {
                    Console.Write($"{grade:F2} ");
                }
                Console.WriteLine($"(avg: {average:F2})");
            }
        }
    }
}
