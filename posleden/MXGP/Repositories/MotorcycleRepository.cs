using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Motorcycles.Contracts;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Contracts.IRepository<IMotorcycle>
    {
        private List<IMotorcycle> motorcycles;
        public MotorcycleRepository()
        {
            motorcycles = new List<IMotorcycle>();
        }
        public void Add(IMotorcycle model)
        {
            if (model != null) 
            {
                motorcycles.Add(model);
            }
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return motorcycles.AsReadOnly();
        }

        public IMotorcycle GetByName(string name)
        {
            foreach (var item in motorcycles)
            {
                if (item.Model == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Remove(IMotorcycle model)
        {
            if (motorcycles.Contains(model))
            {
                motorcycles.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
