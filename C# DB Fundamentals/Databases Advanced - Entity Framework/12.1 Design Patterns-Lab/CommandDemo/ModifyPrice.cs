namespace CommandDemo
{
    using System.Collections.Generic;

    public class ModifyPrice
    {
        private readonly IList<ICommand> commands;
        private ICommand command;

        public ModifyPrice()
        {
            commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => this.command = command;

        public void Invoke()
        {
            commands.Add(command);
            command.ExecuteAction();
        }
    }
}
