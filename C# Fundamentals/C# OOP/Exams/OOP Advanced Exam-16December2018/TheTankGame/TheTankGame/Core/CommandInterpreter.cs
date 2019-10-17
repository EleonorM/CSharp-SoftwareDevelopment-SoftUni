namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            var parameters = new List<string>(inputParameters.Skip(1).ToList());

            string result = (string)this.tankManager
               .GetType()
               .GetMethods()
               .FirstOrDefault(m => m.Name.Contains(command))
               .Invoke(this.tankManager, new object[] { parameters });

            return result.ToString();
        }
    }
}