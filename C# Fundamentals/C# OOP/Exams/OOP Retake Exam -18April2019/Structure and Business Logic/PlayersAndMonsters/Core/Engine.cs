namespace PlayersAndMonsters.Core
{
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.IO;
    using PlayersAndMonsters.IO.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            IBattleField battleField = new BattleField();
            ICardRepository cardRepository = new CardRepository();
            IPlayerRepository playerRepository = new PlayerRepository();
            ICardFactory cardFactory = new CardFactory();
            IPlayerFactory playerFactory = new PlayerFactory();

            IManagerController managerController = new ManagerController(
                cardRepository,
                playerRepository,
                battleField,
                cardFactory,
                playerFactory
            );
            while (true)
            {
                var input = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input[0] == "Exit")
                {
                    break;
                }
                try
                {
                    if (input[0] == "AddPlayer")
                    {
                        this.writer.WriteLine(managerController.AddPlayer(input[1], input[2]));

                    }
                    else if (input[0] == "AddCard")
                    {
                        this.writer.WriteLine(managerController.AddCard(input[1], input[2]));

                    }
                    else if (input[0] == "AddPlayerCard")
                    {
                        this.writer.WriteLine(managerController.AddPlayerCard(input[1], input[2]));

                    }
                    else if (input[0] == "Fight")
                    {
                        this.writer.WriteLine(managerController.Fight(input[1], input[2]));

                    }
                    else if (input[0] == "Report")
                    {
                        this.writer.WriteLine(managerController.Report());

                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
