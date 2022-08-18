using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        List<Student> students = new List<Student>();

        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = students;
        }

        // students collection

        public int Capacity { get; set; }
        public List<Student> Students { get; set; }

        public string RegisterStudent(Student student)
        {
            if (this.Capacity == this.Students.Count)
            {
                return "No seats in the classroom";
            }
            students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            Students.Remove(student);
            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> student = Students.Where(x => x.Subject == subject).ToList();

            if (student.Count == 0)
            {
                return "No students enrolled for the subject";
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Subject: {subject}");
            stringBuilder.AppendLine("Students:");

            foreach (var person in student)
            {
                stringBuilder.AppendLine($"{person.FirstName} {person.LastName}");
            }
            return stringBuilder.ToString().TrimEnd();
        }

        public int GetStudentsCount()
        { 
            return Students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

           return student;
        }

    }
}
