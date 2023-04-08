using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        public University(int universityId, string universityName, string category, int capacity, ICollection<int> requiredSubjects)
        {

        }
        public int Id => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();

        public string Category => throw new NotImplementedException();

        public int Capacity => throw new NotImplementedException();

        public IReadOnlyCollection<int> RequiredSubjects => throw new NotImplementedException();
    }
}
