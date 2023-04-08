using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private Collection<IStudent> students;

        public StudentRepository()
        {
           // students = new Collection<IStudent>();
        }

        public IReadOnlyCollection<Student> Models => //this.students;
            throw new System.NotImplementedException();

        public void AddModel(Student model)
        {
            throw new System.NotImplementedException();
        }

        public Student FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Student FindByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
