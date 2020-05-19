using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        public Astronaut(string name, double oxygen)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Astronaut name cannot be null or empty.");
            }
            if (oxygen < 0)/////////////
            {
                throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
            }
            this.Name = name;
            this.Oxygen = oxygen;
        }


        public virtual double Oxygen { get; protected set; }
        public virtual string Name { get; private set; }

        public bool CanBreath
        {
            get
            {
                if (Oxygen == 0)
                {
                    return false;
                }
                return true;
            }
        }
        
        public virtual IBag Bag { get; protected set; }

        public virtual void Breath()
        {
            if (Oxygen <= 10)////////////
            {
                Oxygen = -1.0;
                return;
            }
            Oxygen -= 10;
        }
    }
}
