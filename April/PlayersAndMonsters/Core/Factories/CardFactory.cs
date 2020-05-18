using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Models.Cards;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : Contracts.ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            if (type == "Magic")
            {
                MagicCard magicCard = new MagicCard(name);
                return magicCard;
            }
            else if (type == "Trap") 
            {
                TrapCard trapCard = new TrapCard(name);
                return trapCard;
            }
            return null;
        }
    }
}
