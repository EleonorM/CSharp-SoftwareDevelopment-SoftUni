namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;

        public string GetTime => stopwatch.Elapsed.ToString();

        public List<string> Laps { get; private set; }

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            Laps = new List<string>();
        }

        public string Lap()
        {
           var timespan = stopwatch.Elapsed;
            Laps.Add(timespan.ToString());
            return timespan.ToString();
        }

        public void Reset()
        {
            stopwatch.Restart();
            stopwatch.Stop();
            Laps = new List<string>();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
    }
}
