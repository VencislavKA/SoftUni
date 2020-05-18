using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    class GunRepository : Contracts.IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => guns.AsReadOnly();

        void IRepository<IGun>.Add(IGun model)
        {
            guns.Add(model);
        }

        IGun IRepository<IGun>.Find(string name)
        {
            foreach (var item in guns)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        bool IRepository<IGun>.Remove(IGun model)
        {
            if (guns.Contains(model))
            {
                guns.Remove(model);
                return true;
            }
            return false;
        }
    }
}
