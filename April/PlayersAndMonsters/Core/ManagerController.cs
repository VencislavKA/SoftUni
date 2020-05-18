namespace PlayersAndMonsters.Core
{
    using System;
    using Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Cards;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System.Text;

    public class ManagerController : IManagerController
    {
        private Repositories.PlayerRepository playerRepository;
        private CardRepository cardRepository;
        private BattleField battleField;
        public ManagerController()
        {
            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();
            battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            CardRepository cardRepository = new CardRepository();
            if (type == "Beginner")
            {
                Beginner beginner = new Beginner(cardRepository, username);
                playerRepository.Add(beginner);
                return($"Successfully added player of type Beginner with username: {beginner.Username}");
            }
            else if (type == "Advanced")
            {
                Advanced advanced = new Advanced(cardRepository, username);
                playerRepository.Add(advanced);
                return($"Successfully added player of type Advanced with username: {advanced.Username}");
            }
            return null;
        }

        public string AddCard(string type, string name)
        {
            if (type == "Trap")
            {
                TrapCard trapCard = new TrapCard(name);
                cardRepository.Add(trapCard);
                return($"Successfully added card of type TrapCard with name: {trapCard.Name}");
            }
            else if (type == "Magic")
            {
                MagicCard magicCard = new MagicCard(name);
                cardRepository.Add(magicCard);
                return($"Successfully added card of type MagicCard with name: {magicCard.Name}");
            }
            return null;
        }

        public string AddPlayerCard(string username, string cardName)
        {
            if (playerRepository.Find(username) != null && cardRepository.Find(cardName) != null)
            {
                IPlayer a = playerRepository.Find(username);
                ICard c = cardRepository.Find(username);
                a.CardRepository.Add(c);
                return($"Successfully added card: {c.Name} to user: {a.Username}");
            }
            return null;
        }

        public string Fight(string attackUser, string enemyUser)
        {
            if (playerRepository.Find(attackUser) != null && playerRepository.Find(enemyUser) != null)
            {
                var a = playerRepository.Find(attackUser);
                var h = playerRepository.Find(enemyUser);
                battleField.Fight(a, h);
                return($"Attack user health {a.Health} - Enemy user health {h.Health}");
            }
            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in playerRepository.Players)
            {
                sb.AppendLine($"Username: {item.Username} - Health: {item.Health} - Cards {item.CardRepository.Count}");
                if (item.CardRepository.Count != 0)
                {
                    foreach (var card in item.CardRepository.Cards)
                    {
                        sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                    }
                }
                sb.AppendLine("###");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
