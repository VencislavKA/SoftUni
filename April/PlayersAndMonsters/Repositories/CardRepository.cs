using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : Contracts.ICardRepository
    {
        private List<ICard> cards;
        public CardRepository()
        {
            cards = new List<ICard>();
        }
        public int Count { get { return cards.Count; } }

        public IReadOnlyCollection<ICard> Cards => cards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if(cards.Contains(card))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            cards.Add(card);
        }

        public ICard Find(string name)
        {
            foreach (var item in cards)
            {
                if (item.Name == name)
                {
                    return item;
                }
            }
            return null;
        }

        public bool Remove(ICard card)
        {
            if(card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            if(Find(card.Name) != null)
            {
                cards.Remove(card);
                return true;
            }
            return false;
        }
    }
}
