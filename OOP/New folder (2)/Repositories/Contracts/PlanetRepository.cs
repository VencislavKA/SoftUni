using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Planets;

namespace SpaceStation.Repositories.Contracts
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        public IReadOnlyCollection<IPlanet> Models => Models;
        public readonly List<IPlanet> planets = new List<IPlanet>();
        public void Add(IPlanet model) => planets.Add(model);

        public IPlanet FindByName(string name)
        {
            foreach (var item in planets)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Remove(IPlanet model)
        {
            if (planets.Contains(model))
            {
                planets.Remove(model);
                return true;
            }
            return false;
        }
    }
}
