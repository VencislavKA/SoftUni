using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        int i;
        public int DeadAftrerMIssion { get => i;}
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            i = 0;
            foreach (var person in astronauts)
            {
                while (person.CanBreath)
                {
                    person.Bag.Items.Add(planet.Items.First());
                    person.Breath();
                    planet.Items.Remove(planet.Items.First());
                }
                i++;
            }
        }
    }
}
