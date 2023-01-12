using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> coctails;

        public CocktailRepository()
        {
            this.coctails = new List<ICocktail>();
        }

        public IReadOnlyCollection<ICocktail> Models { get; private set; }

        public void AddModel(ICocktail model)
        {
            coctails.Add(model);
        }
    }
}
