using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        readonly List<IHero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => this.heroes;

        public void Add(IHero model)
        {
            throw new NotImplementedException();
        }

        public IHero FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IHero model)
        {
            throw new NotImplementedException();
        }
    }
}
