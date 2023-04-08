using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<University>
    {
        private IReadOnlyCollection<University> models;

        public IReadOnlyCollection<University> Models => throw new NotImplementedException();

        public void AddModel(University model)
        {
            throw new NotImplementedException();
        }

        public University FindById(int id)
        {
            throw new NotImplementedException();
        }

        public University FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
