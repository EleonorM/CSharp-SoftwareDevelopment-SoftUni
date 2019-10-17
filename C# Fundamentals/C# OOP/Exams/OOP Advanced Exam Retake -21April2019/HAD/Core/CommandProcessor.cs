namespace HAD.Core
{
    using HAD.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class CommandProcessor : ICommandProcessor
    {
        private readonly IManager heroManager;

        public CommandProcessor(IManager heroManager)
        {
            this.heroManager = heroManager;
        }

        public string Process(IList<string> arguments)
        {
            string command = arguments[0];
            arguments = arguments.Skip(1).ToList();

            var result = string.Empty;
            if (arguments.Count == 0)
            {
                result = (string)heroManager
                   .GetType()
                   .GetMethods()
                   .FirstOrDefault(x => x.Name.Contains(command))
                   .Invoke(this.heroManager, null);

            }
            else
            {
                result = (string)heroManager
                    .GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name.Contains(command))
                    .Invoke(this.heroManager, new object[] { arguments });
            }

            return result;
        }
    }
}