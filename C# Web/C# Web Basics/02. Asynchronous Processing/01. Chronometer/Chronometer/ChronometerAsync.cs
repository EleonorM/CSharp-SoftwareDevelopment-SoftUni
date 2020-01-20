namespace Chronometer
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChronometerAsync : IChronometer
    {
        private long miliseconds;

        private bool isRunnig;

        public string GetTime => $"{miliseconds / 60000:d2}:{miliseconds / 1000:d2}:{(miliseconds % 1000):d4}";

        public List<string> Laps { get; private set; }

        public ChronometerAsync()
        {
            Laps = new List<string>();
        }

        public string Lap()
        {
            string lap = GetTime;
            Laps.Add(lap);
            return lap;
        }

        public void Reset()
        {
            Stop();
            miliseconds = 0;
            Laps.Clear();
        }

        public void Start()
        {
            isRunnig = true;
            Task.Run(() =>
            {
                while (isRunnig)
                {
                    Thread.Sleep(1);
                    miliseconds++;
                }
            });
        }

        public void Stop()
        {
            isRunnig = false;
        }
    }
}
