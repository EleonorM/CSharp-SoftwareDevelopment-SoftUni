namespace MortalEngines.Core
{
    using MortalEngines.Core.Contracts;
    using MortalEngines.IO.Contracts;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IMachinesManager machinesManager;

        public Engine(IReader reader, IWriter writer, IMachinesManager machinesManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.machinesManager = machinesManager;
        }

        public void Run()
        {
        }
    }
}
