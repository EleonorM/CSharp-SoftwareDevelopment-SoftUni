namespace SoftUniParking
{
    using System;

    public class Car
    {
        public string Make { get; private set; }

        public string Model { get; private set; }

        public int HorsePower { get; private set; }

        public string RegistrationNumber { get; private set; }

        public Car(string make, string model, int horsePower, string registartionNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registartionNumber;
        }

        public override string ToString()
        {
            return $"Make: {this.Make}" + Environment.NewLine + $"Model: {this.Model}" + Environment.NewLine + $"HorsePower: {this.HorsePower}" + Environment.NewLine + $"RegistrationNumber: {this.RegistrationNumber}";
        }
    }
}
