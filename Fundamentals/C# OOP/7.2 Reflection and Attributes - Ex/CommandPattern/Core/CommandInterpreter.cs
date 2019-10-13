namespace CommandPattern.Core
{
    using CommandPattern.Core.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostFix = "Command";

        public string Read(string inpit)
        {
            var args = inpit.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var commandName = args[0] + CommandPostFix;
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == commandName);

            if (type != null)
            {
                ICommand command = (ICommand)Activator.CreateInstance(type);
                string result = command.Execute(args.Skip(1).ToArray());
                return result;
            }
            else
            {
                throw new ArgumentException("The command does not exist!");
            }
        }
    }
}
