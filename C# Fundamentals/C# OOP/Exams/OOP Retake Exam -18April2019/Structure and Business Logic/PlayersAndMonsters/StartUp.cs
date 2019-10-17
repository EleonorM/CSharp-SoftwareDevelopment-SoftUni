using PlayersAndMonsters.Core;
using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters
{

    public class StartUp
    {
        public static void Main()
        {
            var reader = new Reader();
            var writer = new Writer();
            Engine engine = new Engine(reader,writer);
            engine.Run();
        }
    }
}