using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : Contracts.IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race() 
        {
            riders = new List<IRider>();
        }

        public string Name { get=> name; 
            set
            {
                if(string.IsNullOrEmpty(value) && value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                name = value;
            } 
        }

        public int Laps { get=>laps; 
            set
            {
                if (laps < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                Laps = value;
            } 
        }

        public IReadOnlyCollection<IRider> Riders => riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentException("Rider cannot be null.");
            }
            else if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            else if (riders.Contains(rider))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {Name} race.");
            }
            riders.Add(rider);
        }
    }
}
