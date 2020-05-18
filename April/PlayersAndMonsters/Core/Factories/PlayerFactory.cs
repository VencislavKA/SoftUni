using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Repositories;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : Contracts.IPlayerFactory
    {
        IPlayer IPlayerFactory.CreatePlayer(string type, string username)
        {
            CardRepository cardRepository = new CardRepository();
            if (type == "Beginner")
            {
                Beginner beginner = new Beginner(cardRepository,username);
                return beginner;
            }
            else if (type == "Advanced")
            {
                Advanced advanced = new Advanced(cardRepository,username);
                return advanced;
            }
            return null;
        }
    }
}
