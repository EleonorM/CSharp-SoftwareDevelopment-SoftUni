namespace MortalEngines.Entities
{
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.PilotNameIsNullOrWhiteSpace);
                }

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException(ExceptionMessages.MachineIsNull);
            }

            this.machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} - {machines.Count} machines");

            foreach (IMachine machine in machines)
            {
                sb.Append(machine.ToString());
            }

            return sb.ToString();
        }
    }
}
