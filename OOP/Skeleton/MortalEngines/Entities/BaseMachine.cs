using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : Contracts.IMachine
    {
        private string name;
        private IPilot pilot;
        public string Name 
        { 
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                name = value;
            }
        }

        public IPilot Pilot 
        { 
            get 
            {
                return pilot;
            }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                pilot = value;
            }
        }

        public double HealthPoints { get => HealthPoints; set => HealthPoints = value; } 
        

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets { get; set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

        }
    }
}
