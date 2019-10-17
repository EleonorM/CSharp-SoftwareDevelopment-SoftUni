namespace MXGP.Models.Motorcycles
{
    using MXGP.Utilities.Messages;
    using System;

    public class PowerMotorcycle : Motorcycle
    {
        private const double cubicCentimeters = 450;
        private const int minHorsePower = 70;
        private const int maxHorsePower = 100;

        public PowerMotorcycle(string model, int horsePower) : base(model, horsePower, cubicCentimeters)
        {
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
