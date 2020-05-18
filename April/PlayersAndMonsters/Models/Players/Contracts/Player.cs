using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players.Contracts
{
    public abstract class Player : IPlayer
    {
        public Player(ICardRepository cardRepository, string username, int health)
        {
            CardRepository = cardRepository;
            Username = username;
            Health = health;
        }
        
        private string username;
        private int healt;
        private ICardRepository cardRepository;
        public ICardRepository CardRepository { get => cardRepository; set => cardRepository = value; }

        public string Username 
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
                }
                username = value;
            }
        }

        public int Health
        {
            get => healt;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }
                healt = value;
            }
        }


        public bool IsDead 
        {
            get;
            private set;
        }


        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if(Health < damagePoints)
            {
                Health = 0;
            }
            else
            {
                Health -= damagePoints;
            }
        }
    }
}
