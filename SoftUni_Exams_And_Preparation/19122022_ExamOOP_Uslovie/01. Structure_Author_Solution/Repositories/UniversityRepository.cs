using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> universities;

        public UniversityRepository()
        {
            this.universities = new List<IUniversity>();
        }

        public IReadOnlyCollection<IUniversity> Models => this.universities;

        public void AddModel(IUniversity model)
        {
            this.universities.Add(model);
        }

        public IUniversity FindById(int id) => this.universities.FirstOrDefault(x => x.Id == id);

        public IUniversity FindByName(string name) => this.universities.FirstOrDefault(x => x.Name == name);
    }
}
