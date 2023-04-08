using System.Collections.Generic;
using System.Collections.ObjectModel;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {


        public IReadOnlyCollection<Subject> Models => throw new System.NotImplementedException();

        public void AddModel(Subject model)
        {
            throw new System.NotImplementedException();
        }

        public Subject FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Subject FindByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
