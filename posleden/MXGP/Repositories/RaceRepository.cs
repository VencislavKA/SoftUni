using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Races.Contracts;

namespace MXGP.Repositories
{
    public class RaceRepository : Contracts.IRepository<IRace>
    {
        private List<IRace> races;
        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public void Add(IRace model)
        {
            if (model != null)
            {
                races.Add(model);
            }
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return races.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            foreach (var item in races)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Remove(IRace model)
        {
            if (races.Contains(model))
            {
                races.Remove(model);
                return true;
            }
            return false;
        }
    }
}
