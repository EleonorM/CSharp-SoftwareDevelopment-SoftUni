namespace MXGP.Models.Motorcycles
{
    using MXGP.Utilities.Messages;
    using System;

    public class SpeedMotorcycle : Motorcycle
    {
        private const double cubicCentimeters = 125;
        private const int minHorsePower = 50;
        private const int maxHorsePower = 69;

        public SpeedMotorcycle(string model, int horsePower) : base(model, horsePower, cubicCentimeters)
        {
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
