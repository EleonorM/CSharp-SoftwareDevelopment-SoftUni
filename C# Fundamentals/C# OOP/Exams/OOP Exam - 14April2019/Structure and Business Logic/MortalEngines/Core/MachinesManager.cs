namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Common;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(x => x.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }
            else
            {
                var pilot = new Pilot(name);
                this.pilots.Add(pilot);
                return string.Format(OutputMessages.PilotHired, name);
            }
        }

        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var tank = new Tank(name, attackPoints, defensePoints);
                this.machines.Add(tank);

                return string.Format(OutputMessages.TankManufactured, tank.Name, tank.AttackPoints, tank.DefensePoints);
            }
        }

        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }
            else
            {
                var fighter = new Fighter(name, attackPoints, defensePoints);
                this.machines.Add(fighter);
                return string.Format(OutputMessages.FighterManufactured, fighter.Name, fighter.AttackPoints, fighter.DefensePoints,"ON");
            }
        }

        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == selectedPilotName);
            var machine = this.machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (pilot == null)
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (machine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }
            else if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }
            else
            {
                pilot.AddMachine(machine);
                machine.Pilot = pilot;
                return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
            }
        }

        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = this.machines.FirstOrDefault(m => m.Name == attackingMachineName);
            var defendingMachine = this.machines.FirstOrDefault(m => m.Name == defendingMachineName);

            if (attackingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (defendingMachine == null)
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }
            else if (attackingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defendingMachine.HealthPoints <= 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }
            else
            {
                attackingMachine.Attack(defendingMachine);
                return string.Format(OutputMessages.AttackSuccessful, defendingMachine.Name, attackingMachine.Name, defendingMachine.HealthPoints);
            }
        }

        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots.FirstOrDefault(x => x.Name == pilotReporting);
            return pilot.Report();
        }

        public string MachineReport(string machineName)
        {
            var machine = this.machines.FirstOrDefault(m => m.Name == machineName);
            return machine.ToString();
        }

        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var fighter = (IFighter)this.machines.FirstOrDefault(f => f.Name == fighterName);
            if (fighter == null)
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }
            else
            {
                fighter.ToggleAggressiveMode();
                return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
            }
        }

        public string ToggleTankDefenseMode(string tankName)
        {
            var tank = (ITank)this.machines.FirstOrDefault(t => t.Name == tankName);
            if (tank == null)
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }
            else
            {
                tank.ToggleDefenseMode();
                return string.Format(OutputMessages.TankOperationSuccessful, tankName);
            }
        }
    }
}