using System;
using System.Collections.Generic;
using System.Text;
using MXGP.Models.Riders.Contracts;

namespace MXGP.Repositories
{
    public class RiderRepository : Contracts.IRepository<IRider>
    {
        private List<IRider> riders;
        public RiderRepository()
        {
            riders = new List<IRider>();
        }
        public void Add(IRider model)
        {
            if (model != null)
            {
                riders.Add(model);
            }
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return riders.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            foreach (var item in riders)
            {
                if(item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Remove(IRider model)
        {
            if (riders.Contains(model))
            {
                riders.Remove(model);
                return true;
            }
            return false;
        }
    }
}
