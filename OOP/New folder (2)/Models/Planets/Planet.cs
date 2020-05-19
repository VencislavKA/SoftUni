using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name,string[] bag)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Invalid name!");
            }
            Name = name;
            Items = bag;
        }
        public ICollection<string> Items { get; set; }
        public string Name { get; private set; }
    }
}
