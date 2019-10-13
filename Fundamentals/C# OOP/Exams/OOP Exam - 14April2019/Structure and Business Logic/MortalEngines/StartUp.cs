namespace MortalEngines
{
    using MortalEngines.Core;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var mn = new MachinesManager();

            Console.WriteLine(mn.HirePilot("Smith"));
            Console.WriteLine(mn.HirePilot("Stones"));
            Console.WriteLine(mn.ManufactureFighter("Boeing", 180, 90));
            Console.WriteLine(mn.ManufactureTank("T-72", 100, 100));
            Console.WriteLine(mn.EngageMachine("Stones", "T-72"));
            Console.WriteLine(mn.EngageMachine("Smith", "Boeing"));
            Console.WriteLine(mn.AttackMachines("Boeing", "T-72"));
            Console.WriteLine(mn.MachineReport("Boeing"));
            Console.WriteLine(mn.MachineReport("T-72"));
        }
    }
}