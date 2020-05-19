using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;


namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : Contracts.IPlayerRepository
    {
        private List<IPlayer> players;
        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public int Count => players.Count;

        public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.players.Contains(player))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            players.Add(player);
        }

        public IPlayer Find(string username)
        {
            foreach (var player in players)
            {
                if (player.Username == username)
                {
                    return player;
                }
            }
            return null;
        }

        public bool Remove(IPlayer player)
        {
            if(player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.players.Contains(player))
            {
                players.Remove(player);
                return true;
            }
            return false;
        }
    }
}
