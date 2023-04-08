using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        public Student(int studentId, string firstName, string lastName)
        {
            
        }

        public int Id => throw new NotImplementedException();

        public string FirstName => throw new NotImplementedException();

        public string LastName => throw new NotImplementedException();

        public IReadOnlyCollection<int> CoveredExams => throw new NotImplementedException();

        public IUniversity University => throw new NotImplementedException();

        public void CoverExam(ISubject subject)
        {
            throw new NotImplementedException();
        }

        public void JoinUniversity(IUniversity university)
        {
            throw new NotImplementedException();
        }
    }
}
