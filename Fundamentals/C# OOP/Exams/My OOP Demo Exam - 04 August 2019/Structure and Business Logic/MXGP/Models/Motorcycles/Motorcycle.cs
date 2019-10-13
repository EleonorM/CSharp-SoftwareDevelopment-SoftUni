namespace MXGP.Models.Motorcycles
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Utilities.Messages;
    using System;

    public abstract class Motorcycle : IMotorcycle
    {
        private const int minLenghtName = 4;
        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minLenghtName)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel, value, minLenghtName));
                }

                this.model = value;
            }
        }

        public int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps * 1.0;
        }
    }
}
