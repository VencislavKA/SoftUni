using System;
using System.Collections.Generic;
using System.Text;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Cards;
using PlayersAndMonsters.Models.BattleFields;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;




namespace PlayersAndMonsters.Core
{
    public class Engine : Contracts.IEngine
    {
        ManagerController manager;
        CardRepository cardRepository;
        PlayerRepository playerRepository;
        BattleField battleField;
        List<string> OUT;
        public Engine()
        {
            cardRepository = new CardRepository();
            playerRepository = new PlayerRepository();
            battleField = new BattleField();
            OUT = new List<string>();
            manager = new ManagerController();
        }

        public void Run()
        {
            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Exit")
                {
                    foreach (var item in OUT)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                }
                else if (input[0] == "AddPlayer")
                {
                    OUT.Add(manager.AddPlayer(input[1],input[2]));
                }
                else if (input[0] == "AddCard")
                {
                    OUT.Add(manager.AddCard(input[1], input[2]));
                }
                else if (input[0] == "AddPlayerCard")
                {
                    OUT.Add(manager.AddPlayerCard(input[1], input[2]));
                }
                else if (input[0] == "Fight")
                {
                    OUT.Add(manager.Fight(input[1],input[2]));
                }
                else if (input[0] == "Report")
                {
                    OUT.Add(manager.Report());
                }
            }
        }
    }
}
