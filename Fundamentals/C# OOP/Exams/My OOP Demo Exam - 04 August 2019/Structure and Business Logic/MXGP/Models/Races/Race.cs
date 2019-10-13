namespace MXGP.Models.Races
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using MXGP.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    partial class Race : IRace
    {
        private string name;
        private int laps;
        private const int minLenghtName = 5;
        private const int minNumberOfLaps = 1;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.riders = new List<IRider>();
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

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < minNumberOfLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, minNumberOfLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null)
            {
                throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            }

            if (!rider.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            }

            if (this.riders.FirstOrDefault(x => x.Name == rider.Name) != null)
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
