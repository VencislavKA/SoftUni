using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards.Contracts
{
    public abstract class Card : ICard
    {
        public Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }


        private string name;
        private int demagepoints;
        private int healthpoints;


        public string Name 
        { 
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Card's name cannot be null or an empty string.");
                }
                name = value;
            }
        }
        public int DamagePoints 
        { 
            get 
            {
                return demagepoints;
            } 
            set 
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Card's damage points cannot be less than zero.");
                }
                demagepoints = value;
            }
        }


        public int HealthPoints 
        {
            get 
            {
                return healthpoints;
            } 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Card's HP cannot be less than zero.");
                }
                healthpoints = value;
            }
        }
    }
}
