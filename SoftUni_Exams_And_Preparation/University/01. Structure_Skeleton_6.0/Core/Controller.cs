using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {

        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            IStudent student;
            int id = students.Models.Count() + 1;

            if (students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return $"{firstName} {lastName} is already added in the repository.";
            }

            student = new Student(id, firstName, lastName);


            students.AddModel(student);
            return $"Student {firstName} {lastName} is added to the {students.GetType().Name}!";
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            ISubject subject;

            int id = subjects.Models.Count() + 1;

            if (subjectType != "TechnicalSubject" && subjectType != "EconomicalSubject" && subjectType != "HumanitySubject")
            {
                return $"Subject type {subjectType} is not available in the application!";
            }
            if (subjects.Models.Any(m => m.Name == subjectName))
            {
                return $"{subjectName} is already added in the repository.";
            }


            if (subjectType == "TechnicalSubject")
            {
                subject = new TechnicalSubject(id, subjectName);
                
            }
            else if (subjectType == "EconomicalSubject")
            {
                subject = new EconomicalSubject(id, subjectName);

            }
            else {

                subject = new HumanitySubject(id, subjectName);
            }

            subjects.AddModel(subject);

            return $"{subjectType} {subjectName} is created and added to the {subjects.GetType().Name}!";
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            IUniversity university;
            int id = universities.Models.Count() + 1;
            List<int> subjectsIds = new List<int>();


            if (universities.Models.Any(u => u.Name == universityName))
            {
                return $"{universityName} is already added in the repository.";
            }
            
            foreach (var subject in requiredSubjects)
            {
               
                subjectsIds.Add(subjects.FindByName(subject).Id);
            }

            university = new University(id, universityName, category, capacity, subjectsIds);
            universities.AddModel(university);

            return $"{universityName} university is created and added to the {universities.GetType().Name}!";
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            if (student == null)
            {
                string firstName = studentName.Split()[0];
                string lastName = studentName.Split()[1];

                return $"{firstName} {lastName} is not registered in the application!";
            }
            if (university == null)
            {
                return $"{universityName} is not registered in the application!";
            }
            if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(y => y == x)))
            {
                return $"{studentName} has not covered all the required exams for {universityName} university!";
            }
            if (student.University == university)
            {
                return $"{student.FirstName} {student.LastName} has already joined {universityName}.";
            }

            student.JoinUniversity(university);
            return $"{student.FirstName} {student.LastName} joined {universityName} university!";

        }

        public string TakeExam(int studentId, int subjectId)
        {
            IStudent student = students.FindById(studentId);
            ISubject subject = subjects.FindById(subjectId);

            if (student == null)
            {
                return "Invalid student ID!";
            }
            if (subject == null)
            {
                return "Invalid subject ID!";
            }
            if (student.CoveredExams.Contains(subjectId))
            {
                return $"{student.FirstName} {student.LastName} has already covered exam of {subject.Name}.";
            }

            student.CoverExam(subject);
            return $"{student.FirstName} {student.LastName} covered {subject.Name} exam!";

        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            var collection = students.Models.Where(s => s.University == university).ToList();
            var studentsCount = collection.Count;


            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentsCount}");
            sb.AppendLine($"University vacancy: {university.Capacity - studentsCount}");

            return sb.ToString().TrimEnd();

        }
    }
}
