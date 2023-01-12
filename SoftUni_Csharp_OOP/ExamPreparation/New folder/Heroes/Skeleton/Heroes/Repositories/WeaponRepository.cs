using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void Add(IWeapon model)
        {
            throw new NotImplementedException();
        }

        public IWeapon FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IWeapon model)
        {
            throw new NotImplementedException();
        }
    }
}
