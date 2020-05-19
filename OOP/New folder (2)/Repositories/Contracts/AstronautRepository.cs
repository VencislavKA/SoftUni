using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Astronauts;


namespace SpaceStation.Repositories.Contracts
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        public IReadOnlyCollection<IAstronaut> Models => Models;
        public List<IAstronaut> Astronauts;

        public void Add(IAstronaut model)
        {
            try
            {
                if (Astronauts.Count != 0)
                {
                    Astronauts.Add(model);
                }
            }
            catch
            {
                Astronauts = new List<IAstronaut>();
                Astronauts.Add(model);
                
            }

        }

        public IAstronaut FindByName(string name)
        {
            foreach (var item in Astronauts)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }
        public bool Remove(IAstronaut model)
        {
            if (Astronauts.Contains(model))
            {
                Astronauts.Remove(model);
                return true;
            }
            return false;
        }
    }
}
