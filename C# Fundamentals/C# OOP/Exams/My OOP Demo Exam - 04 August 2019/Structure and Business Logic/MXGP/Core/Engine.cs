namespace MXGP.Core
{
    using MXGP.Core.Contracts;
    using MXGP.IO;
    using MXGP.IO.Contracts;
    using System;

    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IChampionshipController controller;

        public Engine()
        {
            reader = new ConsoleReader();
            writer = new ConsoleWriter();
            controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    return;
                }
                try
                {
                    if (input[0] == "CreateRider")
                    {
                        var name = input[1];
                        writer.WriteLine(controller.CreateRider(name));
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        var type = input[1];
                        var model = input[2];
                        var horsePower = int.Parse(input[3]);
                        writer.WriteLine(controller.CreateMotorcycle(type, model, horsePower));
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        var riderName = input[1];
                        var motorcycleName = input[2];
                        writer.WriteLine(controller.AddMotorcycleToRider(riderName, motorcycleName));
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        var raceName = input[1];
                        var riderName = input[2];
                        writer.WriteLine(controller.AddRiderToRace(raceName, riderName));
                    }
                    else if (input[0] == "CreateRace")
                    {
                        var name = input[1];
                        var laps = int.Parse(input[2]);
                        writer.WriteLine(controller.CreateRace(name, laps));
                    }
                    else if (input[0] == "StartRace")
                    {
                        var name = input[1];
                        writer.WriteLine(controller.StartRace(name));
                    }
                    else if (input[0] == "End")
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
