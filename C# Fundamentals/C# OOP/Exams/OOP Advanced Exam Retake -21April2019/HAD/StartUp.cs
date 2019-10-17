using HAD.Contracts;
using HAD.Core;
using HAD.Core.Factory;
using HAD.IO;

namespace HAD
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var manager = new HeroManager();
            var commandProcessor = new CommandProcessor(manager);
            var engine = new Engine(reader, writer, commandProcessor);
            engine.Run();
        }
    }
}
