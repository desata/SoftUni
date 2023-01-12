using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private readonly ICollection<IFormulaOneCar> models;

        public FormulaOneCarRepository()
        {
            this.models = new HashSet<IFormulaOneCar>();
        }

       IReadOnlyCollection<IFormulaOneCar> IRepository<IFormulaOneCar>.Models => (IReadOnlyCollection<IFormulaOneCar>)this.models;

        void IRepository<IFormulaOneCar>.Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        IFormulaOneCar IRepository<IFormulaOneCar>.FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == name);
        }

        bool IRepository<IFormulaOneCar>.Remove(IFormulaOneCar model)
        {
            return this.models.Remove(model);
        }
    }
}
