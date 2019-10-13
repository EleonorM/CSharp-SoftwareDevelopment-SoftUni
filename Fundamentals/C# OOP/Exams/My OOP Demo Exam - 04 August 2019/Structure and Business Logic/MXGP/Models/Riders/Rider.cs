namespace MXGP.Models.Riders
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public class Rider : IRider
    {
        private string name;
        private const int minLenghtName = 5;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < minLenghtName)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, minLenghtName));
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException(ExceptionMessages.MotorcycleMustBeNull);
            }

            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
