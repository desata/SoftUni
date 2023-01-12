using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {

        private List<IDelicacy> delicasies;

        public DelicacyRepository()
        {
            delicasies = new List<IDelicacy>();
        }

        public IReadOnlyCollection<IDelicacy> Models { get; private set; }

        public void AddModel(IDelicacy model)
        {
            delicasies.Add(model);
        }
    }
}
