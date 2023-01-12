using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            this.models = new List<IWeapon>();
        }


        public IReadOnlyCollection<IWeapon> Models => this.models;

        public void AddItem(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name) => models.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string name)
        {
            IWeapon weapon = this.models.FirstOrDefault(x => x.GetType().Name == name);
            
            return models.Remove(weapon);
        }

    }
}
