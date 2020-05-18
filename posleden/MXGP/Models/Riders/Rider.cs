using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : Contracts.IRider
    {
        public Rider(string name)
        {
            Name = name;
        }


        private string name;
        private IMotorcycle motorcycles;
        private int numberOfWins;
        
        public string Name { get=>name;
            private set
            {
                if(string.IsNullOrEmpty(value) && value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }
        public IMotorcycle Motorcycle { get; protected set; }
        public int NumberOfWins { get; }
        public bool CanParticipate 
        { 
            get 
            {
                if (Motorcycle != null)
                {
                    return true;
                }
                return false;
            } 
        }
        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException("Motorcycle cannot be null.");
            }
        }
        public void WinRace()
        {
            numberOfWins++;
        }
    }
}
