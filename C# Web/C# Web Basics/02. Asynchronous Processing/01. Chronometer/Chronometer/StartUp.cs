namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            var chronometer = new ChronometerAsync();
            while (true)
            {
                var command = Console.ReadLine();
                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "laps")
                {
                    var laps = chronometer.Laps;
                    if (laps.Count>0)
                    {

                        Console.WriteLine("Laps:");
                        for (int i = 0; i < laps.Count; i++)
                        {
                            Console.WriteLine($"{i}. {laps[i].ToString()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Laps:no laps");
                    }
                }
                else if (command == "time")
                {
                    var time = chronometer.GetTime;
                    Console.WriteLine(time);
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
                else if (command == "exit")
                {
                    chronometer.Stop();
                    return;
                }
                else
                {
                    Console.WriteLine("Function not implemented!");
                }
            }
        }
    }
}
