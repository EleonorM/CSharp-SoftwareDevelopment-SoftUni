namespace _08.MilitaryElite.Core
{
    using _08.MilitaryElite.Contracts;
    using _08.MilitaryElite.Exceptions;
    using _08.MilitaryElite.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private readonly List<ISoldier> army;

        public Engine()
        {
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                var args = command.Split();

                var type = args[0];
                var id = args[1];
                var firstName = args[2];
                var lastName = args[3];
                var salary = decimal.Parse(args[4]);

                if (type == "Private")
                {
                    var soldier = new Private(id, firstName, lastName, salary);
                    this.army.Add(soldier);
                }
                else if (type == "LieutenantGeneral")
                {
                    var general = new LieutenantGeneral(id, firstName, lastName, salary);
                    var privateArgs = args.Skip(5).ToArray();

                    foreach (var pId in privateArgs)
                    {
                        ISoldier soldierToAdd = this.army.FirstOrDefault(s => s.Id == pId);

                        general.AddPrivate(soldierToAdd);
                    }

                    this.army.Add(general);
                }
                else if (type == "Engineer")
                {
                    try
                    {
                        var corps = args[5];
                        var engineer = new Engineer(id, firstName, lastName, salary, corps);
                        var repairArgs = args.Skip(6).ToArray();
                        AddRepairs(engineer, repairArgs);
                        this.army.Add(engineer);

                    }
                    catch (InvalidCorseException)
                    {
                    }
                }
                else if (type == "Commando")
                {
                    try
                    {
                        string corps = args[5];
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                        var missionArgs = args.Skip(6).ToArray();

                        for (int i = 0; i < missionArgs.Length; i += 2)
                        {
                            try
                            {
                                var codeName = missionArgs[i];
                                var state = missionArgs[i + 1];
                                var mission = new Mission(codeName, state);
                                commando.AddMission(mission);
                            }
                            catch (InvalidStateException)
                            {
                                continue;
                            }
                        }

                        this.army.Add(commando);
                    }
                    catch (InvalidCorseException)
                    {
                    }
                }
                else if (type == "Spy")
                {
                    var codeNumber = int.Parse(args[4]);
                    var spy = new Spy(id, firstName, lastName, codeNumber);
                    this.army.Add(spy);
                }

                command = Console.ReadLine();
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.army)
            {
                var type = soldier.GetType();
                var actual = Convert.ChangeType(soldier, type);
                Console.WriteLine(actual.ToString());
            }
        }

        private static void AddRepairs(Engineer engineer, string[] repairArgs)
        {
            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                var partName = repairArgs[i];
                var hours = int.Parse(repairArgs[i + 1]);

                var repair = new Repair(partName, hours);
                engineer.AddRepair(repair);
            }
        }
    }
}
