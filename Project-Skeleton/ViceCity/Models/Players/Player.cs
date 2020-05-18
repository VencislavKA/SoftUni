using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Repositories.Contracts;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player
    {
        public Player(string name, int lifePoints)
        {
            Name = name;
            LifePoints = lifePoints;
        }
        
        public IRepository<Gun> gunRepository { get;set; }
        private bool isAlive
        {
            get
            {
                if (LifePoints <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public string Name { get => Name; 
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }
                Name = value;
            }
        }
        public int LifePoints { get => LifePoints;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                LifePoints = value; 
            } 
        }
        public void TakeLifePoints(int points)//////////////////////
        {
            if(LifePoints > points)
            {
                LifePoints -= points;
            }
            else
            {
                isAlive = false;
            }
        }
    }
}
